/**
* Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */
/**
 *
 * @version $Revision: 1.0 $  $Date: 2014/05/30 $
 * @author : Quang-Thien
 */

'use strict';

var paragonApp = angular.module('paragonApp', ['ui.bootstrap.pagination']);

var holidays = {

  };

paragonApp.directive('showErrors', function($timeout) {
    return {
      restrict: 'A',
      require: '^form',
      link: function (scope, el, attrs, formCtrl) {
        // find the text box element, which has the 'name' attribute
        var inputEl   = el[0].querySelector("[name]");
        // convert the native text box element to an angular element
        var inputNgEl = angular.element(inputEl);
        // get the name on the text box
        var inputName = inputNgEl.attr('name');
        
        // only apply the has-error class after the user leaves the text box
        var blurred = false;
        inputNgEl.bind('blur', function() {
          blurred = true;
          el.toggleClass('has-error', formCtrl[inputName].$invalid);
        });
        
        scope.$watch(function() {
          return formCtrl[inputName].$invalid
        }, function(invalid) {
          // we only want to toggle the has-error class after the blur
          // event or if the control becomes valid
          if (!blurred && invalid) { return }
          el.toggleClass('has-error', invalid);
        });
        
        scope.$on('show-errors-check-validity', function() {
          el.toggleClass('has-error', formCtrl[inputName].$invalid);
        });
        
        scope.$on('show-errors-reset', function() {
          $timeout(function() {
            el.removeClass('has-error');
          }, 0, false);
        });
      }
    }
});

paragonApp.directive( 'modal', function(){
  return {
    restrict: 'EA',
    transclude:true,
    scope: {
      id: '=',
      modalbase: '=',
      modalobject: '='
    },
    templateUrl : 'modalDialog'
  };
} );

paragonApp.directive('loading', function(){
  return {
    restrict: 'E',
    scope: true,
    transclude: true,
//    template: '<div id="bg-loading" ng-show="isLoading"></div> \n' +
//    ' <div ng-show="isLoading" style="position: fixed; left: 50%; top: 35%; font-size: 20px; width: 400px; margin-left: -200px;z-index:99999"> \n'+
//    '  <div class="alert alert-info"> \n'+
//    '  <i class="glyphicon glyphicon-refresh glyphicon-refresh-animate"></i></div> \n' +
//    ' </div>'
    template: '<div id="bg-loading" ng-show="isLoading"></div> \n' +
        ' <div ng-show="isLoading" style="position: fixed; left: 50%; top: 35%; font-size: 20px; width: 400px; margin-left: -200px;z-index:99999; background-color:transparent;"> \n'+
        '  <div class="alert alert-info"> \n'+
        //'  <i class="glyphicon glyphicon-refresh glyphicon-refresh-animate"></i>Đang tải dữ liệu...</div> \n' +
        '  Đang tải dữ liệu...</div> \n' +
        ' </div>'
  };
});

paragonApp.directive('chosenSelect', function() {
  var linker = function(scope, element, attrs) {

    var dropPosition = attrs.dropposition;
    //var classChosen = attrs.classChosen;

    var width = attrs.chosenWidth;
    var list = attrs['chosenSelect'];
    if (angular.isDefined(attrs.list) && attrs.list !== null) {
      scope.$watch(attrs.list, function() {
        $(element).trigger('liszt:updated');
        $(element).trigger('chosen:updated');
      });
    }
    if (angular.isDefined(list) && list !== null) {
      scope.$watch(list, function() {
        $(element).trigger('liszt:updated');
        $(element).trigger('chosen:updated');
      });
    }
    scope.$watch(attrs['ngModel'], function() {
      $(element).trigger('chosen:updated');
    });
    var isDisabled = attrs['ngDisabled'];
    if (angular.isDefined(isDisabled) && isDisabled !== null) {
      scope.$watch(isDisabled, function(newValue) {
        $(element).prop('disabled', newValue);
        $(element).trigger('liszt:updated');
        $(element).trigger('chosen:updated');
      });
    }
    scope.$watch(attrs['ngModel'], function() {
      $(element).trigger('chosen:updated');
    });
    width = (width == null || width == '' || width === undefined) ? '100%' : width;

    var muiltiDropdow = attrs.muiltiDropdow;
    if (muiltiDropdow == null || muiltiDropdow === '' || muiltiDropdow === 'true' || muiltiDropdow == true) {
      muiltiDropdow = true;
    } else if (muiltiDropdow === 'false' || muiltiDropdow == false) {
      muiltiDropdow = false;
    } else {
      muiltiDropdow = true;
    }

    var maxSelected = attrs.maxSelected;
    maxSelected = (maxSelected == null || maxSelected == '' || maxSelected === undefined) ? 10 : maxSelected;

    $(element).chosen({
      "width" : width,
      "dropPosition" : dropPosition,
      //"classChosen" : classChosen,
      disable_search_threshold : 0,
      muilti_dropdow : muiltiDropdow,
      max_selected_options : maxSelected
    });
    var deselect = attrs.chosenDeselect;
    if (deselect == null || deselect === '' || deselect === 'true' || deselect == true) {
      deselect = true;
    } else if (deselect === 'false' || deselect == false) {
      deselect = false;
    } else {
      deselect = true;
    }
    element.data('chosen').allow_single_deselect = deselect;
  };

  return {
    restrict : 'A',
    link : linker
  };
});

// TODO this will replace chosenSelect
paragonApp.directive('magicSuggest', function($rootScope, $window){
  return {
    restrict: 'EA',
    priority : 10,
    terminal : false,
    scope: {
      ngModel: '=',
      ngModelMaster: '=',
      displayField: '=',
      valueField: '=',
      placeholder: '@',
      hideTrigger: '=',
      allowFreeEntries: '=',
      maxSelection : '=',
      maxSuggestions: '=',
      magicWidth : '=',
      //magicFunction : '=',
      selectionOnchange : '=',
      currentIndex : '=',
      required : '=',
      broadcastLoading :'=',
      functionBroadcastLoading :'=',
      name:'@'},
    template: '<div class="error"></div>',
    replace: true,
    transclude: true,
    controller : function($scope, $element, $attrs, $window, $rootScope) {
      $scope.init = function() {
//          $scope.$on('CrmRefer#editCustomer1', function(ev, arg) {
//              console.log(arg);
        //console.log($scope.ngModel);
        //console.log($scope.ngModelMaster);
        if($scope.broadcastLoading == true || $scope.broadcastLoading == undefined ){
          var width = ($scope.magicWidth == null || $scope.magicWidth == '' || $scope.magicWidth === undefined) ? 'auto' : $scope.magicWidth;
          var ms = $element.magicSuggest({
            data : $scope.ngModelMaster,
            cls : 'suggest-default',
            style: 'min-height: 30px !important;',
            displayField : $scope.displayField,
            valueField : $scope.valueField,
            name: $scope.name,
            sortDir : 'desc',
            highlight : false,
            width : width,
            maxDropHeight: 174,
            //allowFreeEntries : false,
            allowFreeEntries : $scope.allowFreeEntries,
            preselectSingleSuggestion : false,
            resultAsString : false,
            //required : false,
            required : $scope.required,
            typeDelay : 0,
            maxSelection : $scope.maxSelection,
            maxSuggestions: $scope.maxSuggestions,
            // hideTrigger default false
            hideTrigger : $scope.hideTrigger,
            suggestField1 : 'name11',
            //value : selectValOfReport,
            value: $scope.ngModel,
            //value: ["001","002"],
            maxSelectionRenderer : function(a) {
              return '';
            },
            emptyText : $scope.placeholder
          });

          $(ms).on('selectionchange', function (event, combo, selection) {
            //if(this.getValue() != null && this.getValue() != ''){
              var code = this.getValue();
              $rootScope.$apply(
                $rootScope.$broadcast($scope.selectionOnchange, $scope.currentIndex, code)
              );
              //$rootScope.$broadcast('cloneItem');
              //$scope.datas.items.push($scope.datas.items[0]);
            //}
          });
        }
//              });
      };
      $scope.init();
    },
    //require: 'ngModel',
    link: function ($scope, element, attrs,ngModel) {
      //console.log($scope.ngModel);
      //console.log($scope.ngModelMaster);

      var width = ($scope.magicWidth == null || $scope.magicWidth == '' || $scope.magicWidth === undefined) ? 'auto' : $scope.magicWidth;
      $scope.$on($scope.functionBroadcastLoading, function(ev, arg) {
        var ms = element.magicSuggest({
          data : $scope.ngModelMaster,
          cls : 'suggest-default',
          style: 'min-height: 30px !important;',
          displayField : $scope.displayField,
          valueField : $scope.valueField,
          name: $scope.name,
          sortDir : 'desc',
          highlight : false,
          width : width,
          maxDropHeight: 174,
          //allowFreeEntries : false,
          allowFreeEntries : $scope.allowFreeEntries,
          preselectSingleSuggestion : false,
          resultAsString : false,
          //required : false,
          required : $scope.required,
          typeDelay : 0,
          maxSelection : $scope.maxSelection,
          maxSuggestions: $scope.maxSuggestions,
          // hideTrigger default false
          hideTrigger : $scope.hideTrigger,
          suggestField1 : 'name11',
          //value : selectValOfReport,
          value: $scope.ngModel,
          //value: ["001","002"],
          maxSelectionRenderer : function(a) {
            return '';
          },
          emptyText : $scope.placeholder
        });

        $(ms).on('selectionchange', function (event, combo, selection) {
            var code = this.getValue();
            $rootScope.$apply(
              $rootScope.$broadcast($scope.selectionOnchange, $scope.currentIndex, code)
            );
        });
      });
    }
  };
});

/*paragonApp.controller('holidayCtrl', function($scope){
  $http.get('data/ja/holidays.json').success(function(data) {
    $scope.holidays = data;
    console.log(data);
  });
});*/

paragonApp.directive('exexDateTimePicker', function(){
//    var linker = function(scope, element, attrs) {
//        element.datetimepicker({
//            language : 'ja',
//            todayBtn : true,
//            autoclose : true,
//            todayHighlight : true,
//            startView : 2,
//            forceParse : 0,
//            calendarWeeks : true,
//            showMeridian : true,
//            weekStart : 0,
//            daysHoliday : holidays,
//            format : 'yyyy/mm/dd - HH:ii p',
//            dataNgModel : scope.dataNgModel
//        });
//    };
  return {
      restrict : 'EA',
      replace: true,
      transclude: true,
      scope : {
        dateId : '@',
        dateClass : '@',
        dateType : '=',
        dateValue : '=',
        dateMinValue : '=',
        dateMaxValue : '=',
        dateMaxLength : '=',
        dateValidation : '=',
        dateTimeFormat : '@',
        width : '@'
      },
      template : '<div class="input-group date form_datetime {{width}}"> \n' +
          '  <input class="form-control {{dateClass}}" type="text" ng-model="dateValue" ' +
            'id={{dateId}} name={{dateId}} maxlength="{{dateMaxLength}}"> \n' +
          '  <span class="input-group-addon"> \n'+
          '    <span class="glyphicon glyphicon-th"></span> \n'+
          '  </span> \n' +
          '</div>',
      //link : linker
      link : function(scope, element, attrs) {
        element.datetimepicker({
          language : 'ja',
          todayBtn : true,
          autoclose : true,
          todayHighlight : true,
          startView : 2,
          forceParse : 0,
          calendarWeeks : true,
          showMeridian : true,
          weekStart : 0,
          daysHoliday : holidays,
          format : attrs.dateTimeFormat
        });
      }
  };
});



paragonApp.directive('exexDatePicker', function(){
  return {
      restrict : 'EA',
      replace: true,
      transclude: true,
      scope : {
        dateid : '@',
        dateType : '=',
        dateValue : '=',
        dateMinValue : '=',
        dateMaxValue : '=',
        dateValidation : '=',
        dateFormat : '@',
        width : '@'
      },
      template :'<div class="input-group date form_date {{width}}" "> \n' +
          '  <input class="form-control yyyy_mm_dd" type="text" sms-date-format ' +
          '      ng-model="dateValue" id={{dateid}} name={{dateid}}> \n' +
          '  <span class="input-group-addon"> \n'+
          '      <span class="glyphicon glyphicon-calendar"></span> \n'+
          '  </span> \n' +
          '</div>',
      //link : linker
      link : function(scope, element, attrs) {
        if(attrs.dateFormat == undefined || attrs.dateFormat == ''){
          attrs.dateFormat = 'yyyy/mm/dd';
        }
        element.datetimepicker({
          language : 'ja',
          weekStart : 0,
          todayBtn : 1,
          autoclose : 1,
          todayHighlight : 1,
          startView : 2,
          calendarWeeks : true,
          minView : 2,
          forceParse : 0,
          showMeridian : true,
          daysHoliday : holidays,
          format : attrs.dateFormat
        });
      }
  };
});


paragonApp.directive('exexMonthPicker', function(){
  return {
      restrict : 'EA',
      replace: true,
      transclude: true,
      scope : {
        dateid : '@',
        dateType : '=',
        dateValue : '=',
        dateMinValue : '=',
        dateMaxValue : '=',
        dateValidation : '=',
        dateFormat : '@',
        width : '@'
      },
      template :'<div class="input-group date form_date {{width}}" "> \n' +
          '  <input class="form-control yyyy_mm_dd" type="text" sms-date-format ' +
          '      ng-model="dateValue" id={{dateid}} name={{dateid}}> \n' +
          '  <span class="input-group-addon"> \n'+
          '      <span class="glyphicon glyphicon-calendar"></span> \n'+
          '  </span> \n' +
          '</div>',
      //link : linker
      link : function(scope, element, attrs) {
        if(attrs.dateFormat == undefined || attrs.dateFormat == ''){
          attrs.dateFormat = 'yyyy/mm/dd';
        }
        element.datetimepicker({
          language : 'ja',
          weekStart : 0,
          todayBtn : 1,
          autoclose : 1,
          todayHighlight : 1,
          startView : 3,
          calendarWeeks : true,
          minView : 3,
          forceParse : 0,
          showMeridian : true,
          daysHoliday : holidays,
          format : attrs.dateFormat
        });
      }
  };
});


paragonApp.directive('exexTimePicker', function(){
  return {
      restrict : 'EA',
      replace: true,
      transclude: true,
      scope : {
        timeId : '@',
        timeType : '=',
        timeValue : '=',
        timeMinValue : '=',
        timeMaxValue : '=',
        timeValidation : '=',
        timeFormat : '@',
        width : '@'
      },
      template : '<div class="input-group date form_time {{width}}"> \n' +
          '  <input class="form-control ds" type="text" ng-model="timeValue"> \n' +
          '  <span class="input-group-addon"> \n'+
          '    <span class="glyphicon glyphicon-time"></span> \n'+
          '  </span> \n' +
          '</div>',
      //link : linker
      link : function(scope, element, attrs) {
        //console.log(attrs.widthT);
        element.datetimepicker({
          language : 'ja',
          weekStart : 0,
          todayBtn : 1,
          autoclose : 1,
          todayHighlight : 1,
          startView : 1,
          minView : 0,
          maxView : 1,
          forceParse : 0,
          format : attrs.timeFormat
        });
      }
  };
});

paragonApp.directive("inputDisabled", function(){
  return function(scope, element, attrs){
    scope.$watch(attrs.inputDisabled, function(val){
      if(val){
        element.removeAttr("disabled");
      }else{
        element.attr("disabled", "disabled");
      }
  });
  };
});

paragonApp.directive("inputReadonly", function(){
  return function(scope, element, attrs){
    scope.$watch(attrs.inputReadonly, function(val){
      if(val){
        element.removeAttr("readonly");
      }else{
        element.attr("readonly", "readonly");
      }
  });
  };
});

paragonApp.directive('smsDateFormat', function ($filter)  {
  return {
    require: 'ngModel',
    restrict: 'A',
    scope: { ngModel: '=' },
    link: function (scope, element, attrs, ngModel) {
//            var fromUser = function (data) {
//                var date = new Date(data);
//                $(element).formance('format_yyyy_mm_dd');
//                return $filter('date')(data, 'yyyy/MM/dd');
//            };
//            var toUser = function (data) {
//                if (data === '0001-01-01') {
//                    return '';
//
//                }else {
//                    $(element).formance('format_yyyy_mm_dd');
//                    return $filter('date')(data, 'yyyy/MM/dd');
//                }
//            };
      ngModel.$parsers.push(function (viewValue){
        $(element).formance('format_yyyy_mm_dd');
      return $filter('date')(viewValue, 'yyyy/MM/dd');
      });
      ngModel.$formatters.push(function (modelValue){
        return $filter('date')(modelValue, 'yyyy/MM/dd');
      });
    }
  };
});

paragonApp.directive('smsDateTimeFormat', function ($filter) {
  return {
    require: 'ngModel',
    restrict: 'A',
    scope: { ngModel: '=' },
    link: function (scope, element, attrs, ngModel) {
      var fromUser = function (data) {
        var date = new Date(data);
        return $filter('date')(date, 'yyyy/MM/dd HH:mm:ss');
      };
      var toUser = function (data) {
        if (data === '0001-01-01') {
          return '';
        }else {
          return $filter('date')(data, 'yyyy/MM/dd HH:mm:ss');
        }
      };
      ngModel.$parsers.push(fromUser);
      ngModel.$formatters.unshift(toUser);
    }
  };
});

paragonApp.filter('startFrom', function() {
  return function(input, start) {
    if(input) {
      start = +start; //parse to int
      return input.slice(start);
    }
    return [];
  };
});

paragonApp.filter('tel', function () {
  return function (tel) {
    if (!tel) {
      return '';
    }
    if(!ValidateUtil.isValidTextEmpty(tel)){
      var value = tel.toString().trim().replace(/^\+/, '');

      if (value.match(/[^0-9-]/)) {
        return tel;
      }
      var number;
      switch (value.length) {
        case 7: // ####### ->###-####
          number = value.slice(0, 3) + '-' + value.slice(3);
          break;
        case 10: // ########## ->###-###-####
          number = value.slice(0, 3) + '-' + value.slice(3,6) + '-' + value.slice(6);
          break;
        case 13: // ############# ->#####-####-####
          number = value.slice(0, 5) + '-' + value.slice(5,9) + '-' + value.slice(9);
          break;
        case 15: // ######-####-#### ->#####-####-####
          number = value;
          break;
        default:
          return tel;
      }
      return "TEL :" + number.trim();
    }
  };
});

paragonApp.filter('fax', function () {
  return function (tel) {
    if (!tel) {
      return '';
    }
    if(!ValidateUtil.isValidTextEmpty(tel)){
      var value = tel.toString().trim().replace(/^\+/, '');

      if (value.match(/[^0-9-]/)) {
        return tel;
      }
      var number;
      switch (value.length) {
        case 7: // ####### ->###-####
          number = value.slice(0, 3) + '-' + value.slice(3);
          break;
        case 10: // ########## ->###-###-####
          number = value.slice(0, 3) + '-' + value.slice(3,6) + '-' + value.slice(6);
          break;
        case 13: // ############# ->#####-####-####
          number = value.slice(0, 5) + '-' + value.slice(5,9) + '-' + value.slice(9);
          break;
        case 15: // ######-####-#### ->#####-####-####
          number = value;
          break;
        default:
          return number = tel;
      }
      return "FAX :" + number.trim();
    }
  };
});

paragonApp.filter('post', function () {
  return function (tel) {
    if (!tel) {
      return '';
    }
    if(!ValidateUtil.isValidTextEmpty(tel)){
      var value = tel.toString().trim().replace(/^\+/, '');

      if (value.match(/[^0-9-]/)) {
        return tel;
      }
      var number;
      switch (value.length) {
        case 7: // ####### ->###-####
          number = value.slice(0, 3) + '-' + value.slice(3);
          break;
        case 10: // ########## ->###-###-####
          number = value.slice(0, 3) + '-' + value.slice(3,6) + '-' + value.slice(6);
          break;
        case 13: // ############# ->#####-####-####
          number = value.slice(0, 5) + '-' + value.slice(5,9) + '-' + value.slice(9);
          break;
        default:
          return number = tel;
      }
      return "〒 " + number.trim();
    }
  };
});

paragonApp.filter('htmlEscape', function() {
  return function(input) {
    if (!input) {
      return '';
    }
    return input.
      replace(/&amp;/g, '&').
      replace(/&lt;/g, '<').
      replace(/&gt;/g, '>')
    ;
  };
});

paragonApp.filter('textToHtml', ['$sce', 'htmlEscapeFilter', function($sce, htmlEscapeFilter) {
  return function(input) {
    if (!input) {
      return '';
    }
    input = htmlEscapeFilter(input);

    var output = '';
    $.each(input.split("\n\n"), function(key, paragraph) {
      output += '<p>' + paragraph + '</p>';
    });

    return $sce.trustAsHtml(output);
  };
}]);

paragonApp.filter('currency', function () {
  return function (currency) {
    if(!ValidateUtil.isValidTextEmpty(currency)){
      return currency + "　VNĐ";
    }else {
      return currency;
    }
  };
});

paragonApp.filter("skyfireCurrency", function (numberFilter){
  function isNumeric(value){
  return (!isNaN(parseFloat(value)) && isFinite(value));
  }

  return function (inputNumber, currencySymbol, decimalSeparator, thousandsSeparator, decimalDigits) {
    if (isNumeric(inputNumber)){
      // Default values for the optional arguments
      currencySymbol = (typeof currencySymbol === "undefined") ? "" : currencySymbol;
      decimalSeparator = (typeof decimalSeparator === "undefined") ? "." : decimalSeparator;
      thousandsSeparator = (typeof thousandsSeparator === "undefined") ? "," : thousandsSeparator;
      decimalDigits = (typeof decimalDigits === "undefined" || !isNumeric(decimalDigits)) ? 0 : decimalDigits;

      if (decimalDigits < 0){
        decimalDigits = 0;
      }

      // Format the input number through the number filter
      // The resulting number will have "," as a thousands separator
      // and "." as a decimal separator.
      var formattedNumber = numberFilter(inputNumber, decimalDigits);

      // Extract the integral and the decimal parts
      var numberParts = formattedNumber.split(".");

      // Replace the "," symbol in the integral part
      // with the specified thousands separator.
      numberParts[0] = numberParts[0].split(",").join(thousandsSeparator);

      // Compose the final result
      var result = numberParts[0] + " " + currencySymbol;

      if (numberParts.length == 2) {
      result += decimalSeparator + numberParts[1];
      }

      return result + " VNĐ";
    } else {
      return inputNumber + " VNĐ";
    }
  };
});

paragonApp.filter('person', function () {
  return function (person) {
    console.log(person);
    if(!ValidateUtil.isValidTextEmpty(person)){
      return person + "　名";
    }else {
      return person;
    }
  };
});

paragonApp.directive("colSort", function() {
  return {
    restrict: 'A',
    transclude: true,
    template: '<a href="" ng-click="sortBy()">' +
        '   <span ng-transclude></span>' +
        //'   <i class="glyphicon" ng-class="{\'glyphicon-sort-by-alphabet\' : predicate === by && !reverse,  \'glyphicon-sort-by-alphabet-alt\' : predicate===by && reverse}"></i>' +
        '   <i class="glyphicon" ng-class="selectedColumn();"></i>' +
        '</a>',
    scope: {
      predicate: '=',
      by: '=',
      reverse: '='
    },
    link: function(scope, element, attrs) {
      scope.sortBy = function() {
        /*scope.predicate = predicate;
        scope.reverse = !scope.reverse;*/
        if (scope.predicate === scope.by) {
          scope.reverse = !scope.reverse;
        } else {
          scope.by = scope.predicate;
          scope.reverse = false;
        }
      };
      scope.selectedColumn = function() {
        /*if (scope.predicate === predicate && !scope.reverse) {
          return 'glyphicon-sort-by-alphabet';
        } else {
          return 'glyphicon-sort-by-alphabet-alt';
        }*/
        if (scope.predicate === scope.by) {
          //return ('icon-chevron-' + ((scope.sort.reverse) ? 'down' : 'up'));
          return ('glyphicon glyphicon-sort-by-' + ((scope.reverse) ? 'alphabet' : 'alphabet-alt'));
        } else {
          return 'glyphicon glyphicon-sort';
        }
      };
    }
  };
});

paragonApp.directive('autoFocus', function($timeout, $parse) {
  return {
    link: function(scope, element, attrs) {
      var model = $parse(attrs.autoFocus);
      scope.$watch(model, function(value) {
        //console.log('value=',value);
        if(value === true) {
          $timeout(function() {
            element[0].focus();
          });
        }
      });
    }
  };
});

paragonApp.directive('format', ['$filter', function ($filter) {
  return {
    require: '?ngModel',
    link: function (scope, elem, attrs, ctrl) {
      if (!ctrl) return;
      ctrl.$formatters.unshift(function (a) {
        var value = $filter(attrs.format)(ctrl.$modelValue);
        if(value == 0){
          return '';
        }
        return value;
      });
      ctrl.$parsers.unshift(function (viewValue) {
        var plainNumber = viewValue.replace(/[^\d|\-+|\.+]/g, '');
        elem.val($filter('number')(plainNumber));
        return plainNumber;
      });
    }
  };
}]);

paragonApp.directive('numbersOnly', function () {
  return  {
    restrict: 'A',
    link: function (scope, elm, attrs, ctrl) {
      elm.on('keydown', function (event) {
        if(event.shiftKey){
          event.preventDefault();
          return false;
        }else if ([8, 9, 13, 27, 35, 36, 37, 38, 39, 40, 46].indexOf(event.which) > -1) {
          // backspace, enter, escape, arrows, home, end
          return true;
        } else if (event.which >= 48 && event.which <= 57) {
          // numbers
          return true;
        } else if (event.which >= 96 && event.which <= 105) {
          // numpad number
          return true;
        } else if ([110, 190].indexOf(event.which) > -1) {
          // dot and numpad dot
          return true;
        }else {
          event.preventDefault();
          return false;
        }
      });
    }
  };
});


paragonApp.directive('numChar', function () {
  return  {
    restrict: 'A',
    link: function (scope, elm, attrs, ctrl) {
      elm.on('keydown', function (event) {
        if(event.shiftKey & (event.which >= 49 && event.which <= 57)){
          // !@#$%&*()_+
          event.preventDefault();
          return false;
        }else if ([8, 9, 13, 27, 35, 36, 37, 38, 39, 40, 46].indexOf(event.which) > -1) {
          // backspace, enter, escape, arrows, home, end
          return true;
        } else if (event.which >= 49 && event.which <= 57) {
          // numbers
          return true;
        } else if (event.which >= 96 && event.which <= 105) {
          // numpad number
          return true;
        }else if(event.which >= 65 && event.which <= 91){
          // a-z, A-Z
          return true;
        }else {
          event.preventDefault();
          return false;
        }
      });
    }
  };
});

paragonApp.directive('exexNumeric', [function () {
  'use strict';
  // Declare a empty options object
  var options = {aPad : false};
  var strTmp = "";
  return {
    // Require ng-model in the element attribute for watching changes.
    require: '?ngModel',
    // This directive only works when used in element's attribute (e.g: cr-numeric)
    restrict: 'A',
    compile: function (tElm, tAttrs) {

      var isTextInput = tElm.is('input:text');

      return function (scope, elm, attrs, controller) {
        // Get instance-specific options.
        if(!ValidateUtil.isValidTextEmpty(attrs.maxlength)){
          var maxLength = parseInt(attrs.maxlength, 10);
          var vMax = strTmp.pad("9", maxLength);
          options.vMax = vMax;
        }

        if(!ValidateUtil.isValidTextEmpty(attrs.ngmaxlength)){
          var maxLength = parseInt(attrs.ngmaxlength, 10);
          var vMax = strTmp.pad("9", maxLength);
          options.vMax = vMax;
        }

        if(!ValidateUtil.isValidTextEmpty(attrs.min)){
          var minLength = parseInt(attrs.minLength, 10);
          var vMin = strTmp.pad("9", minLength);
          options.vMin = '-' + vMin;
        }

        var opts = angular.extend({}, options, scope.$eval(attrs.exexNumeric));

        // Helper method to update autoNumeric with new value.
        var updateElement = function (element, newVal) {
          // Only set value if value is numeric
          if ($.isNumeric(newVal))
            element.autoNumeric('set', newVal);
        };

        // Initialize element as autoNumeric with options.
        elm.autoNumeric(opts);

        // if element has controller, wire it (only for <input type="text" />)
        if (controller && isTextInput) {
          // watch for external changes to model and re-render element
          scope.$watch(tAttrs.ngModel, function (current, old) {
            controller.$render();
          });
          // render element as autoNumeric
          controller.$render = function () {
            updateElement(elm, controller.$viewValue);
          };
          // Detect changes on element and update model.
          elm.on('change', function (e) {
            scope.$apply(function () {
              controller.$setViewValue(elm.autoNumeric('get'));
            });
          });
        }
        else {
          // Listen for changes to value changes and re-render element.
          // Useful when binding to a readonly input field.
          if (isTextInput) {
            attrs.$observe('value', function (val) {
              updateElement(elm, val);
            });
          }
        }
      };
    } // compile
  }; // return
}]);


//paragonApp.directive('exexDaterange', ['$compile', '$parse', function ($compile, $parse) {
//
//  return {
//    restrict: 'EA',
//    require: 'ngModel',
//        template:   '<div class="input-daterange input-group width-360"> \n' +
//                    '  <span class="input-group-addon">From</span> \n' +
//                    '  <input ng-daterange ng-model="dates5" class="form-control" name="fromDate"/> \n' +
//                    '  <span class="input-group-addon daterange-none-border"> \n' +
//                    '    <span class="glyphicon glyphicon-calendar"></span> \n' +
//                    '  </span> \n' +
//                    '  <span class="input-group-addon daterange-none-border-lr">To</span> \n' +
//                    '  <input ng-daterange ng-model="dates5" class="form-control" name="toDate"/> \n' +
//                    '  <span class="input-group-addon"> \n' +
//                    '    <span class="glyphicon glyphicon-calendar"></span> \n' +
//                    '  </span> \n' +
//                    '</div>' ,

//        scope: {},
//        replace: true,
//        transclude : true,

//    link: function ($scope, $element, $attributes, ngModel) {
//      var options = {};
//      $scope.locale = {
//          applyLabel: '適用',
//          cancelLabel: 'キャンセル',
//          fromLabel: 'From',
//          toLabel: 'To',
//          weekLabel: '週',
//          customRangeLabel: 'Custom Range',
//          daysOfWeek: ["日", "月", "火", "水", "木", "金", "土"],
//          monthNames: ["1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"],
//          firstDay: 1
//        };
//      options.format = $attributes.format || 'YYYY/MM/DD';
//      options.separator = $attributes.separator || ' - ';
//      options.minDate = $attributes.minDate && moment($attributes.minDate);
//      options.maxDate = $attributes.maxDate && moment($attributes.maxDate);
//      options.dateLimit = $attributes.limit && moment.duration.apply(this, $attributes.limit.split(' ').map(function (elem, index) { return index === 0 && parseInt(elem, 10) || elem; }) );
//      options.ranges = $attributes.ranges && $parse($attributes.ranges)($scope);
//      //options.locale = $attributes.locale && $parse($attributes.locale)($scope);
//      options.locale = $scope.locale;
//      options.opens = $attributes.opens || 'right';
//      options.showWeekNumbers = $attributes.showWeekNumbers || false;
//
//      function format(date) {
//        return date.format(options.format);
//      }
//
//      function formatted(dates) {
//        return [format(dates.startDate), format(dates.endDate)].join(options.separator);
//      }
//
//      ngModel.$formatters.unshift(function (modelValue) {
//        if (!modelValue) return '';
//        return modelValue;
//      });
//
//      ngModel.$parsers.unshift(function (viewValue) {
//        return viewValue;
//      });
//
//      $scope.$watch($attributes.ngModel, function (modelValue) {
//        if (!modelValue || (!modelValue.startDate)) {
//          ngModel.$setViewValue({ startDate: moment().startOf('day').toDate(), endDate: moment().startOf('day').toDate() });
//          return;
//        }
//        $element.data('daterangepicker').startDate = moment(modelValue.startDate);
//        $element.data('daterangepicker').endDate = moment(modelValue.endDate);
//        $element.data('daterangepicker').updateView();
//        $element.data('daterangepicker').updateCalendars();
//        $element.data('daterangepicker').updateInputText();
//
//        var test = $element.data('daterangepicker').updateInputText1();
//        if(!ValidateUtil.isValidTextEmpty(test)){
//          var start = test.substring(0,10);
//          var end = test.substring(11,21);
//          $('input[name="fromDate"]').val(start);
//          $('input[name="toDate"]').val(end);
//        }
//
//      });
//
//      $element.daterangepicker(options, function(start, end) {
//        $scope.$apply(function () {
//          ngModel.$setViewValue({ startDate: start.toDate(), endDate: end.toDate() });
//        });
//      });
//    }
//  };
//}]);



paragonApp.directive("contenteditable", function($compile) {
  return {
    link : function(scope, element, attrs) {

      element.bind("focus", function() {
        scope.name = scope.name.replace(/</g, "&lt;").replace(/>/g,
            "&gt;");
        scope.$apply();
      });
      element.bind("blur", function() {
        scope.name = element[0].innerHTML.replace(/[&]lt[;]/g, "<")
            .replace(/[&]gt[;]/g, ">");
        scope.$apply();
      });
    }
  };
});

paragonApp.directive('ngBind', function(){
  return {
    compile: function(tElement, tAttrs) {
      tAttrs.ngBind = 'myBind(' + tAttrs.ngBind + ')';
      return {
        pre: function(scope) {
          scope.myBind = function(text) {
            return angular.element('<div>' + text + '</div>').text();
          }
        }
      };
    }
  }
});


/* Vinh Nguyễn Angularjs*/

paragonApp.directive('input', function ($compile, $parse) {
    return {
        restrict: 'E',
        require: '?ngModel',
        link: function ($scope, $element, $attributes, ngModel) {
            if ($attributes.type !== 'daterange' || ngModel === null ) return;

            var options = {};
            options.format = $attributes.format || 'YYYY-MM-DD';
            options.separator = $attributes.separator || ' - ';
            options.minDate = $attributes.minDate && moment($attributes.minDate);
            options.maxDate = $attributes.maxDate && moment($attributes.maxDate);
            options.dateLimit = $attributes.limit && moment.duration.apply(this, $attributes.limit.split(' ').map(function (elem, index) { return index === 0 && parseInt(elem, 10) || elem; }) );
            options.ranges = $attributes.ranges && $parse($attributes.ranges)($scope);
            options.locale = $attributes.locale && $parse($attributes.locale)($scope);
            options.opens = $attributes.opens && $parse($attributes.opens)($scope);

            function format(date) {
                return date.format(options.format);
            }

            function formatted(dates) {
                return [format(dates.startDate), format(dates.endDate)].join(options.separator);
            }

            ngModel.$formatters.unshift(function (modelValue) {
                if (!modelValue) return '';
                return modelValue;
            });

            ngModel.$parsers.unshift(function (viewValue) {
                return viewValue;
            });

            ngModel.$render = function () {
                if (!ngModel.$viewValue || !ngModel.$viewValue.startDate) return;
                $element.val(formatted(ngModel.$viewValue));
            };

            $scope.$watch($attributes.ngModel, function (modelValue) {
                if (!modelValue || (!modelValue.startDate)) {
                    ngModel.$setViewValue({ startDate: moment().startOf('day'), endDate: moment().startOf('day') });
                    return;
                }
                $element.data('daterangepicker').startDate = modelValue.startDate;
                $element.data('daterangepicker').endDate = modelValue.endDate;
                $element.data('daterangepicker').updateView();
                $element.data('daterangepicker').updateCalendars();
                $element.data('daterangepicker').updateInputText();
            });

            $element.daterangepicker(options, function(start, end) {
                $scope.$apply(function () {
                    ngModel.$setViewValue({ startDate: start, endDate: end });
                    ngModel.$render();
                });
            });         
        }
    };
});






