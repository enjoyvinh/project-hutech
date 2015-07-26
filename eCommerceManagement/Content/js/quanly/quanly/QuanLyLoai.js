/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyLoaiModule = angular.module('QuanLyLoaiModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap', 'ui.sortable',
    'dialogs.main','QuanLyHeaderModule', 'QuanLyMenuModule' ]);

QuanLyLoaiModule.factory('QuanLyLoaiModel', [ 'BaseModel',
    '$rootScope', function(BaseModel, $rootScope) {

      var model = BaseModel.getInstance();

      model.form = {
        timkiem : {
          madanhmuc : '',
          tenloai : '',
        },
        danhsachdanhmuc : [],
        list : [],
        filtered : []
      };

      return model;
} ]);

QuanLyLoaiModule.controller('QuanLyLoaiControl', function($rootScope,
    $scope, $http, $window, $timeout, dialogs, QuanLyLoaiModel) {

    $scope.model = QuanLyLoaiModel;

    setTimeout(function() {
      var params = {
          madanhmuc : '',
          tenloai : '',
      };
      $scope.getDanhSachLoai(params);
    }, 100);
    
    $scope.getDanhSachLoai = function(param) {
    
      var params = {
          madanhmuc : !ValidateUtil.isValidTextEmpty(param.madanhmuc) ? param.madanhmuc.toString() : '',
          tenloai : !ValidateUtil.isValidTextEmpty(param.tenloai) ? param.tenloai : '',
      };
      console.log(params);
      $rootScope.$broadcast('doPost', {
        action : 'getDanhSachLoai',
        params : params,
        callback : function(result) {
          console.log(result);
    
          $scope.model.form.list = result.danhsachloai;
    
          $scope.model.form.danhsachdanhmuc = result.danhsachdanhmuc;
    
          // Table Paging
          $scope.model.filteredItems = $scope.model.form.list.length; //Initially for no filter
          $scope.model.totalItems = $scope.model.form.list.length;
          if($scope.model.form.list.length > 0){
            $scope.model.beginValFilter = 1;
          }else{
            $scope.model.beginValFilter = 0;
          }
          // Table Paging
        }
      });
    };
    
    // Table Paging
    $scope.model.currentPage = 1; //current page
    $scope.model.entryLimit = 10; //max no of items to display in a page
    $scope.model.filteredItems = $scope.model.form.list.length; //Initially for no filter
    $scope.model.totalItems = $scope.model.form.list.length;
    if($scope.model.form.list.length > 0){
      $scope.model.beginValFilter = 1;
    }else{
      $scope.model.beginValFilter = 0;
    }
    
    $scope.setPage = function(pageNo) {
      $scope.currentPage = pageNo;
    };
    
    $scope.model.filter = function() {
      $timeout(function() {
        $scope.model.filteredItems = $scope.model.form.filtered.length;
        if($scope.model.form.filtered.length > 0){
          $scope.model.beginValFilter = 1;
        }else{
          $scope.model.beginValFilter = 0;
        }
      }, 10);
    };
    // End Table Paging
    
  $scope.goToThem = function() {
    $window.location = 'quanlythemloai';
  };

  $scope.goToSua = function(param) {
    sessionStorage.setItem("loaiDetail", JSON.stringify(param));
    $window.location = 'quanlysualoai';
  };
});