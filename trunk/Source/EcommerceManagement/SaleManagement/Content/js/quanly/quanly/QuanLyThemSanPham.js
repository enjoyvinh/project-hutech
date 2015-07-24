/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyThemSanPhamModule = angular.module('QuanLyThemSanPhamModule', [
    'commonModule', 'paragonApp', 'ui.bootstrap', 'ui.sortable',
    'dialogs.main', 'QuanLyHeaderModule', 'QuanLyMenuModule' ]);

QuanLyThemSanPhamModule.factory('QuanLyThemSanPhamModel', [ 'BaseModel',
    '$rootScope', function(BaseModel, $rootScope) {

      var model = BaseModel.getInstance();

      model.form = {
         sanpham : {
          masanpham : '',
          manhasanxuat : '',
          tensanpham : '',
          giaban : '',
          thongso : '',
          mota : '',
          baohanh : 12,
          namsanxuat: 2014,
          fileAnh: '',
         },
      };
      return model;
    } ]);

QuanLyThemSanPhamModule.controller('QuanLyThemSanPhamControl', function(
    $rootScope, $scope, $http, $window, dialogs, QuanLyThemSanPhamModel) {
  $scope.model = QuanLyThemSanPhamModel;

  $scope.themMoi = function(param){
//      if (!$scope.model.validate()) {
//        return;
//      };

    var dlg = dialogs.confirm("Xác Nhận", "Bạn muốn thêm mới?",{size: 'sm'});
    dlg.result.then(function(btn){
      var params = {
        fileAnh : param.fileAnh,
      };

      var fd = new FormData();
      fd.append('file', param.fileAnh);
      $http.post("themSanPham", fd, {
          transformRequest: angular.identity,
          headers: {'Content-Type': undefined}
      })
      .success(function(result){
        console.log(result);
      })
      .error(function(){
      });

//      $rootScope.$broadcast('doPost', {
//        action : 'themSanPham',
//        params : params,
//        callback : function(result) {
//          console.log(result);

//	        if (!ValidateUtil.isValidTextEmpty(result.ThanhCong)) {
//	          var dlg = dialogs.notify("Thông Báo",result.ThanhCong,{size: 'sm'});
//	            dlg.result.then(function(btn){
//	              $window.location = 'quanlydanhmuc';
//	            });
//	        } else {
//	          if(!ValidateUtil.isValidTextEmpty(result.CanhBao)){
//	            dialogs.errorWarning("Cảnh Báo",result.CanhBao,{size: 'sm'});
//	          }else{
//	            dialogs.error("Lỗi Hệ Thống",result.Loi,{size: 'sm'});
//	          }
//	        }
//        }
//      });
    });
  };
});