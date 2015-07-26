/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLySanPhamModule = angular.module('QuanLySanPhamModule', [ 'commonModule',
    'paragonApp', 'ui.bootstrap', 'ui.sortable', 'dialogs.main',
    'QuanLyHeaderModule', 'QuanLyMenuModule' ]);

QuanLySanPhamModule.factory('QuanLySanPhamModel', [ 'BaseModel', '$rootScope',
    function(BaseModel, $rootScope) {

      var model = BaseModel.getInstance();

      model.form = {
        timkiem : {
           madanhmuc : '',
           maloai : '',
           manhasanxuat : '',
           tensanpham : '',
           giaban : '',
        },
        danhsachdanhmuc : [],
        danhsachloai : [],
        danhsachnhasanxuat : [],
        list : [],
        filtered : []
      };

      return model;
    } ]);

QuanLySanPhamModule
    .controller(
        'QuanLySanPhamControl',
        function($rootScope, $scope, $http, $window, $timeout, dialogs,
            QuanLySanPhamModel) {

          $scope.model = QuanLySanPhamModel;

          $scope.init = function() {

            setTimeout(function() {
              var params = {
                madanhmuc : '',
                maloai : '',
                manhasanxuat : '',
                tensanpham : '',
                giaban : '',
              };
              $scope.getDanhSachSanPham(params);
            }, 100);

            $scope.getDanhSachSanPham = function(param) {

              console.log(param);
              var params = {
                madanhmuc : !ValidateUtil.isValidTextEmpty(param.madanhmuc) ? param.madanhmuc.toString() : '',
                maloai : !ValidateUtil.isValidTextEmpty(param.maloai) ? param.maloai.toString() : '',
                manhasanxuat : !ValidateUtil.isValidTextEmpty(param.manhasanxuat) ? param.manhasanxuat.toString() : '',
                tensanpham : !ValidateUtil.isValidTextEmpty(param.tensanpham) ? param.tensanpham : '',
                giaban : !ValidateUtil.isValidTextEmpty(param.giaban) ? param.giaban : '',
              };
              console.log(params);
              $rootScope.$broadcast('doPost',{
                  action : 'getDanhSachSanPham',
                  params : params,
                  callback : function(result) {
                    console.log(result);

                    $scope.model.form.list = result.danhsachsanpham;

                    $scope.model.form.danhsachdanhmuc = result.danhsachdanhmuc;
                    $scope.model.form.danhsachloai = result.danhsachloai;
                    $scope.model.form.danhsachnhasanxuat = result.danhsachnhasanxuat;

                    // Table Paging
                    $scope.model.filteredItems = $scope.model.form.list.length;
                    $scope.model.totalItems = $scope.model.form.list.length;
                    if ($scope.model.form.list.length > 0) {
                      $scope.model.beginValFilter = 1;
                    } else {
                      $scope.model.beginValFilter = 0;
                    }
                    // Table Paging
                  }
                });
            };

            // Table Paging
            $scope.model.currentPage = 1; // current page
            $scope.model.entryLimit = 10; // max no of items to display in a page
            $scope.model.filteredItems = $scope.model.form.list.length; // Initially for no filter
            $scope.model.totalItems = $scope.model.form.list.length;
            if ($scope.model.form.list.length > 0) {
              $scope.model.beginValFilter = 1;
            } else {
              $scope.model.beginValFilter = 0;
            }

            $scope.setPage = function(pageNo) {
              $scope.currentPage = pageNo;
            };

            $scope.model.filter = function() {
              $timeout(
                  function() {
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

          $scope.goToThem = function() {
            $window.location = 'quanlythemsanpham';
          };

          $scope.goToSua = function(param) {
            sessionStorage.setItem("sanphamDetail", JSON.stringify(param));
            $window.location = 'quanlysuasanpham';
          };

          $scope.init();
        });