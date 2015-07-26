/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyDanhMucModule = angular.module('QuanLyDanhMucModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap',
    'dialogs.main','QuanLyHeaderModule', 'QuanLyMenuModule']);


QuanLyDanhMucModule.factory('QuanLyDanhMucModel', [ 'BaseModel', '$rootScope',
    function(BaseModel, $rootScope) {

  var model = BaseModel.getInstance();

  model.form = {
      timkiem : {
        tendanhmuc : '',
      },
      list : [],
      filtered : []
    };

  return model;

} ]);

QuanLyDanhMucModule.controller('QuanLyDanhMucControl', function($rootScope,
    $scope, $modal, $http, $window, $log, dialogs, QuanLyDanhMucModel) {
  $scope.model = QuanLyDanhMucModel;

  $scope.open = function($event) {
      $event.preventDefault();
      $event.stopPropagation();

      $scope.opened = true;
    };
  
  sessionStorage.removeItem("danhmucDetail");

  $scope.init = function() {
      
      var functions = {
              phanQuyen : '',
              chucNang : ''
      }
      
      $rootScope.$broadcast('doPost', {
          action : 'checkAuthentication',
          params : functions,
          callback : function(result) {
              console.log(result);
              
          }
      });

    setTimeout(function() {
      var params = {
        tendanhmuc : '',
      };
      $scope.getDanhSachDanhMuc(params);
    }, 100);

    $scope.getDanhSachDanhMuc = function(param) {

      var params = {
        tendanhmuc : !ValidateUtil.isValidTextEmpty(param.tendanhmuc) ? param.tendanhmuc : '',
      };
      console.log(params);
      $rootScope.$broadcast('doPost', {
        action : 'getCategories',
        params : params,
        callback : function(result) {
          console.log(result);
          
          $scope.model.form.list = result.danhsachdanhmuc;
          
          // Table Paging
          $scope.model.filteredItems = $scope.model.form.list.length; //Initially for no filter
          $scope.model.totalItems = $scope.model.form.list.length;
          if($scope.model.form.list.length > 0) {
            $scope.model.beginValFilter = 1;
          }
          else {
            $scope.model.beginValFilter = 0;
          }
        }
      });
    };

    // Table Paging
    $scope.model.currentPage = 1; //current page
    $scope.model.entryLimit = 15; //max no of items to display in a page
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

  };

  $scope.init();

});