/**
* Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */
/**
 *
 * @version $Revision: 1.0 $ $Date: 2014/05/30 $
 * @author : Quang-Thien
 */

'use strict';

var commonModule = angular.module('commonModule', ['paragonApp', 'dialogs.main', 'daterangepicker']);

commonModule.factory('BaseModel', function ($rootScope) {

    var model = function () {

    };

    model.prototype.submitStatus = false;

    model.getInstance = function () {
        return new model();
    };

    /*
     * submit中かを取得する
     */
    model.prototype.isSubmitStatus = function () {
        return this.submitStatus;
    };

    /*
     * モデルをsubmitする <pre> 第1引数：サービスのURL 第2引数：サービスに渡すパラメータ or
     * サービスに渡すパラメータが不要の場合、コールバック関数 第3引数：コールバック関数 or サービスに渡すパラメータが不要の場合、指定不要
     * </pre>
     */
    model.prototype.submitModel = function () {

        var that = this;

        var params = {
            action: arguments[0]
        };

        var callback;

        that.submitStatus = true;

        switch (arguments.length) {
            case 2:
                callback = arguments[1];
                params.params = {};
                break;
            case 3:
                callback = arguments[2];
                params.params = arguments[1];
                break;
        }
        ;

        params.callback = function (data) {

            that.submitStatus = false;
            callback(data);
        };

        $rootScope.$broadcast('doPost', params);
    };

    return model;
});

commonModule.config(['dialogsProvider'/*,'$translateProvider'*/, function (dialogsProvider/*,$translateProvider*/) {
    dialogsProvider.useBackdrop('static');
    dialogsProvider.useEscClose(false);
    dialogsProvider.useCopy(false);
}]);

commonModule.run(['$templateCache', function ($templateCache) {
    $templateCache.put('/dialogs/custom.html', '<div class="modal-header"><button type="button" class="close" ng-click="no()">&times;</button><h4 class="modal-title"><span class="glyphicon glyphicon-star"></span> User\'s Name{param}</h4></div><div class="modal-body"><ng-form name="nameDialog" novalidate role="form"><div class="form-group input-group-lg" ng-class="{true: \'has-error\'}[nameDialog.username.$dirty && nameDialog.username.$invalid]"><label class="control-label" for="course">Name:</label><input type="text" class="form-control" name="username" id="username" ng-model="user.name" ng-keyup="hitEnter($event)" required><span class="help-block">Enter your full name, first &amp; last.</span></div></ng-form></div><div class="modal-footer"><button type="button" class="btn btn-default" ng-click="cancel()">Cancel</button><button type="button" class="btn btn-primary" ng-click="save()" ng-disabled="(nameDialog.$dirty && nameDialog.$invalid) || nameDialog.$pristine">Save</button></div>');
    $templateCache.put('/dialogs/custom2.html', '<div class="modal-header"><button type="button" class="close" ng-click="no()">&times;</button><h4 class="modal-title"><span class="glyphicon glyphicon-star"></span> Custom Dialog 2 </h4></div><div class="modal-body"><label class="control-label" for="customValue">Custom Value:</label><input type="text" class="form-control" id="customValue" ng-model="{param}" ng-keyup="hitEnter($event)"><span class="help-block">Using "dialogsProvider.useCopy(false)" in your applications config function will allow data passed to a custom dialog to retain its two-way binding with the scope of the calling controller.</span></div><div class="modal-footer"><button type="button" class="btn btn-default" ng-click="done()">Done</button></div>');
}]);

commonModule.controller('customDialogCtrl', function ($scope, $modalInstance, data) {
    //-- Variables --//
    $scope.user = { name: '' };
    //-- Methods --//
    $scope.cancel = function () {
        $modalInstance.dismiss('Canceled');
    }; // end cancel
    $scope.save = function () {
        $modalInstance.close($scope.user.name);
    }; // end save
    $scope.hitEnter = function (evt) {
        if (angular.equals(evt.keyCode, 13) && !(angular.equals($scope.user.name, null) || angular.equals($scope.user.name, '')))
            $scope.save();
    };
    $scope.no = function () {
        $modalInstance.dismiss('no');
    }; // end close
}); // end controller(customDialogCtrl)

commonModule.controller('customDialogCtrl2', function ($scope, $modalInstance) {
    $scope.data = {
        alertMessage: '',
        className: '',
        showAlert: false,
        showButton: false,
        link: ''
    };
    //-- Methods --//
    $scope.done = function () {
        $modalInstance.close($scope.data);
    }; // end done
    $scope.no = function () {
        $modalInstance.dismiss('no');
    }; // end close
});

commonModule.controller('commonCtrl', function ($scope, $rootScope, $http, $window, $filter, dialogs, $location) {
    // Loading when call service

    $scope.$on('themGioHang', function (event, data) {
        $scope.themGioHang(data.params);
    });

    $scope.themGioHang = function (sanpham) {
        var sessionGioHang = angular.fromJson(sessionStorage.getItem("GioHang"));
        if (sessionGioHang == null) {
            sessionGioHang = [];
            sessionGioHang.push(sanpham);
            sessionStorage.setItem("GioHang", JSON.stringify(sessionGioHang));
        } else {
            if (!ValidateUtil.isValidTextEmpty(sanpham.masanpham)) {
                var demSanPham = 0;
                console.log(sessionGioHang);
                sessionGioHang.forEach(function (item) {
                    if (item.masanpham == sanpham.masanpham) {
                        item.soluong += 1;
                    } else {
                        demSanPham++;
                    }
                });
                if (demSanPham == sessionGioHang.length) {
                    sessionGioHang.push(sanpham);
                }
                sessionStorage.setItem("GioHang", JSON.stringify(sessionGioHang));
                $window.location = "giohang";
            } else {
                $rootScope.launch('errorWarning', "Giỏ Hàng", "Thêm Sản Phẩm Không Thành Công", { size: 'sm' });
            }
        }
    };


    $rootScope.setLoading = function (loading) {
        $scope.isLoading = loading;
    };

    $rootScope.launch = function (which, header, msg, opts) {
        switch (which) {
            case 'error':
                dialogs.error(header, msg, opts);
                break;
            case 'errorWarning':
                dialogs.errorWarning(header, msg, opts);
                break;
            case 'wait':
                dialogs.wait(undefined, undefined, _progress);
                _fakeWaitProgress();
                break;
            case 'notify':
                dialogs.notify(header, msg, opts);
                break;
            case 'success':
                dialogs.success();
                break;
            case 'confirm':
                var dlg = dialogs.confirm();
                dlg.result.then(function (btn) {
                    $scope.confirmed = 'You confirmed "Yes."';
                }, function (btn) {
                    $scope.confirmed = 'You confirmed "No."';
                });
                break;
            case 'custom':
                var dlg = dialogs.create('custom', 'customDialogCtrl', {}, 'sm');
                dlg.result.then(function (name) {
                    $scope.name = name;
                }, function () {
                    if (angular.equals($scope.name, ''))
                        $scope.name = 'You did not enter in your name!';
                });
                break;
            case 'custom2':
                dialogs.create('/dialogs/custom2.html', 'customDialogCtrl2', param, 'sm');
                break;
        }
    }; // end launch


    // POSTリクエストのイベントを監視する。
    $scope.$on('doPost', function (event, data) {

        // Submit中かを制御するプロパティが無ければパラメーターに追加する。
        if (!data.params) {
            data.params = {
                isSubmitted: false
            };
        } else if (!data.params.hasOwnProperty('isSubmitted')) {
            data.params.isSubmitted = false;
        }

        $scope.doPost(data.action, data.params, data.callback);
    });

    /*
     * JSON形式でPOSTリクエストを発行する。
     */
    $scope.doPost = function (action, params, callbackFn) {

        $rootScope.setLoading(true);

        // aタグのhref属性に#が設定されていた場合、除去する。
        var location =
            /#$/.test($window.location) ? $window.location.toString().slice(0, -1) : $window.location
                .toString();

        // URLの末尾がスラッシュの場合、除去する。
        if (/\/$/.test(location)) {
            location = location.slice(0, -1);
        }

        // ベースのURLを取得(http://{hostname}/{context-root}/)
        location = location.slice(0, location.lastIndexOf("/") - 5);

        // $httpサービスに渡すパラメータ編集
        //url: $window.location.origin + "/" + action,
        var httpParams = {
            method: 'POST',
            url: $window.location.origin + "/" + action,
            data: params,
            enctype: 'multipart/form-data',
            processData: true,  // tell jQuery not to process the data
            contentType: true   // tell jQuery not to set contentType
        };

        if (params.isSubmitted) {
            // Submit中の場合、処理を終了する。
            return;
        } else {
            // ここでパラメーターのisSubmittedプロパティをtrueに変更すると、
            // 今後、同一画面から当関数をcallされた場合は画面から渡されたModelにisSubmittedプロパティが保持される。
            params.isSubmitted = true;
        }

        // HTTPリクエストするパラメータからisSubmittedプロパティを削除する(HTTPステータスコード400(Bad Request)対策)
        delete httpParams.data.isSubmitted;

        // 次に実行する$httpサービスのコールバック関数内で参照したいため、パラメーターをスコープオブジェクトで保持する。
        $scope.rawParams = params;

        var actionStartDate = new Date();
        httpParams.actionStartDate = actionStartDate;
        console.log('[ACTION   START] ' + $filter('date')(actionStartDate, 'yyyy-MM-dd HH:mm:ss.sss') + ': ' + httpParams.url);

        // $httpサービスでPOSTリクエストを発行する。
        $http(httpParams).success(function (data, status, headers, config) {

            // パラメーターをスコープオブジェクトから削除する。
            delete $scope.rawParams.isSubmitted;

            var actionEndDate = new Date();
            console.log('[ACTION   END  ] ' + $filter('date')(actionEndDate, 'yyyy-MM-dd HH:mm:ss.sss') + ': ' + config.url + ' [' + (actionEndDate - config.actionStartDate) + 'ms]');

            var callbackStartDate = new Date();
            console.log('[CALLBACK START] ' + $filter('date')(callbackStartDate, 'yyyy-MM-dd HH:mm:ss.sss') + ': ' + config.url);

            // コールバック実行
            callbackFn(data);

            var callbackEndDate = new Date();
            console.log('[CALLBACK END  ] ' + $filter('date')(callbackEndDate, 'yyyy-MM-dd HH:mm:ss.sss') + ': ' + config.url + ' [' + (callbackEndDate - callbackStartDate) + 'ms]');
            $rootScope.setLoading(false);
        }).error(function (data) {

            // パラメーターをスコープオブジェクトから削除する。
            delete $scope.rawParams.isSubmitted;

            // HTTPステータスコードが4xx、5xxの場合、エラー画面に遷移する。
            //$window.location = getContextPath() + '/error';
            $rootScope.setLoading(false);
            //$rootScope.showBlockAlert(data);
        });

        // 画面が操作されたら「ユーザーが操作したイベント」を発火する。 このイベントは共通ヘッダーによって検知される。
        $rootScope.$broadcast('UserOperated');
    };

    /**
     * 数値をカンマ区切りで表示する
     *
     * @param value
     * @returns
     */
    $scope.formatNumber = function (value) {
        if (value == null)
            return null;
        return value.toString().replace(/([\d]+?)(?=(?:\d{3})+$)/g,
            function (t) {
                return t + ',';
            });
    };

    /**
     * カンマ付数値からカンマを除外する
     *
     * @param value
     * @returns
     */
    $scope.unformattedNumber = function (value) {
        if (value == null)
            return null;
        var text = value.toString().replaceAll(',', '');
        debugger;
        return Number(text);
    };

    /**
     * 価格を計算する
     *
     * @param unitPrice
     *            単価
     * @param amount
     *            数量
     * @param discount
     *            割引
     * @returns {Number} 価格
     */
    $scope.rowCalc = function (unitPrice, amount, discount) {
        var sum = unitPrice * amount * (1 - discount / 100);
        // 四捨五入
        sum = Math.round(sum);
        return sum;
    };

    /**
     * 価格を計算する
     *
     * @param itemPrice
     *            単価
     * @param itemSum
     *            数量
     * @returns {Number} 価格
     */
    $scope.calcPrice = function (itemPrice, itemSum) {
        var sum = itemPrice * itemSum;
        // 四捨五入
        sum = Math.round(sum);
        return sum;
    };

    /**
     *
     */
    $rootScope.calcItemTax = function (itemPrice, itemSum, taxRate, taxType, rounding) {
        var tax = 0;
        var round = Math.pow(10, rounding);
        if (!ValidateUtil.isValidTextEmpty(taxType)) {
            if (taxType == 0) {
                //tax = itemPrice * itemSum * taxRate / (taxRate + 100);
                tax = Math.round(itemPrice * itemSum * taxRate / (taxRate + 100) * round) / round;
            } else if (taxType == 1) {
                //tax = itemPrice * itemSum * taxRate / 100;
                tax = Math.round(itemPrice * itemSum * taxRate / 100 * round) / round;
            } else {
                tax = 0;
            }
        }
        //console.log(rounding);
        //console.log(Math.pow(10, rounding));
        //console.log("tax :" + tax);
        return tax;
    };

});
