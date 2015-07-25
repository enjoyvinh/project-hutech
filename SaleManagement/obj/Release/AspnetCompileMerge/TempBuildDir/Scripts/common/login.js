/**
* Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */
/**
 * 
 * @version $Revision: $ $Date: $
 */

'use strict';

var loginModule = angular.module('loginModule', [ 'commonModule', 'paragonApp' ]);

loginModule.factory('LoginModel', function(BaseModel, $rootScope) {
    // モデルのベースをBaseModelとする。
    var model = BaseModel.getInstance();
    
    // サーバーと連携する画面項目の定義
    model.form = {
        mailAddress : "root@systemexe.com",
        password : "123456789"
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
    model.validate = function() {
        var form = $("#loginBox");
        var validator = form.validate({
            rules : {
                email : {
                    email : true,
                    required : true
                },
                password : {
                    required : true,
                    minlength : 8
                }
            },
            messages : {
                email : {
                    required : Messages.getMessage('W00001'),
                    email : Messages.getMessage('W00056')
                },
                password : {
                    required : Messages.getMessage('W00002'),
                    minlength : Messages.getMessage('W00010')
                }
            },
            tooltip_options : {
                email : {
                    trigger : 'focus'
                },
                password : {
                    trigger : 'focus'
                }
            },
            onfocusout: false,
            invalidHandler: function(form, validator) {
                var errors = validator.numberOfInvalids();
                if (errors) {                    
                    validator.errorList[0].element.focus();
                }
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

loginModule.controller('LoginController', function($scope, $rootScope,
        LoginModel, $window) {
    /*
     * 初期表示 <pre> 対応するJSPのng-init属性経由でcallされる </pre>
     */
    $scope.init = function(model) {
        // Model(画面項目)の初期化
        $scope.model = LoginModel;
        $scope.model.setup(model);
    };

    // login action
    $scope.submit = function() {
        $scope.model.submit(getContextPath() + '/tlogin/logon', function(data) {
            // 画面遷移する
            if (data.message != '') {
                $rootScope.launch('error', Messages.getMessage('vn.skyfire.cloud.messages.title.check.error'),
                                                data.message, {size : 'sm'});
                return;
            }else{
                sessionStorage.setItem("userName", data.userName);
                $window.location = 'ptltodolist';
            }
        });
    };

    // redirect to reset password page
    $scope.resetPassword = function() {
        $window.location = 'PwdReset';
    };
});
