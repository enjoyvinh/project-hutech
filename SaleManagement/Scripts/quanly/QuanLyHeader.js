/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';

var QuanLyHeaderModule = angular.module('QuanLyHeaderModule', ['commonModule', 'paragonApp']);

QuanLyHeaderModule.factory('QuanLyHeaderModel', ['BaseModel', '$rootScope',
	function (BaseModel, $rootScope) {

	    var model = BaseModel.getInstance();

	    model.sessionDangNhap = {
	        manhanvien: '',
	        tennhanvien: '',
	        thoigiandangnhap: '',
	    };

	    model.hidden = {
	        logoffTime: 30 * 60 * 1000,
	        dangNhapThanhCong: 0,
	    };

	    return model;
	}]);

QuanLyHeaderModule.controller('QuanLyHeaderCtrl', function ($timeout, $scope, $rootScope, $http,
	$window, dialogs, QuanLyHeaderModel) {

    $scope.model = QuanLyHeaderModel;

    $scope.init = function () {
        $scope.model.sessionDangNhap.manhanvien = sessionStorage.getItem("TaiKhoanNhanVien");
        $scope.model.sessionDangNhap.tennhanvien = sessionStorage.getItem("TenNhanVien");
        $scope.model.sessionDangNhap.thoigiandangnhap = sessionStorage.getItem("thoiGianDangNhap");

        
    };

    $scope.doLogout = function () {
        $rootScope.$broadcast('doPost', {
            action: 'api/APIDangNhap/doLogout',
            param:{},
            callback: function (result) {
                if (result.url != undefined) {
                    sessionStorage.clear();
                    $window.location = result.url;
                } else {
                    dialogs.errorWarning("Cảnh Báo", "Đăng Xuất Thất Bại, Xảy Ra Lỗi Hệ Thống!", { size: 'md' });
                }
            }
        });
    };

    $scope.init();
});