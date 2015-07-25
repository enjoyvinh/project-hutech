var app = angular.module('indexApp', []);

app.controller('downloadCtr', function($scope, $http){
	$scope.exportPdf = function() {
		window.location.href = "exportPdf";
	};
	$scope.exportCsv = function() {
		window.location.href = "exportCsv";
	};
});