/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyBanTinModule = angular.module('QuanLyBanTinModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap',
    'dialogs.main','QuanLyHeaderModule', 'QuanLyMenuModule']);


QuanLyBanTinModule.factory('QuanLyBanTinModel', ['BaseModel', '$rootScope',
    function(BaseModel, $rootScope) {

  var model = BaseModel.getInstance();

  model.form = {
      timkiem: {
          ngaythang: {
              startDate: new Date(1,1,2015),
              endDate: new Date(31, 12, 2015),
          },
          matheloai: '',
          tieude: '',
          noidungtomtat: '',
          tacgia: '',
      },
      list : [],
      filtered : []
  };
  model.data = {
      comboBoxTheLoai: [],
  }
  model.list = {
      delID : [],
  }
  return model;

} ]);

QuanLyBanTinModule.controller('QuanLyBanTinControl', function ($rootScope,
    $scope, $modal, $http, $filter, $window, $log, dialogs, QuanLyBanTinModel) {
    $scope.model = QuanLyBanTinModel;
  
    sessionStorage.removeItem("MABANTIN");

    $scope.init = function () {


    setTimeout(function() {
      var date = new Date();
      var params = {
          ngaythang: {
              startDate: $filter('date')(DateUtils.getFirstDateOfMonth(), "yyyy/MM/dd"),
              endDate: $filter('date')(DateUtils.getLateDateOfMonth(), "yyyy/MM/dd")
          },
          matheloai: '',
          tieude: '',
          noidungtomtat: '',
          tacgia: '',
      };
      $scope.getDanhSachBanTin(params);

      $scope.getComboBoxTheLoai();
    }, 100);

    $scope.getComboBoxTheLoai = function () {

        var params = {
            TENTHELOAI: '',
        };
        console.log(params);
        $rootScope.$broadcast('doPost', {
            action: 'api/APIQLTheLoai/getDanhSachTheLoai',
            params: params,
            callback: function (result) {
                console.log(result);
                $scope.model.data.comboBoxTheLoai = result.dsTheLoai;
            }
        });
    };

    $scope.getDanhSachBanTin = function (param) {

        var date = new Date();

        var params = {
            TUNGAY: param.ngaythang.startDate != null ? param.ngaythang.startDate : new Date(date.getFullYear(), date.getMonth() - 3, 1),
            DENNGAY: param.ngaythang.endDate != null ? param.ngaythang.endDate : date,
            MATHELOAI: !ValidateUtil.isValidTextEmpty(param.matheloai) ? param.matheloai : '',
            TIEUDE: !ValidateUtil.isValidTextEmpty(param.tieude) ? param.tieude : '',
            NOIDUNGTOMTAT: !ValidateUtil.isValidTextEmpty(param.noidungtomtat) ? param.noidungtomtat : '',
            TACGIA: !ValidateUtil.isValidTextEmpty(param.tacgia) ? param.tacgia : '',
      };

      console.log(params);

      $rootScope.$broadcast('doPost', {
          action: 'api/APIQLBanTin/getDanhSachBanTin',
        params : params,
        callback : function(result) {
          console.log(result);
          
          $scope.model.form.list = result.dsBanTin;
          
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

    $scope.delBanTin = function (param) {
        var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn Xóa Bản Tin Này?", { size: 'sm' });
        dlg.result.then(function (btn) {
            var params = {
                MABANTIN: !ValidateUtil.isValidTextEmpty(param.MABANTIN) ? param.MABANTIN : '',
            };
            console.log(params);
            $rootScope.$broadcast('doPost', {
                action: 'api/APIQLBanTin/xoaBanTin',
                params: params,
                callback: function (result) {
                    if (!ValidateUtil.isValidTextEmpty(result.SUCCESS)) {
                        var dlg = dialogs.notify("Thông Báo", result.SUCCESS, { size: 'sm' });
                        dlg.result.then(function (btn) {
                            var date = new Date();
                            var params = {
                                ngaythang: {
                                    startDate: $filter('date')(DateUtils.getFirstDateOfMonth(), "yyyy/MM/dd"),
                                    endDate: $filter('date')(DateUtils.getLateDateOfMonth(), "yyyy/MM/dd")
                                },
                                matheloai: '',
                                tieude: '',
                                noidungtomtat: '',
                                tacgia: '',
                            };
                            $scope.getDanhSachBanTin(params);
                        });
                    } else {
                        if (!ValidateUtil.isValidTextEmpty(result.WARNING)) {
                            dialogs.errorWarning("Cảnh Báo", result.WARNING, { size: 'md' });
                        } else {
                            dialogs.error("Lỗi Hệ Thống", result.ERROR, { size: 'md' });
                        }
                    }
                }
            });
        });
    };

    $scope.checkAll = function () {
        $scope.model.list.delID = $scope.model.form.list.map(function (item) { return item.MATHELOAI; });
    };
    $scope.uncheckAll = function () {
        $scope.model.list.delID = [];
    };

    $scope.goToUpdate = function (param) {

        var params = {
            MATHELOAI: !ValidateUtil.isValidTextEmpty(param.MATHELOAI) ? param.MATHELOAI : '',
        };
     
    };

    $scope.goToAddNew = function () {
        $window.location = 'QuanLyThemBanTin';
    };

    $scope.goToUpdate = function (param) {

        if (param.MABANTIN != "" && param.MABANTIN != null && param.MABANTIN != "undefined") {
            sessionStorage.setItem("MABANTIN", param.MABANTIN);
            $window.location = 'QuanLyCapNhatBanTin';
        }
        else {
            dialogs.error("Lỗi Hệ Thống", "Có Lỗi Không Mong Muốn Đã Xảy Ra, Vui Lòng Thử Lại", { size: 'md' });
        }
        
    };

    // Table Paging
    $scope.model.currentPage = 1; //current page
    $scope.model.entryLimit =  15; //max no of items to display in a page
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