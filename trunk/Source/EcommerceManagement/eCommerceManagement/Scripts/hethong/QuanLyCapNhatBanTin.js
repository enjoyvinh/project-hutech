/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyCapNhatBanTinModule = angular.module('QuanLyCapNhatBanTinModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap','ckeditor','ngFileUpload',
    'dialogs.main', 'QuanLyHeaderModule', 'QuanLyMenuModule']);


QuanLyCapNhatBanTinModule.factory('QuanLyCapNhatBanTinModel', ['BaseModel', '$rootScope',
    function(BaseModel, $rootScope) {

  var model = BaseModel.getInstance();

  model.form = {
      chitiet: {
          matheloai: '',
          tieude: '',
          noidungtomtat: '',
          ngaydang: new Date(),
          giodang: '',
          noidung: '',
          tentacgia: '',
          hinhanh: '',
          xoa: '1',
      },
    };
  model.data = {
      comboBoxTheLoai : [],
  };

  model.validate = function () {

      var form = $("#formThem");

      var validator = form.validate({
          rules: {
              theloai: { required: true },
              tieude: { required: true },
              noidungtomtat: { required: true },
              ngaydang: { required: true },
              noidung: { required: true },
              tentacgia: { required: true },
          },
          messages: {
              theloai: {
                  required: "Vui Lòng Chọn Thể Loại"
              },
              tieude: {
                  required: "Vui Lòng Nhập Tiêu Đề"
              },
              noidungtomtat: {
                  required: "Vui Lòng Nhập Nội Dung Tóm Tắt"
              },
              ngaydang: {
                  required: "Vui Lòng Chọn Ngày Đăng"
              },
              noidung: {
                  required: "Vui Lòng Nhập Nội Dung"
              },
              tentacgia: {
                  required: "Vui Lòng Nhập Tên Tác Giả"
              },
          },
          tooltip_options: {
              theloai: { trigger: 'focus hover' },
              tieude: { trigger: 'focus hover' },
              noidungtomtat: { trigger: 'focus hover' },
              ngaydang: { trigger: 'focus hover' },
              noidung: { trigger: 'focus hover' },
          },
          onfocusout: false,
          invalidHandler: function (form, validator) {
              var errors = validator.numberOfInvalids();
              if (errors) {
                  validator.errorList[0].element.focus();
              }
          }
      });
      return validator.form();
  };

  return model;

} ]);

QuanLyCapNhatBanTinModule.controller('QuanLyCapNhatBanTinControl', function ($rootScope, $timeout,
    $scope, $modal, $http, $filter, $window, $log, $compile, Upload, dialogs, QuanLyCapNhatBanTinModel) {
    $scope.model = QuanLyCapNhatBanTinModel;

    $scope.hstep = 1;
    $scope.mstep = 1;

    $scope.ismeridian = true;
    $scope.toggleMode = function () {
        $scope.ismeridian = !$scope.ismeridian;
    };

    //$scope.model.form.chitiet.ngaydang = $filter('date')(new Date())

    // Editor options.
    $scope.options = {
        language: 'en',
        allowedContent: true,
        entities: true
    };

    setTimeout(function () {
        $scope.getComboBoxTheLoai();

        $scope.getChiTiet();
    }, 100);

    $scope.init = function () {

        $scope.getChiTiet = function () {

            var params = {
                MABANTIN: sessionStorage.getItem("MABANTIN"),
            };

            $rootScope.$broadcast('doPost', {
                action: 'api/APIQLBanTin/getChiTietBanTin',
                params: params,
                callback: function (result) {
                    console.log(result);


                    if (result.ctBanTin.MABANTIN != "" && result.ctBanTin.MABANTIN != null
                        && result.ctBanTin.MABANTIN != "undefined" && result.ctBanTin.MABANTIN != 0) {


                        $scope.model.form.chitiet.matheloai = [result.ctBanTin.MATHELOAI];
                        $scope.model.form.chitiet.tieude = result.ctBanTin.TIEUDE;
                        $scope.model.form.chitiet.noidungtomtat = result.ctBanTin.NOIDUNGTOMTAT;
                        $scope.model.form.chitiet.ngaydang = new Date(result.ctBanTin.NGAYDANG);
                        $scope.model.form.chitiet.giodang = new Date(result.ctBanTin.NGAYDANG);
                        $scope.model.form.chitiet.noidung = result.ctBanTin.NOIDUNG;
                        $scope.model.form.chitiet.tentacgia = result.ctBanTin.TENTACGIA;
                        $scope.model.form.chitiet.hinhanh = result.ctBanTin.HINHANH;

                        if (result.ctBanTin.XOA == true) {
                            $scope.model.form.chitiet.xoa = "1";
                        } else {
                            $scope.model.form.chitiet.xoa = "0";
                        }
                    } else {
                        var dlg = dialogs.errorWarning("Cảnh Báo", "Bản Tin Không Còn Tồn Tại.", { size: 'sm' });
                        dlg.result.then(function (btn) {
                            $window.location = 'QuanLyBanTin';
                        });
                    }
                }
            });
        };


        $scope.getComboBoxTheLoai = function () {
            var params = {
                TENTHELOAI: '',
            };

            console.log(params);
            $rootScope.$broadcast('doPost', {
                action: 'api/APIQLTheLoai/getDanhSachTheLoai',
                params: params,
                callback: function (result) {
                    console.log(result);
                    $scope.model.data.comboBoxTheLoai = result.dsTheLoai;
                }
            });
        };

        $scope.doUpdate = function (param) {

            if (!$scope.model.validate()) {
                return;
            }


            var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn cập nhật bản tin?", { size: 'sm' });
            dlg.result.then(function (btn) {

                var date = $filter('date')(param.ngaydang, "yyyy/MM/dd");
                var arrDate = date.split('/');

                var now = $filter('date')(param.giodang, "HH:mm");
                var arrNow = now.split(':');

                var ngaytao = new Date(parseInt(arrDate[0]), parseInt(arrDate[1]), parseInt(arrDate[2]), parseInt(arrNow[0]), parseInt(arrNow[1]),0);


                var params = {
                    MATHELOAI: !ValidateUtil.isValidTextEmpty(param.matheloai[0]) ? param.matheloai[0] : '',
                    TIEUDE: !ValidateUtil.isValidTextEmpty(param.tieude) ? param.tieude : '',
                    NOIDUNGTOMTAT: !ValidateUtil.isValidTextEmpty(param.noidungtomtat) ? param.noidungtomtat : '',
                    NOIDUNG: !ValidateUtil.isValidTextEmpty(param.noidung) ? param.noidung : '',
                    NGAYDANG: ngaytao,
                    HINHANH: !ValidateUtil.isValidTextEmpty(param.hinhanh[0].name) ? param.hinhanh[0].name : '',
                    TENTACGIA: !ValidateUtil.isValidTextEmpty(param.tentacgia) ? param.tentacgia : '',
                    Attachment: param.hinhanh[0],
                    XOA: !ValidateUtil.isValidTextEmpty(param.xoa) ? param.xoa : 0,
                };
                //var fd = new FormData();
                //$http({
                //    method: 'POST',
                //    url: 'http://localhost:56025/api/APIQLBanTin/themBanTin',
                //    headers: {
                //    'Content-Type': 'multipart/form-data'
                //},
                //data: {
                //    Attachment: param.hinhanh[0]
                //},
                //transformRequest: fd
                //});

                console.log(params);
                $rootScope.$broadcast('doPost', {
                    action: 'api/APIQLBanTin/capnhatBanTin',
                    params: params,
                    callback: function (result) {
                        if (!ValidateUtil.isValidTextEmpty(result.SUCCESS)) {
                            var dlg = dialogs.notify("Thông Báo", result.SUCCESS, { size: 'sm' });
                            dlg.result.then(function (btn) {
                                $window.location = 'QuanLyBanTin';
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


        $scope.goBack = function (param) {
            $window.location = 'QuanLyBanTin';
        };

    };

    $scope.init();

});