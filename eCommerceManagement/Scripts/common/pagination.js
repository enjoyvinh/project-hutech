'use strict';

angular.module('ui.bootstrap.pagination', [])

.controller('PaginationController', ['$scope', '$attrs', '$parse', '$interpolate',
function ($scope, $attrs, $parse, $interpolate) {
	  var self = this,
		setNumPages = $attrs.numPages ? $parse($attrs.numPages).assign : angular.noop;

	  this.init = function (defaultItemsPerPage) {
		  if ($attrs.itemsPerPage) {
			  $scope.$parent.$watch($parse($attrs.itemsPerPage), function (value) {
				  self.itemsPerPage = parseInt(value, 10);
				  $scope.totalPages = self.calculateTotalPages();
			  });
		  } else {
			  this.itemsPerPage = defaultItemsPerPage;
		  }
	  };

	  this.noPrevious = function () {
		  return this.page === 1;
	  };
	  this.noNext = function () {
		  return this.page === $scope.totalPages;
	  };

	  this.isActive = function (page) {
		  return this.page === page;
	  };

	  this.calculateTotalPages = function () {
		  var totalPages = this.itemsPerPage < 1 ? 1 : Math.ceil($scope.totalItems / this.itemsPerPage);
		  return Math.max(totalPages || 0, 1);
	  };

	  this.getAttributeValue = function (attribute, defaultValue, interpolate) {
		  return angular.isDefined(attribute) ? (interpolate ? $interpolate(attribute)($scope.$parent) : $scope.$parent.$eval(attribute)) : defaultValue;
	  };

	  this.render = function () {
		  this.page = parseInt($scope.page, 10) || 1;
		  if (this.page > 0 && this.page <= $scope.totalPages) {
			  $scope.pages = this.getPages(this.page, $scope.totalPages);
		  }
	  };

	  $scope.selectPage = function (page) {
		  if (!self.isActive(page) && page > 0 && page <= $scope.totalPages) {
			  $scope.page = page;
			  $scope.onSelectPage({
				  page: page
			  });
		  }
	  };

	  $scope.$watch('page', function () {
		  self.render();
	  });

	  $scope.$watch('totalItems', function () {
		  $scope.totalPages = self.calculateTotalPages();
	  });

	  $scope.$watch('totalPages', function (value) {
		  setNumPages($scope.$parent, value); // Readonly variable

		  if (self.page > value) {
			  $scope.selectPage(value);
		  } else {
			  self.render();
		  }
	  });
}
])

.constant('paginationConfig', {
	itemsPerPage: 10,
	boundaryLinks: false,
	directionLinks: true,
	firstText: 'Đầu',
	previousText: 'Trước',
	nextText: 'Tiếp',
	lastText: 'Cuối',
	rotate: false
})

.directive('pagination', ['$parse', 'paginationConfig',
function ($parse, config) {
	  return {
		  restrict: 'E',
		  scope: {
			  page: '=',
			  totalItems: '=',
			  onSelectPage: ' &'
		  },
		  controller: 'PaginationController',
		  //templateUrl : 'template/pagination/pagination.html',
		  //templateUrl: 'pagination.html',
	      //templateUrl: 'pagination',
		  template: '<ul class="pagination"><li ng-repeat="page in pages" ng-class="{active: page.active, disabled: page.disabled}"><a href ng-click="selectPage(page.number)">{{page.text}}</a></li></ul>',
          replace: true,
		  link: function (scope, element, attrs, paginationCtrl) {

			  // Setup configuration parameters
			  var maxSize,
				boundaryLinks = paginationCtrl.getAttributeValue(attrs.boundaryLinks, config.boundaryLinks),
				directionLinks = paginationCtrl.getAttributeValue(attrs.directionLinks, config.directionLinks),
				firstText = paginationCtrl.getAttributeValue(attrs.firstText, config.firstText, true),
				previousText = paginationCtrl.getAttributeValue(attrs.previousText, config.previousText, true),
				nextText = paginationCtrl.getAttributeValue(attrs.nextText, config.nextText, true),
				lastText = paginationCtrl.getAttributeValue(attrs.lastText, config.lastText, true),
				rotate = paginationCtrl.getAttributeValue(attrs.rotate, config.rotate);

			  paginationCtrl.init(config.itemsPerPage);

			  if (attrs.maxSize) {
				  scope.$parent.$watch($parse(attrs.maxSize), function (value) {
					  maxSize = parseInt(value, 10);
					  paginationCtrl.render();
				  });
			  }

			  // Create page object used in template
			  function makePage(number, text, isActive, isDisabled) {
				  return {
					  number: number,
					  text: text,
					  active: isActive,
					  disabled: isDisabled
				  };
			  }

			  paginationCtrl.getPages = function (currentPage, totalPages) {
				  var pages = [];

				  // Default page limits
				  var startPage = 1,
					endPage = totalPages;
				  var isMaxSized = (angular.isDefined(maxSize) && maxSize < totalPages);

				  // recompute if maxSize
				  if (isMaxSized) {
					  if (rotate) {
						  // Current page is displayed in the middle of the visible ones
						  startPage = Math.max(currentPage - Math.floor(maxSize / 2), 1);
						  endPage = startPage + maxSize - 1;

						  // Adjust if limit is exceeded
						  if (endPage > totalPages) {
							  endPage = totalPages;
							  startPage = endPage - maxSize + 1;
						  }
					  } else {
						  // Visible pages are paginated with maxSize
						  startPage = ((Math.ceil(currentPage / maxSize) - 1) * maxSize) + 1;

						  // Adjust last page if limit is exceeded
						  endPage = Math.min(startPage + maxSize - 1, totalPages);
					  }
				  }

				  // Add page number links
				  for (var number = startPage; number <= endPage; number++) {
					  var page = makePage(number, number, paginationCtrl.isActive(number), false);
					  pages.push(page);
				  }

				  // Add links to move between page sets
				  if (isMaxSized && !rotate) {
					  if (startPage > 1) {
						  var previousPageSet = makePage(startPage - 1, '...', false, false);
						  pages.unshift(previousPageSet);
					  }

					  if (endPage < totalPages) {
						  var nextPageSet = makePage(endPage + 1, '...', false, false);
						  pages.push(nextPageSet);
					  }
				  }

				  // Add previous & next links
				  if (directionLinks) {
					  var previousPage = makePage(currentPage - 1, previousText, false, paginationCtrl.noPrevious());
					  pages.unshift(previousPage);

					  var nextPage = makePage(currentPage + 1, nextText, false, paginationCtrl.noNext());
					  pages.push(nextPage);
				  }

				  // Add first & last links
				  if (boundaryLinks) {
					  var firstPage = makePage(1, firstText, false, paginationCtrl.noPrevious());
					  pages.unshift(firstPage);

					  var lastPage = makePage(totalPages, lastText, false, paginationCtrl.noNext());
					  pages.push(lastPage);
				  }

				  return pages;
			  };
		  }
	  };
}
])

.constant('pagerConfig', {
	itemsPerPage: 6,
	previousText: 'Â« Previous',
	nextText: 'Next Â»',
	align: true
})

.directive('pager', ['pagerConfig',
function (config) {
	  return {
		  restrict: 'EA',
		  scope: {
			  page: '=',
			  totalItems: '=',
			  onSelectPage: ' &'
		  },
		  controller: 'PaginationController',
		  templateUrl: 'template/pagination/pager.html',
		  replace: true,
		  link: function (scope, element, attrs, paginationCtrl) {

			  // Setup configuration parameters
			  var previousText = paginationCtrl.getAttributeValue(attrs.previousText, config.previousText, true),
				nextText = paginationCtrl.getAttributeValue(attrs.nextText, config.nextText, true),
				align = paginationCtrl.getAttributeValue(attrs.align, config.align);

			  paginationCtrl.init(config.itemsPerPage);

			  // Create page object used in template
			  function makePage(number, text, isDisabled, isPrevious, isNext) {
				  return {
					  number: number,
					  text: text,
					  disabled: isDisabled,
					  previous: (align && isPrevious),
					  next: (align && isNext)
				  };
			  }

			  paginationCtrl.getPages = function (currentPage) {
				  return [
					makePage(currentPage - 1, previousText, paginationCtrl.noPrevious(), true, false),
					makePage(currentPage + 1, nextText, paginationCtrl.noNext(), false, true)
				  ];
			  };
		  }
	  };
}
]);

/*
angular.module("template/pagination/pagination.html", []).run(["$templateCache", function($templateCache) {
$templateCache.put("template/pagination/pagination.html",
	"<ul class=\"pagination\">\n" +
	"  <li ng-repeat=\"page in pages\" ng-class=\"{active: page.active, disabled: page.disabled}\"> \n" +
	"    <a href ng-click=\"selectPage(page.number)\">{{page.text}}</a> \n" +
	"  </li>\n" +
	"</ul>"
);
}]);
*/