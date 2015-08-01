/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyNhanVienModule = angular.module('QuanLyNhanVienModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap',
    'dialogs.main', 'QuanLyHeaderModule', 'QuanLyMenuModule']);


QuanLyNhanVienModule.factory('QuanLyNhanVienModel', ['BaseModel', '$rootScope',
    function (BaseModel, $rootScope) {

        var model = BaseModel.getInstance();

        model.form = {
            timkiem: {
                ngaythang: {
                    startDate: new Date(1, 1, 2015),
                    endDate: new Date(31, 12, 2015),
                },
                matheloai: '',
                tieude: '',
                noidungtomtat: '',
                tacgia: '',
            },
            list: [],
            filtered: []
        };

        model.data = {
            comboBoxTheLoai: [],
        }

        model.list = {
            delID: [],
        }

        return model;

    }]);

QuanLyNhanVienModule.controller('QuanLyNhanVienControl', function ($rootScope,
    $scope, $modal, $http, $window, $log, dialogs, QuanLyNhanVienModel) {
    $scope.model = QuanLyNhanVienModel;

    sessionStorage.removeItem("MANHANVIEN");

    $scope.init = function () {

        setTimeout(function () {
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
            //$scope.getDanhSachBanTin(params);

            //$scope.getComboBoxTheLoai();
        }, 100);
 
        // Table Paging
        $scope.model.currentPage = 1; //current page
        $scope.model.entryLimit = 15; //max no of items to display in a page
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