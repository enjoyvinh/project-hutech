/**
* Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyTrangChuModule = angular.module('QuanLyTrangChuModule', [ 'commonModule', 'paragonApp','ui.bootstrap', 'ui.sortable', 'dialogs.main']);

QuanLyTrangChuModule.factory('QuanLyTrangChuModel', [ 'BaseModel', '$rootScope', function(BaseModel, $rootScope) {

  var model = BaseModel.getInstance();

}]);

QuanLyTrangChuModule.controller('QuanLyTrangChuControl', function($rootScope, $scope, $http, $window, dialogs, QuanLyTrangChuModel) {
  $scope.model = QuanLyTrangChuModel;

  $scope.init = function(model){

  };

  $scope.init($scope.model);
});