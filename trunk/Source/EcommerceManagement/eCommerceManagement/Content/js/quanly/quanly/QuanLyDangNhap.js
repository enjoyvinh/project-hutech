/**
* Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var quanLyDangNhapModule = angular.module('QuanLyDangNhapModule', [ 'commonModule', 'paragonApp','ui.bootstrap', 'dialogs.main']);

quanLyDangNhapModule.factory('QuanLyDangNhapModel', [ 'BaseModel', '$rootScope', function(BaseModel, $rootScope) {

var model = BaseModel.getInstance();

  model.form = {
    dangnhap : {
    manhanvien : "manager@skyfire.vn",
    matkhau : "123456789",
    },
  };

  return model;
}]);

quanLyDangNhapModule.controller('QuanLyDangNhapControl', function($rootScope, $scope, $http, $window, dialogs, QuanLyDangNhapModel) {

    $scope.model = QuanLyDangNhapModel;

    $scope.init = function(){

    };
    
    $scope.init();
    
    $scope.reset = function() {
        $scope.$broadcast('show-errors-reset');
    }
    
    $scope.doLogin = function(param)
    {
        $scope.$broadcast('show-errors-check-validity');
        
        if ($scope.dangnhapForm.$valid) {
           
          $rootScope.$broadcast('doPost', {
            action : 'doLogin',
            params : param,
            callback : function(result) {
            console.log(result);
            if (!ValidateUtil.isValidTextEmpty(result.ThanhCong)) {
              sessionStorage.setItem("TaiKhoanNhanVien", result.manhanvien);
              sessionStorage.setItem("TenNhanVien", result.tennhanvien);
              sessionStorage.setItem("PhanQuyen", result.phanquyen);
              sessionStorage.setItem("ThoiGianDangNhap", $.now());
              $window.location = 'home';
            } else {
              if(!ValidateUtil.isValidTextEmpty(result.CanhBao)){
                dialogs.errorWarning("Cảnh Báo",result.CanhBao,{size: 'md'});
              }else{
                dialogs.error("Lỗi Hệ Thống",result.Loi,{size: 'md'});
              }
            }
            }
          });
        };
    };

});