/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyThemDanhMucModule = angular.module('QuanLyThemDanhMucModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap',
    'dialogs.main']);


QuanLyThemDanhMucModule.factory('QuanLyThemDanhMucModel', ['BaseModel', '$rootScope',
    function (BaseModel, $rootScope) {

        var model = BaseModel.getInstance();

        model.form = {
            chitiet: {
                tendanhmuc: ''
            },
        };

        return model;

}]);

QuanLyThemDanhMucModule.controller('QuanLyThemDanhMucControl', function ($rootScope,
    $scope, $modal, $http, $modalInstance, $window, $log, dialogs, QuanLyThemDanhMucModel, data) {
    $scope.model = QuanLyThemDanhMucModel;

    $scope.close = function () {
        $modalInstance.dismiss('close');
    };

    $scope.init = function () {

        $scope.doAddNew = function (param) {

            if ($scope.formThem.$valid) {

                var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn thêm mới?", { size: 'sm' });
                dlg.result.then(function (btn) {

                    var params = {
                        DanhMucName: !ValidateUtil.isValidTextEmpty(param.tendanhmuc) ? param.tendanhmuc : '',
                    };

                    $rootScope.$broadcast('doPost', {
                        action: 'api/APIQLDanhMuc/themDanhMuc',
                        params: params,
                        callback: function (result) {
                            if (!ValidateUtil.isValidTextEmpty(result.SUCCESS)) {
                                var dlg = dialogs.notify("Thông Báo", result.SUCCESS, { size: 'sm' });
                                dlg.result.then(function (btn) {
                                    $modalInstance.dismiss('close');
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

    };

    $scope.init();

});