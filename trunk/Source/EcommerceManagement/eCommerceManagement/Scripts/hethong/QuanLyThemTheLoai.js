/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyThemTheLoaiModule = angular.module('QuanLyThemTheLoaiModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap',
    'dialogs.main','QuanLyHeaderModule', 'QuanLyMenuModule']);


QuanLyThemTheLoaiModule.factory('QuanLyThemTheLoaiModel', ['BaseModel', '$rootScope',
    function(BaseModel, $rootScope) {

  var model = BaseModel.getInstance();

  model.form = {
      chitiet : {
          tentheloai: '',
          mota: '',
          xoa: '1',
      },
    };

  return model;

} ]);

QuanLyThemTheLoaiModule.controller('QuanLyThemTheLoaiControl', function ($rootScope,
    $scope, $modal, $http, $window, $log, dialogs, QuanLyThemTheLoaiModel) {
    $scope.model = QuanLyThemTheLoaiModel;

  $scope.init = function() {

      $scope.doAddNew = function (param) {

          if ($scope.formThem.$valid) {

              var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn thêm mới?", { size: 'sm' });
              dlg.result.then(function (btn) {

                  var params = {
                      TENTHELOAI: param.tentheloai,
                      MOTA: !ValidateUtil.isValidTextEmpty(param.mota) ? param.mota : '',
                      XOA: !ValidateUtil.isValidTextEmpty(param.xoa) ? param.xoa : 0,
                  };

                  $rootScope.$broadcast('doPost', {
                      action: 'api/APIQLTheLoai/themTheLoai',
                      params: params,
                      callback: function (result) {
                          if (!ValidateUtil.isValidTextEmpty(result.SUCCESS)) {
                              var dlg = dialogs.notify("Thông Báo", result.SUCCESS, { size: 'sm' });
                              dlg.result.then(function (btn) {
                                  $window.location = 'QuanLyTheLoai';
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
          }
      };

    $scope.goBack = function (param) {
        $window.location = 'QuanLyTheLoai';
    };

  };

  $scope.init();

});