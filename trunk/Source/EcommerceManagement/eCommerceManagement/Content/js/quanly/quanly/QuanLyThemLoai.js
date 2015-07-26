/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyThemLoaiModule = angular.module('QuanLyThemLoaiModule', [
        'commonModule', 'paragonApp', 'ui.bootstrap', 'ui.sortable',
        'dialogs.main','QuanLyHeaderModule', 'QuanLyMenuModule'  ]);

QuanLyThemLoaiModule.factory('QuanLyThemLoaiModel', [ 'BaseModel',
        '$rootScope', function(BaseModel, $rootScope) {

    var model = BaseModel.getInstance();
    
    model.form = {
        loai : {
          madanhmuc:'',
          tenloai:'',
          motaloai:'',
        },
        danhsachdanhmuc : [],
    };
    
    model.validate = function() {
        var validator = $("#themLoai").validate({
          rules: {
            madanhmuc: {required: true},
            tenloai: {required: true},
          },
          messages: {
              madanhmuc: {required : "Vui lòng chọn danh mục"},
              tenloai: {required : "Vui lòng nhập tên loại mới"},
          },
        });
        return validator.form();
      };
    
    return model;
} ]);

QuanLyThemLoaiModule.controller('QuanLyThemLoaiControl', function($rootScope,
        $scope, $http, $window, dialogs, QuanLyThemLoaiModel) {

    $scope.model = QuanLyThemLoaiModel;
    
    
    $rootScope.$broadcast('doPost', {
        action : 'getDanhSachDanhMucChoThemLoai',
        params : {},
        callback : function(result) {
          console.log($scope.model);
          $scope.model.form.danhsachdanhmuc = result.danhsachdanhmuc;
        }
      });
    
    $scope.themMoi = function(param){
        if (!$scope.model.validate()) {
          return;
        };
        var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn thêm mới?",{size: 'sm'});
        dlg.result.then(function(btn){
          var params = {
              madanhmuc : !ValidateUtil.isValidTextEmpty(param.madanhmuc) ? param.madanhmuc.toString() : '',
              tenloai : !ValidateUtil.isValidTextEmpty(param.tenloai) ? param.tenloai : '',
              motaloai : !ValidateUtil.isValidTextEmpty(param.motaloai) ? param.motaloai : '',
            };

          $rootScope.$broadcast('doPost', {
            action : 'themLoai',
            params : params,
            callback : function(result) {
            console.log(result);

            if (!ValidateUtil.isValidTextEmpty(result.ThanhCong)) {
              var dlg = dialogs.notify("Thông Báo",result.ThanhCong,{size: 'sm'});
                dlg.result.then(function(btn){
                  $window.location = 'quanlyloai';
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
    
});