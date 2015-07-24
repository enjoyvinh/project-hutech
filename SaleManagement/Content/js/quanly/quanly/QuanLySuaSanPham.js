/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLySuaSanPhamModule = angular.module('QuanLySuaSanPhamModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap', 'ui.sortable',
    'dialogs.main', 'QuanLyHeaderModule', 'QuanLyMenuModule' ]);

QuanLySuaSanPhamModule.factory('QuanLySuaSanPhamModel', [ 'BaseModel',
    '$rootScope', function(BaseModel, $rootScope) {

      var model = BaseModel.getInstance();

      return model;
    } ]);

QuanLySuaSanPhamModule.controller('QuanLySuaSanPhamControl', function(
    $rootScope, $scope, $http, $window, dialogs, QuanLySuaSanPhamModel) {
  $scope.model = QuanLySuaSanPhamModel;

  $scope.init = function() {

  };

  $scope.init();
});