/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyThemDanhMucModule = angular.module('QuanLyThemDanhMucModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap',
    'dialogs.main','QuanLyHeaderModule', 'QuanLyMenuModule' ]);

QuanLyThemDanhMucModule.factory('QuanLyThemDanhMucModel', [ 'BaseModel',
    '$rootScope', function(BaseModel, $rootScope) {

      var model = BaseModel.getInstance();

      model.form={
          danhmuc : {
            tendanhmuc:''
          }
      };

//      model.validate = function() {
//          var validator = $("#themDanhMuc").validate({
//            rules: {
//              tendanhmuc: {required: true},
//            },
//            messages: {
//              tendanhmuc: {required : "Vui lòng nhập tên danh mục mới"},
//            },
//          });
//          return validator.form();
//        };

      return model;
    } ]);

QuanLyThemDanhMucModule.controller('QuanLyThemDanhMucControl', function($rootScope,
    $scope, $http, $window, dialogs, QuanLyThemDanhMucModel) {
  $scope.model = QuanLyThemDanhMucModel;

  $scope.init = function(model) {

    $scope.themMoi = function(param){
//        if (!$scope.model.validate()) {
//          return;
//        };

        var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn thêm mới?",{size: 'sm'});
        dlg.result.then(function(btn){
          var params = {
              tendanhmuc : !ValidateUtil.isValidTextEmpty(param.tendanhmuc) ? param.tendanhmuc : '',
            };

          $rootScope.$broadcast('doPost', {
            action : 'doAddCategory',
            params : params,
            callback : function(result) {
            console.log(result);

            if (!ValidateUtil.isValidTextEmpty(result.ThanhCong)) {
              var dlg = dialogs.notify("Thông Báo",result.ThanhCong,{size: 'sm'});
                dlg.result.then(function(btn){
                  $window.location = 'categories';
                });
            } else {
              if(!ValidateUtil.isValidTextEmpty(result.CanhBao)){
                dialogs.errorWarning("Cảnh Báo",result.CanhBao,{size: 'sm'});
              }else{
                dialogs.error("Lỗi Hệ Thống",result.Loi,{size: 'sm'});
              }
            }
            }
          });
        });
      };
  };

  $scope.init($scope.model);
});