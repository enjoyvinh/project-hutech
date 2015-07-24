'use strict';

var modalTest = angular.module('modalTest',['commonModule','paragonApp','ui.bootstrap','ui.sortable','dialogs.main']);

modalTest.controller('dialogServiceTest',function($scope, $rootScope,$window, $timeout, dialogs){

		//-- Variables --//
		//$scope.lang = 'en-US';
		//$scope.language = 'English';

		var _progress = 33;

		$scope.name = '';
		$scope.confirmed = 'No confirmation yet!';

		$scope.custom = {
			val: 'Initial Value'
		};

		$scope.deleteModal = {
			id : "deleteModal",
			title : 'Model Tilte',
			body : 'Do you want to delete dan cn cnd d d d d d d d d d d d d d d d d d d d d d d d d d d d a a a a a a a a a a a a aa  ?',
			buttonName: "削除",
			ok : function(){
				//$scope.deleteCard();
			    // add loading when click OK
				$window.alert("削除 OK");
			}
		};

		//-- Listeners & Watchers --//

/*		$scope.$watch('lang',function(val,old){
			switch(val){
				case 'en-US':
					$scope.language = 'English';
					break;
				case 'es':
					$scope.language = 'Spanish';
					break;
			}
		});
*/
		//-- Methods --//

/*		$scope.setLanguage = function(lang){
			$scope.lang = lang;
			$translate.use(lang);
		};*/

		$scope.launch = function(which){
			switch(which){
				case 'error':
					dialogs.error();
					break;
				case 'wait':
					var dlg = dialogs.wait(undefined,undefined,_progress);
					_fakeWaitProgress();
					break;
				case 'notify':
					dialogs.notify();
					break;
				case 'confirm':
					var dlg = dialogs.confirm();
					dlg.result.then(function(btn){
						$scope.confirmed = 'You confirmed "Yes."';
					},function(btn){
						$scope.confirmed = 'You confirmed "No."';
					});
					break;
				case 'custom':
					var dlg = dialogs.create('custom','customDialogCtrl',{},'sm');
					dlg.result.then(function(name){
						$scope.name = name;
					},function(){
						if(angular.equals($scope.name,''))
							$scope.name = 'You did not enter in your name!';
					});
					break;
				case 'custom2':
					var dlg = dialogs.create('/dialogs/custom2.html','customDialogCtrl2',$scope.custom,'sm');
					break;
			}
		}; // end launch

		var _fakeWaitProgress = function(){
			$timeout(function(){
				if(_progress < 100){
					_progress += 33;
					$rootScope.$broadcast('dialogs.wait.progress',{'progress' : _progress});
					_fakeWaitProgress();
				}else{
					$rootScope.$broadcast('dialogs.wait.complete');
				}
			},1000);
		};
	}) // end controller(dialogsServiceTest)

	.controller('customDialogCtrl',function($scope,$modalInstance,data){
		//-- Variables --//
		$scope.user = {name : ''};
		//-- Methods --//
		$scope.cancel = function(){
			$modalInstance.dismiss('Canceled');
		}; // end cancel
		$scope.save = function(){
			$modalInstance.close($scope.user.name);
		}; // end save
		$scope.hitEnter = function(evt){
			if(angular.equals(evt.keyCode,13) && !(angular.equals($scope.user.name,null) || angular.equals($scope.user.name,'')))
				$scope.save();
		};
		$scope.no = function(){
			$modalInstance.dismiss('no');
		}; // end close
	}) // end controller(customDialogCtrl)

	.controller('customDialogCtrl2',function($scope,$modalInstance,data){
		$scope.data = data;
		//-- Methods --//
		$scope.done = function(){
			$modalInstance.close($scope.data);
		}; // end done
		$scope.no = function(){
			$modalInstance.dismiss('no');
		}; // end close
	})

	.config(['dialogsProvider'/*,'$translateProvider'*/,function(dialogsProvider/*,$translateProvider*/){
		dialogsProvider.useBackdrop('static');
		dialogsProvider.useEscClose(false);
		dialogsProvider.useCopy(false);
		//dialogsProvider.setSize('lg');

/*		$translateProvider.translations('es',{
			DIALOGS_ERROR: "Error",
			DIALOGS_ERROR_MSG: "Se ha producido un error desconocido.",
			DIALOGS_CLOSE: "Cerca",
			DIALOGS_PLEASE_WAIT: "Espere por favor",
			DIALOGS_PLEASE_WAIT_ELIPS: "Espere por favor...",
			DIALOGS_PLEASE_WAIT_MSG: "Esperando en la operacion para completar.",
			DIALOGS_PERCENT_COMPLETE: "% Completado",
			DIALOGS_NOTIFICATION: "Notificacion",
			DIALOGS_NOTIFICATION_MSG: "Notificacion de aplicacion Desconocido.",
			DIALOGS_CONFIRMATION: "Confirmacion",
			DIALOGS_CONFIRMATION_MSG: "Se requiere confirmacion.",
			DIALOGS_OK: "Bueno",
			DIALOGS_YES: "Si",
			DIALOGS_NO: "No"
		});

		$translateProvider.preferredLanguage('en-US');*/
	}])

	.run(['$templateCache',function($templateCache){
		$templateCache.put('/dialogs/custom.html','<div class="modal-header"><button type="button" class="close" ng-click="no()">&times;</button><h4 class="modal-title"><span class="glyphicon glyphicon-star"></span> User\'s Name</h4></div><div class="modal-body"><ng-form name="nameDialog" novalidate role="form"><div class="form-group input-group-lg" ng-class="{true: \'has-error\'}[nameDialog.username.$dirty && nameDialog.username.$invalid]"><label class="control-label" for="course">Name:</label><input type="text" class="form-control" name="username" id="username" ng-model="user.name" ng-keyup="hitEnter($event)" required><span class="help-block">Enter your full name, first &amp; last.</span></div></ng-form></div><div class="modal-footer"><button type="button" class="btn btn-default" ng-click="cancel()">Cancel</button><button type="button" class="btn btn-primary" ng-click="save()" ng-disabled="(nameDialog.$dirty && nameDialog.$invalid) || nameDialog.$pristine">Save</button></div>');
		$templateCache.put('/dialogs/custom2.html','<div class="modal-header"><button type="button" class="close" ng-click="no()">&times;</button><h4 class="modal-title"><span class="glyphicon glyphicon-star"></span> Custom Dialog 2</h4></div><div class="modal-body"><label class="control-label" for="customValue">Custom Value:</label><input type="text" class="form-control" id="customValue" ng-model="data.val" ng-keyup="hitEnter($event)"><span class="help-block">Using "dialogsProvider.useCopy(false)" in your applications config function will allow data passed to a custom dialog to retain its two-way binding with the scope of the calling controller.</span></div><div class="modal-footer"><button type="button" class="btn btn-default" ng-click="done()">Done</button></div>');
	}]);


modalTest.controller('sortableController', function($scope) {

	$scope.listsA = [{
		code : '1',
		title : 'Test List A-1',
		link : 'http://www.facebook.com'
	}, {
		code : '2',
		title : 'Test List A-2',
		link : 'http://www.youtube.com'
	}, {
		code : '3',
		title : 'Test List A-3',
		link : 'http://www.gmail.com'
	}, {
		code : '4',
		title : 'Test List A-4',
		link : 'http://plus.google.com'
	}, {
		code : '5',
		title : 'Test List A-5',
		link : 'http://www.twitter.com'
	}, {
		code : '6',
		title : 'Test List A-6',
		link : 'http://mail.yahoo.com'
	}, {
		code : '7',
		title : 'Test List A-7',
		link : 'http://www.pinterest.com'
	} ];

	$scope.listsB = [ {
		code : '1',
		title : 'Test List B-1',
		link : 'http://www.facebook.com'
	}, {
		code : '2',
		title : 'Test List B-2',
		link : 'http://www.youtube.com'
	}, {
		code : '3',
		title : 'Test List B-3',
		link : 'http://www.gmail.com'
	}, {
		code : '4',
		title : 'Test List B-4',
		link : 'http://plus.google.com'
	}, {
		code : '5',
		title : 'Test List B-5',
		link : 'http://www.twitter.com'
	}, {
		code : '6',
		title : 'Test List B-6',
		link : 'http://mail.yahoo.com'
	}, {
		code : '7',
		title : 'Test List B-7',
		link : 'http://www.pinterest.com'
	} ];

	$scope.sortingLog = [];

	function createOptions(listName) {
		var _listName = listName;
		var options = {
			placeholder : "app",
			connectWith : ".apps-container",
			activate : function() {
				console.log("list " + _listName + ": activate");
			},
			beforeStop : function() {
				console.log("list " + _listName + ": beforeStop");
			},
			change : function() {
				console.log("list " + _listName + ": change");
			},
			create : function() {
				console.log("list " + _listName + ": create");
			},
			deactivate : function() {
				console.log("list " + _listName + ": deactivate");
			},
			out : function() {
				console.log("list " + _listName + ": out");
			},
			over : function() {
				console.log("list " + _listName + ": over");
			},
			receive : function() {
				console.log("list " + _listName + ": receive");
			},
			remove : function() {
				console.log("list " + _listName + ": remove");
			},
			sort : function() {
				console.log("list " + _listName + ": sort");
			},
			start : function() {
				console.log("list " + _listName + ": start");
			},
			stop : function() {
				console.log("list " + _listName + ": stop");
			},
			update : function() {
				console.log("list " + _listName + ": update");
			}
		};
		return options;
	}

	$scope.sortableOptionsList = [ createOptions('A'), createOptions('B') ];

/*	$scope.logModels = function() {
		$scope.sortingLog = [];
		for (var i = 0; i < $scope.rawScreens.length; i++) {
			var logEntry = $scope.rawScreens[i].map(function(x) {
				return x.title;
			}).join(', ');
			logEntry = 'container ' + (i + 1) + ': ' + logEntry;
			$scope.sortingLog.push(logEntry);
		}
	};*/
});


modalTest.service('rssFeedList', function($q, $rootScope, $timeout) {
    this.get = function(url) {
        var d = $q.defer();
        $timeout(function(result) { // simulate AJAX call
            var result = { // override result for demo
                feedList: [
                    'http://feeds.feedburner.com/TEDTalks_video',
                    'http://feeds.nationalgeographic.com/ng/photography/photo-of-the-day/',
                    'http://sfbay.craigslist.org/eng/index.rss',
                    'http://www.slate.com/blogs/trending.fulltext.all.10.rss',
                    'http://feeds.current.com/homepage/en_US.rss',
                    'http://feeds.current.com/items/popular.rss',
                    'http://www.nytimes.com/services/xml/rss/nyt/HomePage.xml'
                ]
            };
            $rootScope.$apply(d.resolve(result));
        }, 2000);
        return d.promise;
    };
});


modalTest.controller('loading', function($scope, rssFeedList){

    $scope.setLoading = function(loading) {
        console.log("loading :" + loading);
        $scope.isLoading = loading;
    };

    $scope.loadFeed = function(url) {
        $scope.setLoading(true);
        rssFeedList.get(url).then(function(result) {
            if (result.error) {
                alert("ERROR " + result.error.code + ": " + result.error.message + "\nurl: " + url);
                $scope.setLoading(false);
            } else {
                $scope.feedList = result.feedList;
                $scope.setLoading(false);
                if ($scope.feedList.length == 0) {
                    $scope.setLoading(false);
                }
            }
        });
    };
    //$scope.loadFeed();
});

modalTest.config(['$tooltipProvider', function($tooltipProvider){
    $tooltipProvider.setTriggers({
        'mouseenter': 'mouseleave',
        'click': 'click',
        'focus': 'blur',
        'never': 'mouseleave' // <- This ensures the tooltip will go away on mouseleave
      });
    }]);

modalTest.controller('testSubmitValidated', function($scope){
    $scope.submitForm = function(){
        $scope.submitted = true;
    };
});