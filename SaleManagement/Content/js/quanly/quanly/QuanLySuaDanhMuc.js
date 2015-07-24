/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLySuaDanhMucModule = angular.module('QuanLySuaDanhMucModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap',
    'dialogs.main','QuanLyHeaderModule', 'QuanLyMenuModule' ]);

QuanLySuaDanhMucModule.factory('QuanLySuaDanhMucModel', [ 'BaseModel',
    '$rootScope', function(BaseModel, $rootScope) {

      var model = BaseModel.getInstance();

      model.form={
          danhmuc : {
            madanhmuc: '',
            tendanhmuc:'',
            sapxep: '',
          }
      };

      model.validate = function() {
          var validator = $("#suaDanhMuc").validate({
            rules: {
              tendanhmuc: {required: true},
            },
            messages: {
              tendanhmuc: {required : "Vui lòng nhập tên danh mục mới"},
            },
          });
          return validator.form();
        };

      return model;
    } ]);

QuanLySuaDanhMucModule.controller('QuanLySuaDanhMucControl', function($rootScope,
    $scope, $http, $window, dialogs, QuanLySuaDanhMucModel) {

  $scope.model = QuanLySuaDanhMucModel;

  var danhmucDetail = angular.fromJson(sessionStorage.getItem("danhmucDetail"));

  if(!ValidateUtil.isValidTextEmpty(danhmucDetail)){
    var params = {
        madanhmuc : danhmucDetail.madanhmuc,
    };
    $rootScope.$broadcast('doPost', {
        action : 'getDetailCategory',
        params : params,
        callback : function(result) {
          $scope.model.form.danhmuc.madanhmuc = result.chitiet.madanhmuc;
          $scope.model.form.danhmuc.tendanhmuc = result.chitiet.tendanhmuc;
          $scope.model.form.danhmuc.sapxep = result.chitiet.sapxep;
        }
    });
  }else{
    $window.location = 'categories';
  }

  $scope.init = function() {

    $scope.sua = function(param){
        if (!$scope.model.validate()) {
          return;
        };

        var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn sữa?",{size: 'sm'});
        dlg.result.then(function(btn){
          var params = {
              tendanhmuc : !ValidateUtil.isValidTextEmpty(param.tendanhmuc) ? param.tendanhmuc : '',
              madanhmuc : !ValidateUtil.isValidTextEmpty(param.madanhmuc) ? param.madanhmuc : '',
          };


          $rootScope.$broadcast('doPost', {
            action : 'doUpdateCatory',
            params : params,
            callback : function(result) {
            console.log(result);

            if (!ValidateUtil.isValidTextEmpty(result.ThanhCong)) {
              var dlg = dialogs.notify("Thông Báo",result.ThanhCong,{size: 'sm'});
                dlg.result.then(function(btn){
                  $window.location = 'categories';
                });
            } else {
              if(!ValidateUtil.isValidTextEmpty(result.CanhBao)){
                dialogs.errorWarning("Cảnh Báo",result.CanhBao,{size: 'sm'});
              }else{
                dialogs.error("Lỗi Hệ Thống",result.Loi,{size: 'sm'});
              }
            }
            }
          });
        });
      };

      $scope.xoa = function(param){
        var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn xóa?",{size: 'sm'});
        dlg.result.then(function(btn){
          var params = {
              tendanhmuc : !ValidateUtil.isValidTextEmpty(param.tendanhmuc) ? param.tendanhmuc : '',
              madanhmuc : !ValidateUtil.isValidTextEmpty(param.madanhmuc) ? param.madanhmuc : '',
          };

          $rootScope.$broadcast('doPost', {
            action : 'doDeleteCategory',
            params : params,
            callback : function(result) {
            console.log(result);

            if (!ValidateUtil.isValidTextEmpty(result.ThanhCong)) {
              var dlg = dialogs.notify("Thông Báo",result.ThanhCong,{size: 'sm'});
                dlg.result.then(function(btn){
                  $window.location = 'categories';
                });
            } else {
              if(!ValidateUtil.isValidTextEmpty(result.CanhBao)){
                dialogs.errorWarning("Cảnh Báo",result.CanhBao,{size: 'sm'});
              }else{
                dialogs.error("Lỗi Hệ Thống",result.Loi,{size: 'sm'});
              }
            }
            }
          });
        });
      };
  };

  $scope.goToQuanLy = function() {
      $window.location = 'categories';
    };

  $scope.init();
});