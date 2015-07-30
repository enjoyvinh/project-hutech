/**
 * Copyright(c) Skyfire Team - 12LDTHC2 - HUTECH
 */

'use strict';
var QuanLyTrangChuModule = angular.module('QuanLyTrangChuModule', [
		'commonModule', 'paragonApp', 'ui.bootstrap',
		'dialogs.main', 'QuanLyHeaderModule', 'QuanLyMenuModule']);

QuanLyTrangChuModule.factory('QuanLyTrangChuModel', ['BaseModel',
		'$rootScope', function (BaseModel, $rootScope) {

		    var model = BaseModel.getInstance();

		    model.form = {
		        thongkehethong: {
		            tongcuahang: 0,
		            tongsanpham: 0,
		            tongkhachhang: 0,
		            tongluotdanhgiabinhluan: 0,
		        },
		        bieudobanhang: {
		            chartMonth: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
		            chartGiaoDichThangCong: [],
		            chartGiaoDichThatBai: [],
		        },
		        danhgia: {
		            phantramtonggiatritoansan: 0,
		            tonggiatritoansan: 0,
		            phantramkhoiluonggiaodich: 0,
		            khoiluonggiaodich: 0,
		            phantramtonggiatrigiaodich: 0,
		            tonggiatrigiaodich: 0,
		            phantram: 0,
		            tonggiatri: 0,
		        },
		    };

		    return model;

		}]);

QuanLyTrangChuModule.controller('QuanLyTrangChuControl', function ($rootScope,
		$scope, $http, $window, $location, dialogs, QuanLyTrangChuModel) {

    //$rootScope.setLoading(true);

    $scope.model = QuanLyTrangChuModel;

    $scope.salesChartOptions = {
        //Boolean - If we should show the scale at all
        showScale: true,
        //Boolean - Whether grid lines are shown across the chart
        scaleShowGridLines: true,
        //String - Colour of the grid lines
        scaleGridLineColor: "rgba(0,0,0,.05)",
        //Number - Width of the grid lines
        scaleGridLineWidth: 2,
        //Boolean - Whether to show horizontal lines (except X axis)
        scaleShowHorizontalLines: true,
        //Boolean - Whether to show vertical lines (except Y axis)
        scaleShowVerticalLines: true,
        //Boolean - Whether the line is curved between points
        bezierCurve: true,
        //Number - Tension of the bezier curve between points
        bezierCurveTension: 0,
        //Boolean - Whether to show a dot for each point
        pointDot: true,
        //Number - Radius of each point dot in pixels
        pointDotRadius: 3,
        //Number - Pixel width of point dot stroke
        pointDotStrokeWidth: 1,
        //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
        pointHitDetectionRadius: 50,
        //Boolean - Whether to show a stroke for datasets
        datasetStroke: true,
        //Number - Pixel width of dataset stroke
        datasetStrokeWidth: 2,
        //Boolean - Whether to fill the dataset with a color
        datasetFill: true,
        //String - A legend template
        legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].lineColor%>\"></span><%=datasets[i].label%></li><%}%></ul>",
        //Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
        maintainAspectRatio: false,
        //Boolean - whether to make the chart responsive to window resizing
        responsive: true
    };
    $scope.salesChartData = {};

    $scope.doThongKe = function () {
        

        $rootScope.$broadcast('doPost', {

            action: 'api/API_HeThong_Dashboard/doDashboard',
            params: {},
            callback: function (result) {
                if (!ValidateUtil.isValidTextEmpty(result.SUCCESS)) {
                    $scope.model.form.thongkehethong.tongcuahang = result.tongcuahang;
                    $scope.model.form.thongkehethong.tongsanpham = result.tongsanpham;
                    $scope.model.form.thongkehethong.tongkhachhang = result.tongkhachhang;
                    $scope.model.form.thongkehethong.tongluotdanhgiabinhluan = result.tongluotdanhgiabinhluan;
                    $scope.model.form.bieudobanhang.chartGiaoDichThangCong = JSON.parse("[" + result.chartGiaoDichThangCong + "]");
                    $scope.model.form.bieudobanhang.chartGiaoDichThatBai = JSON.parse("[" + result.chartGiaoDichThatBai + "]");

                    $scope.salesChartData = {
                        labels: $scope.model.form.bieudobanhang.chartMonth,
                        datasets: [
                          {
                              label: "Lượt Giao Dịch Thành Công",
                              fillColor: "transparent",
                              strokeColor: "rgb(0,103,57)",
                              pointColor: "rgb(243,156,18)",
                              pointStrokeColor: "rgb(0,103,57)",
                              pointHighlightFill: "rgb(0,103,57)",
                              pointHighlightStroke: "rgb(243,156,18)",
                              data: $scope.model.form.bieudobanhang.chartGiaoDichThangCong
                          },
                          {
                              label: "Lượt Giao Dịch Thất Bại",
                              fillColor: "transparent",
                              strokeColor: "rgb(155,0,3)",
                              pointColor: "rgb(0,183,227)",
                              pointStrokeColor: "rgb(155,0,3)",
                              pointHighlightFill: "rgb(155,0,3)",
                              pointHighlightStroke: "rgb(0,183,227)",
                              data: $scope.model.form.bieudobanhang.chartGiaoDichThatBai
                          },
                        ]
                    };

                } else {
                    $window.location = '/Error/ServerError';
                }            
            }
        });
    };

    setTimeout(function () {
        // Get context with jQuery - using jQuery's .get() method.
        $scope.salesChartCanvas = $("#salesChart").get(0).getContext("2d");
        // This will get the first returned node in the jQuery collection.
        $scope.salesChart = new Chart($scope.salesChartCanvas);
        //Create the line chart
        $scope.salesChart.Line($scope.salesChartData, $scope.salesChartOptions);
    }, 1000);

    $scope.init = function (model) {
        $scope.doThongKe();
    };

    $scope.init($scope.model);
});