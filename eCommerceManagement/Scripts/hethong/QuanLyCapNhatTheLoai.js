/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyCapNhatTheLoaiModule = angular.module('QuanLyCapNhatTheLoaiModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap',
    'dialogs.main', 'QuanLyHeaderModule', 'QuanLyMenuModule']);


QuanLyCapNhatTheLoaiModule.factory('QuanLyCapNhatTheLoaiModel', ['BaseModel', '$rootScope',
    function (BaseModel, $rootScope) {

        var model = BaseModel.getInstance();

        model.form = {
            chitiet: {
                matheloai: '',
                tentheloai: '',
                mota: '',
                xoa: '',
            },
        };

        return model;

    }]);

QuanLyCapNhatTheLoaiModule.controller('QuanLyCapNhatTheLoaiControl', function ($rootScope,
    $scope, $modal, $http, $window, $log, dialogs, QuanLyCapNhatTheLoaiModel) {

    $scope.model = QuanLyCapNhatTheLoaiModel;

    setTimeout(function () {
        $scope.getChiTietTheLoai();
    }, 100);


    $scope.init = function () {

        $scope.getChiTietTheLoai = function () {

            var params = {
                MATHELOAI: sessionStorage.getItem("MATHELOAI"),
            };

            $rootScope.$broadcast('doPost', {
                action: 'api/APIQLTheLoai/getChiTietTheLoai',
                params: params,
                callback: function (result) {
                    if (result.ctTheLoai.MATHELOAI != "" && result.ctTheLoai.MATHELOAI != null
                        && result.ctTheLoai.MATHELOAI != "undefined" && result.ctTheLoai.MATHELOAI != 0) {
                        $scope.model.form.chitiet.matheloai = result.ctTheLoai.MATHELOAI;
                        $scope.model.form.chitiet.tentheloai = result.ctTheLoai.TENTHELOAI;
                        $scope.model.form.chitiet.mota = result.ctTheLoai.MOTA;
                        if (result.ctTheLoai.XOA == true) {
                            $scope.model.form.chitiet.xoa = "1";
                        } else {
                            $scope.model.form.chitiet.xoa = "0";
                        }
                    } else {
                        var dlg = dialogs.errorWarning("Cảnh Báo", "Không Có Thể Loại", { size: 'sm' });
                        dlg.result.then(function (btn) {
                            $window.location = 'QuanLyTheLoai';
                        });
                    }
                }
            });
        };

        $scope.doUpdate = function (param) {

            if ($scope.formCapNhat.$valid) {

                var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn cập nhật?", { size: 'sm' });

                dlg.result.then(function (btn) {

                    var params = {
                        MATHELOAI: param.matheloai,
                        TENTHELOAI: param.tentheloai,
                        MOTA: !ValidateUtil.isValidTextEmpty(param.mota) ? param.mota : '',
                        XOA: !ValidateUtil.isValidTextEmpty(param.xoa) ? param.xoa : 0,
                    };

                    $rootScope.$broadcast('doPost', {
                        action: 'api/APIQLTheLoai/capnhatTheLoai',
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