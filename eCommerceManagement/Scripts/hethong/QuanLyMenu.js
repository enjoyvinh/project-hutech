/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */
'use strict';

var QuanLyMenuModule = angular.module('QuanLyMenuModule', [ 'commonModule',
        'paragonApp' ]);

QuanLyMenuModule.factory('QuanLyMenuModel', [ 'BaseModel', '$rootScope',
        function(BaseModel, $rootScope) {

            var model = BaseModel.getInstance();

            model.sessionDangNhap = {
                manhanvien : '',
                tennhanvien : '',
                thoigiandangnhap : '',
                phanquyen : '',
            };

            // model.menu = "";
            return model;
        } ]);

QuanLyMenuModule.controller('QuanLyMenuControl', function($rootScope, $scope,
        $http, $window, $timeout, dialogs, QuanLyMenuModel) {

    $scope.model = QuanLyMenuModel;

    $scope.init = function(model) {
        $scope.model.sessionDangNhap.manhanvien = sessionStorage
                .getItem("TaiKhoanNhanVien");
        $scope.model.sessionDangNhap.tennhanvien = sessionStorage
                .getItem("TenNhanVien");
        $scope.model.sessionDangNhap.thoigiandangnhap = sessionStorage
                .getItem("thoiGianDangNhap");
        $scope.model.sessionDangNhap.phanquyen = sessionStorage
                .getItem("PhanQuyen");
    };
    
    $timeout(function () {
        var arrayURI = window.location.href.split('/');

        var strMenu = $(arrayURI).get(-1);

        // alert(strMenu);

        switch (strMenu) {
        case "categories":
        case "UpdateCategory":
        case "AddCateogry":
            $("#menuQuanLyHangHoa").removeClass().addClass("active treeview");
            $("#listMenuQuanLyHangHoa").css("display", "block");
            $("#menuQuanLyDanhMuc").removeClass().addClass("active");
            break;

        default:
            $("#menuDashboard").removeClass().addClass("active");
            break;
        }
    }, 1);

    $scope.init();


});