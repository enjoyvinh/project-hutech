/**
 * 見積入力
 *
 * $Revision:  $  $Date:  $
 */

/*----------------------------------------------------------------------------------------
 * Model定義
 *------------------------------------------------------------------------------------------
 */

/**
 * 見積明細行モデル
 * ※ModelとViewModelに差異が無いので、ViewModelは省略する
 */
var estimateRowModel = function(data, isKo) {
		// 行番号
		this.lineNo = ko.observable(isKo ? data.lineNo() : data.lineNo);
		// 品目コード
		this.itemCd = ko.observable(isKo ? data.itemCd() : data.itemCd);
		// 品目名
		this.itemName = ko.observable(isKo ? data.itemName() : data.itemName);
		// 品目直接入力
		this.itemDirectInput = ko.observable(this.itemCd() == "-1");

		// 単価
		this.itemPrice = ko.observable(isKo ? data.itemPrice() : data.itemPrice);
		// 単位コード
		this.itemUnit = ko.observable(isKo ? data.itemUnit() : data.itemUnit);
		// 単位名
		this.itemUnitName = ko.observable(isKo ? data.itemUnitName() : data.itemUnitName);
		// 数量
		this.itemSum = ko.observable(isKo ? data.itemSum() : data.itemSum);
		// 在庫数
		this.stock = ko.observable(isKo ? data.stock() : data.stock);
		// 税区分
		this.taxType = ko.observable(isKo ? data.taxType() : data.taxType);
		this.taxTypeName =ko.computed(
				function() {
					return getTaxStatusNm(this.taxType(), taxStatusDatasource);
				}, this);

		// 割引
		this.discountRate = ko.observable(isKo ? data.discountRate() : data.discountRate);
		// 価格
		this.price = ko.computed(
				function() {
					return rowCalc(this.itemPrice(), this.itemSum(), this.discountRate());
				}, this);

};

/**
 * 見積モデル（サーバに送信する)
 */
var estimateModel = function(data) {

	this.mode = data.mode();
	// 見積番号
	this.estimateSno = data.estimateSno();
	// 見積日
	this.estDate = empty2null(data.estDate());

	// 見積有効期限日
	this.dueDate = empty2null(data.dueDate());

	// 見積有効期限テキスト
	this.dueDateSub = data.dueDateSub();
	// 案件名
	this.projectName = data.projectName();
	// 案件コード
	this.projectSno = data.projectSno();
	// 見積書件名
	this.estimateName = data.estimateName();
	// 見積提出予定
	this.estPlanDate = data.estPlanDate();
	// 顧客コード
	this.custCd = data.custCd();
	// 顧客名
	this.custName = data.custName();
	// 部署コード
	this.custDeptCd = data.custDeptCd();
	// 部署名
	this.custDeptName = data.custDeptName();
	// 顧客担当者コード
	this.custOwnerCd = data.custOwnerCd();
	// 顧客担当者
	this.custOwnerName = data.custOwnerName();
	// 顧客敬称
	this.custTitleCd = data.custTitleCd();
	// 顧客敬称
	this.custTitle = data.custTitle();
	// 納入期限日
	this.delPlanDate = empty2null(data.delPlanDate());
	// 納入期限テキスト
	this.delPlanDateSub = data.delPlanDateSub();
	// 納入場所
	this.deliveryPoint = data.deliveryPoint();
	// 営業グループコード
	this.salesGroupCd = data.salesGroupCd();
	// 営業グループ名
	this.salesGroupName = data.salesGroupName();
	// 営業担当者コード
	this.salesStaffCd = data.salesStaffCd();
	// 営業担当者
	this.salesStaffName = data.salesStaffName();
	// 電話番号
	this.salesTel = data.salesTel();
	// FAX
	this.salesFax = data.salesFax();
	// 自社情報を印刷する
	this.outputCompanyFlag = data.outputCompanyFlag();
	// 営業情報を印刷する
	this.outputSalesFlag = data.outputSalesFlag();
	// 諸条件
	this.conditionNotes = data.conditionNotes();
	// 特記事項
	this.remark = data.remark();
	// 見積明細
	this.details = data.details();
	// 小計
	this.subTotal = data.subTotal();
	// 税合計
	this.sumTax = data.sumTax();
	// 税込合計金額
	this.sumPrice = data.sumPrice();
	// 文書ステータス
	this.documentStatus = data.documentStatus();
	this.documentStatusText = data.documentStatusText();
	// 最終更新者
	this.lastUpdUserName = data.lastUpdUserName();
	// 最終更新者コード
	this.lastUpdUser = data.lastUpdUser();
	// 最終更新日時
	this.lastUpdDate = data.lastUpdDate();

	//申請依頼情報
	this.apply = null;

	//制御情報
	this.commit = false;
	this.recodeNo = data.recodeNo();
	this.version = data.version();

};

/**
 * 見積破棄モデル（サーバに送信する)
 */
var estimateDeleteModel = function(data) {
	// 見積番号
	this.estimateSno = data.estimateSno();
	this.recodeNo = data.recodeNo();
	this.version = data.version();
};

var estimateCalcReqModel = function(data) {
	// 見積明細
	this.details = data;
};

/*----------------------------------------------------------------------------------------
 * ViewModel定義(画面用データ)
 *------------------------------------------------------------------------------------------
 */
/**
 * 見積入力表示モデル
 * data:サーバから受信したJSONデータ
 */
var estimateViewModel = function(data) {
	var self = this;

	this.convDetails = function(list){
		var result = new Array();
		if(list != null){
			for(var i=0; i < list.length; i++){
				var row = new estimateRowModel(list[i]);
				row.lineNo(i+1);
				result.push(row);
			}
		}
		return result;

	};

	this.infoMessage = ko.observable();

	this.mode = ko.observable(data.mode);
	// 見積番号
	this.estimateSno = ko.observable(data.estimateSno);
	// 見積日
	this.estDate = ko.observable(data.estDate);
	// 見積有効期限日
	this.dueDate = ko.observable(data.dueDate);
	// 見積有効期限テキスト
	this.dueDateSub = ko.observable(data.dueDateSub);
	// 案件名
	this.projectName = ko.observable(data.projectName);
	// 案件コード
	this.projectSno = ko.observable(data.projectSno);
	// 見積書件名
	this.estimateName = ko.observable(data.estimateName);
	// 見積提出予定
	this.estPlanDate = ko.observable(data.estPlanDate);
	// 顧客コード
	this.custCd = ko.observable(data.custCd);
	// 顧客名
	this.custName = ko.observable(data.custName);
	// 部署コード
	this.custDeptCd = ko.observable(data.custDeptCd);
	// 部署名
	this.custDeptName = ko.observable(data.custDeptName);
	// 顧客担当者コード
	this.custOwnerCd = ko.observable(data.custOwnerCd);
	// 顧客担当者
	this.custOwnerName = ko.observable(data.custOwnerName);
	// 顧客敬称
	this.custTitleCd = ko.observable(data.custTitleCd);
	// 顧客敬称
	this.custTitle = ko.observable(data.custTitle);
	// 納入期限日
	this.delPlanDate = ko.observable(data.delPlanDate);
	// 納入期限テキスト
	this.delPlanDateSub = ko.observable(data.delPlanDateSub);
	// 納入場所
	this.deliveryPoint = ko.observable(data.deliveryPoint);
	// 営業グループコード
	this.salesGroupCd = ko.observable(data.salesGroupCd);
	// 営業グループ名
	this.salesGroupName = ko.observable(data.salesGroupName);
	// 営業担当者コード
	this.salesStaffCd = ko.observable(data.salesStaffCd);
	// 営業担当者
	this.salesStaffName = ko.observable(data.salesStaffName);
	// 電話番号
	this.salesTel = ko.observable(data.salesTel);
	// FAX
	this.salesFax = ko.observable(data.salesFax);
	// 自社情報を印刷する
	this.outputCompanyFlag = ko.observable(data.outputCompanyFlag);
	// 営業情報を印刷する
	this.outputSalesFlag = ko.observable(data.outputSalesFlag);
	// 諸条件
	this.conditionNotes = ko.observable(data.conditionNotes);
	// 特記事項
	this.remark = ko.observable(data.remark);
	// 見積明細
	//this.details = ko.observableArray([new estimateRowModel(data.details[0])]);
	this.details = ko.observableArray(this.convDetails(data.details));
	// 小計
	this.subTotal = ko.observable(data.subTotal);
	// 税合計
	this.sumTax = ko.observable(data.sumTax);
	// 税込合計金額
	this.sumPrice = ko.observable(data.sumPrice);
	// 文書ステータス
	this.documentStatus = ko.observable(data.documentStatus);
	this.documentStatusText = ko.observable(data.documentStatusText);
	// 最終更新者
	this.lastUpdUserName = ko.observable(data.lastUpdUserName);
	// 最終更新者コード
	this.lastUpdUser = ko.observable(data.lastUpdUser);
	// 最終更新日時
	this.lastUpdDate = ko.observable(data.lastUpdDate);

	//行編集領域
	// 行番号
	this.lineNo = ko.observable(-1);
	// 品目コード
	this.itemCd = ko.observable();
	// 品目名
	this.itemName = ko.observable();
	// 品目直接入力
	this.itemDirectInput = ko.observable(true);
	// 単価
	this.itemPrice = ko.observable();
	// 単位コード
	this.itemUnit = ko.observable();
	// 単位名
	this.itemUnitName = ko.observable();
	// 数量
	this.itemSum = ko.observable();
	// 在庫数
	this.stock = ko.observable();
	// 税区分
	this.taxType = ko.observable();
	// 割引
	this.discountRate = ko.observable(0);
	// 価格
	this.price = ko.computed(
			function() {
				return rowCalc(this.itemPrice(), this.itemSum(), this.discountRate());
			}, this);


	this.recodeNo = ko.observable(data.recodeNo);

	this.version = ko.observable(data.version);


	this.msProject; // 案件サジェスト
	this.msCust; // 顧客サジェスト
	this.msCustDept; // 顧客部署サジェスト
	this.msUser; // 担当者サジェスト
	this.msTitle; // 敬称サジェスト
	this.msMyGroup; // 自社グループサジェスト
	this.msMyStaff; // 自社スタッフサジェスト
	this.msItem; // 品目サジェスト
	this.msUnit; //単位サジェスト

	/*----------------------------------------------------------------------------------------
	 * 画面イベント関数定義
	 *------------------------------------------------------------------------------------------
	 */
	/**
	 * 明細行削除
	 */
	this.removeRow = function(row) {
		self.details.remove(row);
		for (var i = 0; i < self.details().length; i++) {
			self.details()[i].lineNo( i + 1);
		}
		self.clearEditRow();
		//再計算
		calculate(self.details);
	};
	/**
	 * 明細行追加
	 */
	this.addRow = function(row) {
		//Validate
		var items = $('.grp-row');
		items.validate();
		if (!items.valid()) {
			return false;
		}
		var newRow = new estimateRowModel(row, true);
		newRow.lineNo(self.details().length + 1);
		self.details.push(newRow);
		self.clearEditRow();
		//再計算
		calculate(self.details);
	};

	/**
	 * 明細行更新
	 */
	this.updateRow = function(row) {
		var items = $('.grp-row');
		items.validate();
		if (!items.valid()) {
			return false;
		}

		for (var i = 0; i < self.details().length; i++) {
			if(row.lineNo() === self.details()[i].lineNo()){
				self.details()[i].lineNo(row.lineNo());
				self.details()[i].itemCd(row.itemCd());
				self.details()[i].itemName(row.itemName());
				self.details()[i].itemDirectInput(row.itemDirectInput());
				self.details()[i].itemPrice(row.itemPrice());
				self.details()[i].itemUnit(row.itemUnit());
				self.details()[i].itemUnitName(row.itemUnitName());
				self.details()[i].itemSum(row.itemSum());
				self.details()[i].stock(row.stock());
				self.details()[i].taxType(row.taxType());
				self.details()[i].discountRate(row.discountRate());
				break;
			}
		}
		self.clearEditRow();
		//再計算
		calculate(self.details);
	};

	/**
	 * 明細行選択イベント
	 */
	this.selectRow = function(row) {

		if(!row.itemDirectInput()){
			//品目マスタから選択している場合は、最新在庫数を取得する
			var request = row;
			$.fn.callservice({
				url : 'estimate/stock',
				request : request,
				autodisabled : true,
				beforeSend : function(jqXHR, settings) {
				},
				fnValidate: function(){
					return true;
				},
				success : function(response) {
					//在庫数量を更新
					self.stock(response.stock);
				}
			});
		}

		self.msItem.setDataAndValue(
				{itemCd: row.itemCd(), itemNm: row.itemName() , unitCd : row.itemUnit(), unitNm: row.itemUnitName()} );
		self.lineNo(row.lineNo());
		self.itemCd(row.itemCd());
		self.itemName(row.itemName());
		self.itemDirectInput(row.itemDirectInput());
		if(self.itemDirectInput())
			self.msUnit.enable();
		self.itemPrice(row.itemPrice());
		self.itemUnit(row.itemUnit());
		self.itemUnitName(row.itemUnitName());
		self.itemSum(row.itemSum());
		self.taxType(row.taxType());
		self.discountRate(row.discountRate());


	};

	/**
	 * クリアボタンイベント
	 */
	this.clearEditRow = function() {
		self.msItem.setDataAndValue(null);
		self.msUnit.setDataAndValue(null);
		self.msUnit.enable();
		self.lineNo(-1);
		self.clearItemGroup();
		self.taxType(1);
		self.itemSum(null);
		self.discountRate(0);
		clearErrorTips();
	};

	/**
	 * 編集ボタンイベント
	 */
	this.editClick = function(obj, e) {
		location.href = "estimate?st=3&no=" + this.estimateSno();
	};
	/**
	 * 複写ボタンイベント
	 */
	this.copyClick = function(obj, e) {
		location.href = "estimate?st=2&no=" + this.estimateSno();
	};

	/**
	 * 見積出力イベント
	 */
	this.exportClick = function(obj, e){
		var request = new estimateModel(this);

		$.fn.callservice({
			url : 'estimate/export',
			request : request,
			autodisabled : true,
			validationtarget : '.grp-save',
			disableselector:'#btnExport',
			beforeSend : function(jqXHR, settings) {
			},
			success : function(response) {
				//生成処理後にダウンロードする場合は、以下の通り
				$('#ticket').val(response.ticket);
				$('#downloadViewDto').submit();
			},
			fnUnsupportedError : function(error){
				setTableError(error);
			}

		});
	};

	/**
	 * 見積破棄イベント
	 */
	this.deleteClick = function(obj, e){
		var request = new estimateDeleteModel(self);

		$.fn.callservice({
			url : 'estimate/delete',
			request : request,
			validationtarget : '.grp-del',
			autodisabled : true,
			//disableselector:'#btnDelete',
			beforeSend : function(jqXHR, settings) {
			},
			success : function(response) {
				if(response != null){
					showPopupMessage(
						response.message
					);
					self.infoMessage(response.message);
					$('#pnlMain').hide();
					$('#pnlHeader').hide();
				}
			}
		});
	};

	/**
	 * 一時保存イベント
	 */
	this.tempSaveClick = function(obj, e){
		var request = new estimateModel(this);

		request.commit = true;

		$.fn.callservice({
			url : 'estimate/temp-save',
			request : request,
			autodisabled : true,
			validationtarget : '.grp-save',
			//disableselector:'#btnTempSave',
			beforeSend : function(jqXHR, settings) {
			},
			success : function(response) {
				if(response != null){
					showPopupMessage(
						response.message,
						function(){
							closePopupMessage();
							location.href = "estimate?st=0&no=" + response.estimateSno;
						}
					);
				}
			},
			complete : function(data) {

			},
			fnUnsupportedError : function(error){
				setTableError(error);
			}
		});
	};

	this.commitSave = function(request){
		$.fn.applyPopup({
			fnOk: function(data){
				//本処理のため、commit=trueとする。申請情報を添付する
				request.commit = true;
				request.apply = data;

				$.fn.callservice({
					url : 'estimate/save',
					request : request,
					autodisabled : true,
					validationtarget : '.grp-save',
					beforeSend : function(jqXHR, settings) {
					},
					success : function(response) {
						if(response != null){
							showPopupMessage(
								response.message,
								function(){
									closePopupMessage();
									location.href = "estimate?st=0&no=" + response.estimateSno;
								}
							);
						}
					},
					complete : function(data) {

					},
					fnUnsupportedError : function(error){
						setTableError(error);
					}

				});
			}
		});
	};

	/**
	 * 保存イベント
	 */
	this.saveClick = function(obj, e){
		var request = new estimateModel(this);

		//事前チェック処理のため、commit=falseとする
		request.commit = false;

		$.fn.callservice({
			url : 'estimate/save',
			request : request,
			autodisabled : true,
			validationtarget : '.grp-save',
			success : function(response) {
				if(response != null){
					console.log(request);
					self.commitSave(request);
				}
			},
			fnUnsupportedError : function(error){
				setTableError(error);
			}
		});
		};

	/**
	 * 再計算処理
	 * 計算ボタン無しで、明細データ変更のタイミング
	 */
	function calculate(data){

		var request = new estimateCalcReqModel(data);

		$.fn.callservice({
			url : 'estimate/calculate',
			request : request,
			autodisabled : true,
			disableselector:'#btnCalculate',
			beforeSend : function(jqXHR, settings) {
			},
			fnValidate: function(){
				return true;
			},
			success : function(response) {
				self.subTotal(response.subTotal);
				self.sumTax(response.sumTax);
				self.sumPrice(response.sumPrice);
			},
			fnUnsupportedError : function(error){
				setTableError(error);
			}
		});

	};

	/*----------------------------------------------------------------------------------------
	 * その他関数定義
	 *------------------------------------------------------------------------------------------
	 */
	function setTableError(error){
		var target = error.field;
		var rowIndex;
		var lineNo;
		if(target.lastIndexOf('details[', 0) === 0){
			rowIndex = target.substring(8, target.indexOf(']'));
			lineNo = parseInt(rowIndex) + 1;
			console.log("lineNo:" + lineNo);
			var row = $("#detailsTable tr").eq(lineNo);

			var field = target.split('.')[1];
			var rowItem = row.find('[field=' + field +']').first();
			addErrorTipsForElement(rowItem, error.message);
		}
	};

	/**
	 * 案件関連のデータをクリアする
	 */
	this.clearProjectGroup = function(){
		self.msCust.setDataAndValue(null);
		self.msCustDept.setDataAndValue(null);
		self.msUser.setDataAndValue(null);
		self.projectSno(null);
		self.projectName(null);
		self.custCd(null);
		self.custName(null);
		self.custDeptCd(null);
		self.custDeptName(null);
		self.custOwnerCd(null);
		self.custOwnerName(null);
	};
	/**
	 * 案件関連のデータをセットする
	 */
	this.setProjectGroup = function(data){
		//Suggestの変数名は異なるので注意

		if(data.custCd != null)
			self.msCust.setDataAndValue(data);
		else
			self.msCust.setDataAndValue(null);

		if(data.deptCd != null)
			self.msCustDept.setDataAndValue(data);
		else
			self.msCustDept.setDataAndValue(null);

		if(data.custStaffCd != null)
			self.msUser.setDataAndValue(data);
		else
			self.msUser.setDataAndValue(null);


		self.projectSno(data.projectCd);
		self.projectName(data.projectNm);
		self.custCd(data.custCd);
		self.custName(data.custNm);
		self.custDeptCd(data.deptCd);
		self.custDeptName(data.deptNm);
		self.custOwnerCd(data.custStaffCd);
		self.custOwnerName(data.custStaffNm);
	};

	/**
	 * 行編集領域の品名関連のデータをクリアする
	 */
	this.clearItemGroup = function(){
		self.msUnit.setDataAndValue(null);
		self.msUnit.enable();
		self.itemCd(null);
		self.itemName(null);
		self.itemDirectInput(true);
		self.itemPrice(null);
		self.itemUnit(null);
		self.itemUnitName(null);
		self.stock(null);
		self.taxType(null);
	};

	/**
	 * 行編集領域の品名関連のデータをセットする
	 */
	this.setItemGroup = function(data){
		if(data.unitCd != null)
			self.msUnit.setCodeAndName(data.unitCd, data.unitNm);
		else
			self.msUnit.setCodeAndName(null);

		self.msUnit.disable();
		self.itemCd(data.itemCd);
		self.itemName(data.itemNm);
		self.itemDirectInput(data.itemDirectInput);
		self.itemPrice(data.unitPrice);
		self.itemUnit(data.unitCd);
		self.itemUnitName(data.unitNm);
		self.stock(data.stock);
		self.taxType(data.taxStatus);
	};

	//編集ボタン表示
	this.isVisibleBtnEdit = function(){
		return self.mode() < 1
			&& self.documentStatus() != "03";
	};

	//複写ボタン表示
	this.isVisibleBtnCopy = function(){
		return self.mode() < 1;
	};

	//破棄ボタン表示
	this.isVisibleBtnDelete = function(){
		return self.mode() > 2
		&& self.documentStatus() != "03";

	};

	//一時保存ボタン表示
	this.isVisibleBtnTempSave = function(){
		return self.mode() > 0
			&& self.documentStatus() == "01";

	};

	//保存ボタン表示
	this.isVisibleBtnSave = function(){
		return self.mode() > 0
			&& self.documentStatus() == "01";

	};

};


/*----------------------------------------------------------------------------------------
 * 初期表示処理
 *------------------------------------------------------------------------------------------
 */
$(document)
		.ready(
				function() {
					//-------------------------------------------------------------
					// ViewModel初期化
					//-------------------------------------------------------------
					var model = new estimateViewModel(datasource);
					 ko.applyBindings(model, $('.exex-page-contents')[0]);

					//-------------------------------------------------------------
					// サジェスト初期化
					//-------------------------------------------------------------
					model.msProject = $('#txtProject').projectSuggest({});
					model.msCust = $('#txtCust').custSuggest({});
					model.msCustDept = $('#txtCustDept').custDeptSuggest({
						exPreAjax : function(ms) {
							this.setDataUrlParams({
								custCd : model.custCd()
							});
							return true;
						}
					});
					model.msUser = $('#txtCustOwner').custUserSuggest({
						exPreAjax : function(ms) {
							this.setDataUrlParams({
								custCd : model.custCd(),
								deptCd : model.custDeptCd()
							});
							return true;
						}
					});
					model.msTitle = $('#txtCustTitle').custTitleSuggest({});

					model.msMyGroup = $('#txtSalesGroup').myGroupSuggest({
					});
					model.msMyStaff = $('#txtSalesStaff').myStaffSuggest({
						exPreAjax : function(ms) {
								this.setDataUrlParams({
									groupCd : model.salesGroupCd()
								});
							return true;
						}
					});
					model.msItem = $('#txtItem').itemSuggest({});
					model.msUnit = $('#txtUnit').unitSuggest({});

					//-------------------------------------------------------------
					// サジェスト初期値セット
					//-------------------------------------------------------------
					if (model.msProject != null && model.projectName() != null) {
						model.msProject.setCodeAndName(model.projectSno(), model.projectName());
					}
					if (model.msCust != null && model.custName() != null)
						model.msCust.setCodeAndName(model.custCd(), model.custName());

					if (model.msCustDept != null && model.custDeptName() != null)
						model.msCustDept.setCodeAndName(model.custDeptCd(), model.custDeptName());

					if (model.msUser != null && model.custOwnerName() != null)
						model.msUser.setCodeAndName(model.custOwnerCd(), model.custOwnerName());

					if (model.msTitle != null && model.custTitle() != null)
						model.msTitle.setCodeAndName(model.custTitleCd(), model.custTitle());

					if (model.msMyGroup != null && model.salesGroupCd() != null)
						model.msMyGroup.setCodeAndName(model.salesGroupCd(), model.salesGroupName());

					if (model.msMyStaff != null && model.salesStaffCd() != null)
						model.msMyStaff.setCodeAndName(model.salesStaffCd(), model.salesStaffName());

					//-------------------------------------------------------------
					// サジェスト選択イベント
					//-------------------------------------------------------------
					// 案件サジェスト選択変更
					$(model.msProject)
							.on(
									'selectionchange',
									function(event, combo, selection) {
										var data = selection[0] != null ? selection[0]: null;
										console.log("msProject-freeInput:" + this.isFreeEntry());
										if(data != null){
											if(!this.isFreeEntry()){
												//選択入力ならば
												model.setProjectGroup(data);
											}else{
												//直接入力ならば
												//Suggestの変数名は異なるので注意
												model.projectName(data.projectNm);
												model.projectSno(data.projectCd);
											}
										}else{
											//データがnullならば
											model.clearProjectGroup();
											window.setTimeout("$(\'#txtProject\').find(\'input[id^=\"ms-input\"]\').click()", 20);
										}
									});
					$(model.msCust)
							.on(
									'selectionchange',
									function(event, combo, selection) {
										var data = selection[0] != null ? selection[0]: null;
										model.custCd(data != null ? data.custCd : null);
										//Suggestの変数名は異なるので注意
										model.custName(data != null ? data.custNm : null);
									});
					$(model.msCustDept)
					.on(
							'selectionchange',
							function(event, combo, selection) {
								var data = selection[0] != null ? selection[0]: null;
								//Suggestの変数名は異なるので注意
								model.custDeptCd(data != null ? data.deptCd : null);
								model.custDeptName(data != null ? data.deptNm : null);
							});

					$(model.msUser)
					.on(
							'selectionchange',
							function(event, combo, selection) {
								var data = selection[0] != null ? selection[0]: null;
								//Suggestの変数名は異なるので注意
								model.custOwnerCd(data != null ? data.custStaffCd : null);
								model.custOwnerName(data != null ? data.custStaffNm : null);
							});
					$(model.msTitle)
					.on(
							'selectionchange',
							function(event, combo, selection) {
								var data = selection[0] != null ? selection[0]: null;
								//Suggest部品の変数名は異なるので注意
								model.custTitleCd(data != null ? data.code : null);
								model.custTitle(data != null ? data.name : null);
							});
					$(model.msMyGroup)
					.on(
							'selectionchange',
							function(event, combo, selection) {
								var data = selection[0] != null ? selection[0]: null;
								model.salesGroupCd(data != null ? data.groupCd : null);
								model.salesGroupName(data != null ? data.groupNm : null);
							});
					$(model.msMyStaff)
					.on(
							'selectionchange',
							function(event, combo, selection) {
								var data = selection[0] != null ? selection[0]: null;
								model.salesStaffCd(data != null ? data.userCd : null);
								model.salesStaffName(data != null ? data.userNm : null);
							});


					// 単位サジェスト選択変更
					$(model.msUnit)
							.on(
									'selectionchange',
									function(event, combo, selection) {
										var data = selection[0] != null ? selection[0]: null;
										model.itemUnit(data != null ? data.unitCd : null);
										model.itemUnitName(data != null ? data.unitNm : null);
									});

					// 品目サジェスト選択変更
					$(model.msItem)
							.on(
									'selectionchange',
									function(event, combo, selection) {
										var data = selection[0] != null ? selection[0]: null;
										if(data != null){
											if(!this.isFreeEntry()){
												//選択入力ならば
												model.setItemGroup(data);
											}else{
												//直接入力ならば
												model.itemCd(data.itemCd);
												model.itemName(data.itemNm);
											}
										}else{
											model.clearItemGroup();
											window.setTimeout("$(\'#txtItem\').find(\'input[id^=\"ms-input\"]\').click()", 20);
										}
									});



				});


