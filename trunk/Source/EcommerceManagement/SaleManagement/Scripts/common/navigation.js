/**
* Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */
/**
 *
 * @version $Revision: $ $Date: $
 * @author : Quang-Thien
 */

'use strict';

var navigation = angular.module('navigationModule', [ 'commonModule', 'paragonApp' ]);

navigation.factory('NavigationModel', [ 'BaseModel', '$rootScope', function(BaseModel, $rootScope) {

    var model = BaseModel.getInstance();

    model.hidden = {
        navigationLoaded : false
    };

    return model;
} ]);

navigation.controller('navigationCtrl', function($scope, $rootScope, $http, $window, NavigationModel) {

    $scope.model = NavigationModel;

    $scope.init = function(model){

        $scope.oneAtATime = true;

        $scope.$on("NAVIGATION#navigationLoaded", function(evt, param) {
            $scope.model.hidden.navigationLoaded = true;
            //$scope.searchCompanyList();
        });

        setTimeout(function() {
            $scope.searchCompanyList();
        });

        $scope.searchCompanyList = function(param) {
            $rootScope.$broadcast('doPost', {
                action : 'navigation/getCustomerList',
                params : {},
                callback : function(result) {
                    $scope.customerList = result.customerList;
                    $scope.projectList = result.projectList;
                }
            });
        };

        $scope.goToSfaProjectList = function(param) {
            var params = {
                    custCd : param.custCd,
                    custName : param.custName,
                    connectionStatus : param.connectionStatus
            };
            sessionStorage.setItem("projectCustItemInfo", JSON.stringify(params));
            $window.location = "SfaProjectList";
        };

        $scope.goToSfaProjectControl = function(param) {
            var params = {
                    'add' : true,
                    'edit' : true,
                    'change' : false,
                    'copy' : false,
                    'direct' : false,
                    projectSno : param.projectSno,
                    projectName : param.projectName
            };
            sessionStorage.setItem("projectItemControl", JSON.stringify(params));
            var customerParam = {
                    custCd : param.custCd,
                    custName : param.custName,
                    connectionStatus : param.connectionStatus
            };
            sessionStorage.setItem("projectCustItemInfo", JSON.stringify(customerParam));
            $window.location = "SfaProjectControl";
        };

        $scope.status = {
                isFirstOpen: true,
                isFirstDisabled: false
        };
    };

    $scope.init();

});