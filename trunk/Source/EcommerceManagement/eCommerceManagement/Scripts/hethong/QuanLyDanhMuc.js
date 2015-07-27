/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyDanhMucModule = angular.module('QuanLyDanhMucModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap', 'ui.tree',
    'dialogs.main', 'QuanLyHeaderModule', 'QuanLyMenuModule', 'QuanLyThemDanhMucModule']);


QuanLyDanhMucModule.factory('QuanLyDanhMucModel', ['BaseModel', '$rootScope',
    function (BaseModel, $rootScope) {

        var model = BaseModel.getInstance();

        model.form = {
            timkiem: {
                madanhmuc: '',
                tendanhmuc: ''
            },
            list: [],
            filtered: []
        };
        model.list = {
            delID: [],
        }
        return model;

    }]);

QuanLyDanhMucModule.controller('QuanLyDanhMucControl', function ($rootScope,
    $scope, $modal, $http, $window, $log, dialogs, QuanLyDanhMucModel) {
    $scope.model = QuanLyDanhMucModel;

    $scope.init = function () {

        setTimeout(function () {
            var params = {
                madanhmuc: '',
                tendanhmuc: ''
            };
            $scope.getDanhSach(params);
        }, 100);

        $scope.getDanhSach = function (param) {

            var params = {
                DanhMucName: !ValidateUtil.isValidTextEmpty(param.tendanhmuc) ? param.tendanhmuc : '',
            };
            console.log(params);
            $rootScope.$broadcast('doPost', {
                action: 'api/APIQLDanhMuc/getDanhSachDanhMuc',
                params: params,
                callback: function (result) {
                    console.log(result);

                    $scope.model.form.list = result.dsDanhMuc;

                    // Table Paging
                    $scope.model.filteredItems = $scope.model.form.list.length; //Initially for no filter
                    $scope.model.totalItems = $scope.model.form.list.length;
                    if ($scope.model.form.list.length > 0) {
                        $scope.model.beginValFilter = 1;
                    }
                    else {
                        $scope.model.beginValFilter = 0;
                    }
                }
            });
        };

        $scope.deleteItem = function (param) {

            var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn xóa thể loại này?", { size: 'sm' });

            dlg.result.then(function (btn) {

                var params = {
                    DanhMucGuid: !ValidateUtil.isValidTextEmpty(param.DanhMucGuid) ? param.DanhMucGuid : '',
                };

                console.log(params);

                $rootScope.$broadcast('doPost', {
                    action: 'api/APIQLDanhMuc/xoaDanhMuc',
                    params: params,
                    callback: function (result) {
                        if (!ValidateUtil.isValidTextEmpty(result.SUCCESS)) {
                            var dlg = dialogs.notify("Thông Báo", result.SUCCESS, { size: 'sm' });
                            dlg.result.then(function (btn) {
                                var params = {
                                    madanhmuc: '',
                                    tendanhmuc: ''
                                };
                                $scope.getDanhSach(params);
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

        $scope.goToUpdate = function (param) {

            var params = {
                MATHELOAI: !ValidateUtil.isValidTextEmpty(param.MATHELOAI) ? param.MATHELOAI : '',
            };

        };

        $scope.goToAddNew = function () {
            //$window.location = 'QuanLyThemTheLoai';

            var options = {};
            var param = {};
            var dlg = dialogs.create($window.location.origin + "/Management/QuanLyThemDanhMuc", 'QuanLyThemDanhMucControl', param, options);
            dlg.result.then(function (param) {
            });
        };

        $scope.goToUpdate = function (param) {

            if (param.MATHELOAI != "" && param.MATHELOAI != null && param.MATHELOAI != "undefined") {
                sessionStorage.setItem("MATHELOAI", param.MATHELOAI);
                $window.location = 'QuanLyCapNhatTheLoai';
            }
            else {
                dialogs.error("Lỗi Hệ Thống", "Có Lỗi Không Mong Muốn Đã Xảy Ra, Vui Lòng Thử Lại", { size: 'md' });
            }

        };

        // Table Paging
        $scope.model.currentPage = 1; //current page
        $scope.model.entryLimit = 10; //max no of items to display in a page
        $scope.model.filteredItems = $scope.model.form.list.length; //Initially for no filter
        $scope.model.totalItems = $scope.model.form.list.length;
        if ($scope.model.form.list.length > 0) {
            $scope.model.beginValFilter = 1;
        } else {
            $scope.model.beginValFilter = 0;
        }

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        };

        $scope.model.filter = function () {
            $timeout(function () {
                $scope.model.filteredItems = $scope.model.form.filtered.length;
                if ($scope.model.form.filtered.length > 0) {
                    $scope.model.beginValFilter = 1;
                } else {
                    $scope.model.beginValFilter = 0;
                }
            }, 10);
        };
        // End Table Paging

    };

    $scope.init();

});