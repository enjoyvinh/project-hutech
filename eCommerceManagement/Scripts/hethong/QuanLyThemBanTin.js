/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyThemBanTinModule = angular.module('QuanLyThemBanTinModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap','ckeditor','ngFileUpload',
    'dialogs.main', 'QuanLyHeaderModule', 'QuanLyMenuModule']);


QuanLyThemBanTinModule.factory('QuanLyThemBanTinModel', ['BaseModel', '$rootScope',
    function(BaseModel, $rootScope) {

  var model = BaseModel.getInstance();

  model.form = {
      chitiet: {
          matheloai: '',
          tieude: '',
          noidungtomtat: '',
          ngaydang: new Date(),
          giodang: new Date(),
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

QuanLyThemBanTinModule.controller('QuanLyThemBanTinControl', function ($rootScope, $timeout,
    $scope, $modal, $http, $filter, $window, $log, $compile, Upload, dialogs, QuanLyThemBanTinModel) {
    $scope.model = QuanLyThemBanTinModel;

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
    }, 100);

    $scope.init = function () {

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

        $scope.doAddNew = function (param) {

            if (!$scope.model.validate()) {
                return;
            }

            var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn thêm mới?", { size: 'sm' });
            dlg.result.then(function (btn) {

                var date = $filter('date')(param.ngaydang, "yyyy/MM/dd");
                var arrDate = date.split('/');

                var now = $filter('date')(param.giodang, "HH:mm");
                var arrNow = now.split(':');

                var ngaytao = new Date(parseInt(arrDate[0]), parseInt(arrDate[1]), parseInt(arrDate[2]), parseInt(arrNow[0]), parseInt(arrNow[1]), 0);


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
                    action: 'api/APIQLBanTin/themBanTin',
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

        function upload(file) {
            $scope.errorMsg = null;
            if ($scope.howToSend === 1) {
                uploadUsingUpload(file);
            } else if ($scope.howToSend == 2) {
                uploadUsing$http(file);
            } else {
                uploadS3(file);
            }
        }

        function uploadUsingUpload(file) {
            file.upload = Upload.upload({
                url: "api/APIQLBanTin/themBanTin",
                method: 'POST',
                headers: {
                    'my-header': 'my-header-value'
                },
                fields: { username: $scope.username },
                file: file,
                fileFormDataName: 'myFile'
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    file.result = response.data;
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            });

            file.upload.progress(function (evt) {
                // Math.min is to fix IE which reports 200% sometimes
                file.progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
            });

            file.upload.xhr(function (xhr) {
                // xhr.upload.addEventListener('abort', function(){console.log('abort complete')}, false);
            });
        }

        function uploadUsing$http(file) {
            file.upload = Upload.http({
                url: "api/APIQLBanTin/themBanTin",
                method: 'POST',
                headers: {
                    'Content-Type': file.type
                },
                data: file
            });

            file.upload.then(function (response) {
                file.result = response.data;
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            });

            file.upload.progress(function (evt) {
                file.progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
            });
        }

        function uploadS3(file) {
            file.upload = Upload.upload({
                url: "api/APIQLBanTin/themBanTin",
                method: 'POST',
                data: {
                    key: file.name,
                    'Content-Type': file.type === null || file.type === '' ? 'application/octet-stream' : file.type,
                    filename: file.name
                },
                file: file
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    file.result = response.data;
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            });

            file.upload.progress(function (evt) {
                file.progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
            });
            //storeS3UploadCon figInLocalStore();
        }

        $scope.generateSignature = function () {
            $http.post('/s3sign?aws-secret-key=' + encodeURIComponent($scope.AWSSecretKey), $scope.jsonPolicy).
                success(function (data) {
                    $scope.policy = data.policy;
                    $scope.signature = data.signature;
                });
        };

    $scope.goBack = function (param) {
        $window.location = 'QuanLyBanTin';
    };

  };

  $scope.init();

});