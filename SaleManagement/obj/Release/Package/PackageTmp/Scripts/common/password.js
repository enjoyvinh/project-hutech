/**
* Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */
/**
 *
 * @version $Revision: $ $Date: $
 */

'use strict';

var passwordModule = angular.module('passwordModule', [ 'commonModule', 'paragonApp'
                                                        , 'headerModule', 'navigationModule']);

passwordModule.factory('PasswordModel', function(BaseModel, $rootScope) {
    // モデルのベースをBaseModelとする。
    var model = BaseModel.getInstance();
    // サーバーと連携する画面項目の定義R
    model.form = {
        userId : model.userId,
        password : model.password
    };

    model.hidden = {
            resetPassword : false,
            changePassword : false
        };

    /*
     * 画面項目を初期化する。
     */
    model.setup = function(model) {
        // メッセージクラスを取得し、sessionStorageに保管する。
        Messages.setMessage(model.msgList);
    };
    /*
     * バリデータ
     */
    model.validate =
            function() {
                jQuery.validator.setDefaults({
                    debug: true
                  });
                    var validator = $("#loginBox").validate({
                        rules: {
                                    email: {email: true, required: true},
                                    password: {required: true, minlength : 8}
                        },
                        messages: {
                                email: {
                                              required: Messages.getMessage('W00001'),
                                              email : Messages.getMessage('W00023')
                                },
                                password: {
                                              required: Messages.getMessage('W00002'),
                                              minlength : Messages.getMessage('W00010')
                                }
                        },
                        tooltip_options: {
                                email: {trigger:'focus hover'},
                                password: {trigger:'focus hover'}
                        }
                    });
                    return validator.form();
            };
    /*
     * Modelをsubmitする処理
     */
    model.submit = function(action, callback) {
        // バリデートに成功した場合のみsubmitする
         if (this.validate()) {
                this.submitModel(action, this.form, function(data) {
                    callback(data);
                });
                return;
         }
    };
    return model;
});

passwordModule.controller('passwordCtrl', function($scope, $rootScope,
        PasswordModel, $window) {
    console.log("password passwordCtrl");
    /*
     * 初期表示 <pre> 対応するJSPのng-init属性経由でcallされる </pre>
     */
    $scope.init = function(model) {
        // Model(画面項目)の初期化
        $scope.model = PasswordModel;
        //$scope.model.setup(model);

        $scope.$on("password#changePassword",function(param){
            console.log("param" +param);
            $scope.model.hidden.resetPassword = false;
            $scope.model.hidden.changePassword = true;
        });
    };
  //redirect to reset password
    $scope.goToResetPassword = function() {
        $scope.init();
        $window.location = "password";
        $scope.model.hidden.resetPassword = true;
        $scope.model.hidden.changePassword = false;
    };

    $scope.submit = function() {
//        $scope.model.submit(getContextPath() + '/tlogin/logon', function(data) {
//            if (data.url != undefined) {
//                // 画面遷移する
//                if(data.message != ''){
//                    $rootScope.launch('error', 'error', data.message, {size: 'sm'});
//                    return;
//                }
//                $window.location = data.url;
//            } else {
//                $rootScope.launch('error', 'error', data.message, {size: 'sm'});
//            }
//        });
    };
});
