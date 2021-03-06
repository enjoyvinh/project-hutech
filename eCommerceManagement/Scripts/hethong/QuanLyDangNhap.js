/**
* Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var quanLyDangNhapModule = angular.module('QuanLyDangNhapModule', ['commonModule', 'paragonApp'
    , 'ui.bootstrap', 'dialogs.main', 'webcam']);

quanLyDangNhapModule.factory('QuanLyDangNhapModel', ['BaseModel', '$rootScope', function (BaseModel, $rootScope) {

    var model = BaseModel.getInstance();

    model.form = {
        dangnhap: {
            manhanvien: "",
            matkhau: "",
        },
    };

    return model;
}]);

quanLyDangNhapModule.controller('QuanLyDangNhapControl', function ($rootScope, $scope, $http, $window, $location, dialogs, QuanLyDangNhapModel) {

    $scope.model = QuanLyDangNhapModel;

    $scope.loading = true;

    //$scope.myChannel = {
        // the fields below are all optional
        //videoHeight: 800,
        //videoWidth: 600,
        //video: null // Will reference the video element on success
    //};

    //$scope.onError = function (err) { };
    //$scope.onStream = function (stream) { };
    //$scope.onSuccess = function () { };

    //$scope.init = function () {

    //};

    //$scope.init();

    $scope.reset = function () {
        $scope.$broadcast('show-errors-reset');
    }

    $scope.doLogin = function (param) {
        //var options = {
            
        //};
        //var dlg = dialogs.create('Home/QuanLyDanhMuc', 'QuanLyDanhMucControl', param, options);
        //dlg.result.then(function (param) {
        //});
        $rootScope.setLoading(true);
        $scope.$broadcast('show-errors-check-validity');

        if ($scope.dangnhapForm.$valid) {

            $rootScope.$broadcast('doPost', {
                action: 'api/API_HeThong_DangNhap/doLogin',
                params: param,
                callback: function (result) {

                    console.log(result);
                    if (!ValidateUtil.isValidTextEmpty(result.SUCCESS)) {
                        sessionStorage.setItem("TaiKhoanNhanVien", result.MaNhanVien);
                        sessionStorage.setItem("TenNhanVien", result.TenNhanVien);
                        sessionStorage.setItem("PhanQuyen", result.PhanQuyen);
                        sessionStorage.setItem("ThoiGianDangNhap", $.now());
                        $window.location = '/HeThong/Dashboard';
                    } else {
                        if (!ValidateUtil.isValidTextEmpty(result.WARNING)) {
                            dialogs.errorWarning("Cảnh Báo", result.CanhBao, { size: 'md' });
                        } else {
                            dialogs.error("Lỗi Hệ Thống", result.Loi, { size: 'md' });
                        }
                    }
                    $rootScope.setLoading(false);
                }
            });
        };
    };

});