/**
 * 見積一覧
 *
 * $Revision:  $  $Date:  $
 */
var model = function(data){

	//見積日From
	this.fromDate = empty2null(data.fromDate());

	//見積日To
	this.toDate = empty2null(data.toDate());

	//顧客名
	this.custName = data.custName();
	//件名
	this.estimateName = data.estimateName();

	//見積ステータス
	this.selectedStatus = data.selectedStatus();

	//帳票ステータス
	this.selectedReport = data.selectedReport();

};
// ViewModel定義
var viewModel = function(data) {
	var self = this;

	//見積日From
	self.fromDate = ko.observable(data.fromDate);
	//見積日To
	self.toDate = ko.observable(data.toDate);
	//顧客名
	self.custName = ko.observable(data.custName);
	//件名
	self.estimateName = ko.observable(data.estimateName);

	//見積ステータス
	self.selectedStatus = ko.observableArray(data.selectedStatus);

	//帳票ステータス
	self.selectedReport = ko.observable(data.selectedReport);

	// 検索ボタンイベント
	self.searchClick = fnSearchClick;
	// 帳票出力ボタンイベント
	self.exportClick = fnExportClick;
};



//検索処理
function fnSearchClick(obj, e) {

	var request = new model(obj);

	$.fn.callservice({
		url : 'estimate-list/search',
		validationtarget : '.grp-a',
		request : request,
		autodisabled : true,
		beforeSend : function(jqXHR, settings) {
			clearFilterAndRow($('#result').dataTable());
			//データはありませんを空文字に置き換える
			$('.dataTables_empty').text('');
		},
		success : function(response) {
			if(!Array.isArray(response) || response.length < 1)
				clearFilterAndRow($('#result').dataTable());
            //$timeout(function(result) {
			$.each(response, function() {
				$('#result').dataTable().fnAddData(
						[
								createEstimateLink(this.estimateSno),
								this.estDate,
								this.custCd,
								this.custName,
								this.estimateName,
								this.sumPrice,
								this.salesStaffName,
								convDueDate(this.dueDate, this.dueDateSub),
								createRcvLink(this.rcvSno),
								(function(code) {
									var text = '';
									$.each(statusDatasource,
											function(i, value) {
												if (value.code === code) {
													text = value.name;
													return false;
												}
											});
									return text;
								})(this.documentStatus) ]);
			    });
            //}, 2000000);
            }
	});
};

function createEstimateLink(estimateSno){
	if(estimateSno == null)
		return "";
	return "<a href='estimate?st=0&no=" + estimateSno + "'>" + estimateSno + "</a>";
}

function createRcvLink(rcvSno){
	if(rcvSno == null)
		return "";
	return "<a href='order?st=0&no=" + rcvSno + "'>" + rcvSno + "</a>";
}

function convDueDate(dueDate, dueDateSub){
	if(dueDate != null)
		return dueDate;
	else if(dueDateSub != null)
		return dueDateSub;
	return "";
}

// 帳票出力処理
function fnExportClick(obj, e) {
	var request = new model(obj);

	$.fn.callservice({
		url : 'estimate-list/export',
		validationtarget : '.grp-b',
		request : request,
		autodisabled : true,
		disableselector:'#btnExport',
		beforeSend : function(jqXHR, settings) {
			//clearFilterAndRow($('#result').dataTable());
		},
		////サーバサイドValidationをチェックする場合は、fnValidtionを上書きする
		//fnValidate : function() { return true; },
		success : function(response) {
			//生成処理後にダウンロードする場合は、以下の通り
			$('#ticket').val(response.ticket);
			$('#downloadViewDto').submit();
		}
	});
};


$(document).ready(
		function() {

	    	// 画面とViewModelをバインドする
			var model = new viewModel(datasource);
			 ko.applyBindings(model, $('.exex-page-contents')[0]);

			// 見積ステータス選択
			var ddlStatus = $('#txtStatus').magicSuggest({

				data : statusDatasource,
				cls : 'suggest-default',
				displayField : 'name',
				valueField : 'code',
				sortDir : 'desc',
				highlight : false,
				allowFreeEntries : false,
				selectionStacked : true,
				expandOnFocus : true,
				preselectSingleSuggestion : false,
				resultAsString : false,
				typeDelay : 0,
				maxSelection : 5,
				hideTrigger : false,
				suggestField1 : 'name',
				value : model.selectedStatus(),
				maxSelectionRenderer : function(a) {
					return '';
				},
				emptyText : $('#txtStatus')[0].placeholder
			});

			// 選択変更
			$(ddlStatus).on('selectionchange',
					function(event, combo, selection) {
						model.selectedStatus.removeAll();
						$(selection).each(function() {
							model.selectedStatus.push(this.code);
						});
					});

			// 帳票選択---------------------------------------------------------
			var selectValOfReport = parseInt($('#selectedReport').val());

			// 帳票種別選択
			var ddlReport = $('#txtReport').magicSuggest({
				data : reportDatasource,
				cls : 'suggest-default',
				displayField : 'name',
				valueField : 'code',
				sortDir : 'desc',
				highlight : false,
				width : 200,
				allowFreeEntries : false,
				preselectSingleSuggestion : false,
				resultAsString : false,
				required : false,
				typeDelay : 0,
				maxSelection : 1,
				hideTrigger : false,
				suggestField1 : 'name',
				value : selectValOfReport,
				maxSelectionRenderer : function(a) {
					return '';
				},
				emptyText : $('#txtReport')[0].placeholder
			});

			// ステータスの選択変更
			$(ddlReport).on('selectionchange',
					function(event, combo, selection) {
						//単一選択の場合
						if(selection.length > 0)
							model.selectedReport(selection[0].code);
						else
							model.selectedReport(null);
					});

			// datatable定義----------------------------------------------------------
			var table = $("#result").dataTable({
				oLanguage : {
					sUrl : "data/" + language + "/dataTables.txt"
				},
				bPaginate : false,
				bProcessing : true,
				bAutoWidth : false,
				sDom : '<"top"if><"clear">',
				aoColumns : [
					 			{sType : "date-html", "sClass": "center"} //見積番号
					 			,{sType : "date-jp","sClass": "left", mRender : function(day) {return calculate_yyyymmdd(day);}} //見積日
					 			,{sType : "date-html", "sClass": "left" , mRender : function(val) {return formatDirectInputCode(val);}} //顧客ID
					 			,{sClass: "left"} //顧客名
					 			,{sClass: "left"} //件名
					 			, {sType : "numeric-comma","sClass": "right",mRender : function(num) {return toFormatedNumber(num);}} //合計金額
					 			,{sClass: "left"} //担当者
					 			,{sClass: "left"} //有効期限
					 			,{sType : "date-html", "sClass": "center"} //受注
					 			,{sClass: "center"} //ステータス
					 		]
			});
			// ToolTip初期化
			//loadTips();

			// 遅延実行で検索結果を取得し、datatableに表示する
			$(function() {
				setTimeout(function() {
					$('#btnSearch').click();
				}, 500);
			});
		});



