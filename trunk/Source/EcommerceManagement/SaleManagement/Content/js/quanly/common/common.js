/**
 * 共通function
 * $Revision:  $  $Date:  $
 */

/**
 * 文字列("1,2,3")をInt配列{1,2,3}変換する
 */
function text2IntArray(text) {
	var strs = text.split(',');
	var array = new Array();
	for (var i = 0; i < strs.length; i++) {
		array.push(parseInt(strs[i]));
	}
	return array;
};

/**
 * エラーツールチップをセットする
 * @param elem
 */
function addErrorTipsForElement(element, message) {	
	if(element == null)
		return false;
	$(element).addClass('error');
	$(element).attr('data-powertip', message);
	return true;
};

/**
 * エラーツールチップをセットする
 * @param id
 * @param message
 */
function addErrorTips(id, message) {	
	var element = getTargetElementByField(id);
	if(element == null)
		return false;
	element.addClass('error');
	element.attr('data-powertip', message);
	return true;
};

/**
 * MagicSuggestのelementを取得する
 * @param id
 * @returns
 */
function getTargetElement(id) {
	var element = $('#' + id);
	var target = element.attr('error-target');
	if (target == null) {
		return element;
	}
	return $('#' + target);
};

function getTargetElementByField(field){
	var element = $('[field=' + field +']');
	var target = element.attr('error-target');
	if (target == null) {
		return element;
	}
	return $('#' + target);
}

/**
 * エラーツールチップをクリアする
 */
function clearErrorTips() {
	$('.error').removeClass('error');
	$('[data-powertip]').each(function() {
		$(this).removeAttr('data-powertip');
		$.powerTip.destroy(this);
	});

};

/**
 * エラーツールチップを設定する
 */
function loadTips() {
	$('[data-powertip]').powerTip({
		placement : 'n',
		smartPlacement : true,
		mouseOnToPopup : false
	});
	$('[data-powertip]').powerTip('show');
	setErrorFocus();
};

/**
 * エラー項目にフォーカスをセットする
 */
function setErrorFocus(){
	
	var errors = $('[data-powertip]');
	if(errors.length > 0){
		if(errors[0].localName === "div"){
			$(errors[0]).find('input[id^="ms-input"]').focus();
		}else{
			errors[0].focus();			
		}
	}
}

$.validator.addMethod(
	    "yyyymmdd",
	    function(value, element) {
	        // yyyy/mm/dd
	        var re = /^\d{4}\/\d{1,2}\/\d{1,2}$/;

	        // valid if optional and empty OR if it passes the regex test
	        return (this.optional(element) && value=="") || re.test(value);
	    }, $.validator.messages.date
	);

/*
$.validator.addMethod("postnum", function(value, element) {
	return this.optional(element) || /^\d{3}\-\d{4}$/.test(value);
	}, "郵便番号を入力してください"
);

//電話番号
jQuery.validator.addMethod("phone", function(value, element) {
	return this.optional(element) || /^[0-9-]{12}$/.test(value);
	}, "電話番号を入力してください"
);
*/

/**
 * 別Windowでポップアップ表示する
 * @param url 
 */
function openPopup(url) {
    var winprop = "toolbar=no,location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no,";
    winprop += "width=780, height=" + screen.availHeight * 0.9 + "";
    wo = window.open(url, "openwin", winprop);
    wo.focus();
}

/**
 * 数値をカンマ区切りで表示する
 * @param value
 * @returns
 */
function formatNumber(value) {
	if(value == null)
		return null;
	return value.toString().replace(/([\d]+?)(?=(?:\d{3})+$)/g, function(t){ return t + ','; });
};

/**
 * カンマ付数値からカンマを除外する
 * @param value
 * @returns
 */
function unformattedNumber(value) {
	if(value == null)
		return null;
	var text = value.toString().replaceAll(',','');
	debugger;
	return Number(text);
};

/**
 * 価格を計算する
 * @param unitPrice 単価
 * @param amount 数量
 * @param discount 割引
 * @returns {Number}　価格
 */
function rowCalc(unitPrice, amount, discount){
	var sum;
	if (unitPrice != null && amount != null) {
		sum = unitPrice * amount * (1-discount/100);
		//四捨五入
		sum = Math.round(sum);
	}
	return sum;
};

/**
 * 税区分に対応する名称を取得する
 * @param id 税区分
 * @param datasource データソース
 * @returns 税区分名称
 */
function getTaxStatusNm(code, datasource){
	for(var i = 0; i < datasource.length; i++){
		if(code == datasource[i].code){
			return datasource[i].name;
		}
	}
	return null;
};

/**
 * 一致する全ての文字を置換する
 */
String.prototype.replaceAll = function (org, dest){  
	  return this.split(org).join(dest);  
}; 

/**
 * モーダルポップアップメッセージを表示する
 * @param message
 * @param fnCallBack closeボタン押下時のコールバック関数
 */
function showPopupMessage(message, fnCallBack){
	$('.popup-messages').append(message);	
	$('#popupInfo').show();
	$(".modal-backdrop").show();
	$('body').append("");
	$('.popup-close').click(function() {
		if(fnCallBack != null)
			fnCallBack.call();
		else
			closePopupMessage();
		}
	);
	$('.modal-backdrop').click(function() {
		if(fnCallBack != null)
			fnCallBack.call();
		else
			closePopupMessage();
		}
	);
};

/**
 * モーダルポップアップメッセージを閉じる
 */
function closePopupMessage(){
	$('.popup-messages').empty();
	$('#popupInfo').hide();
	$('.modal-backdrop').hide();
};

function appendErrorMessage(message){
	$('.popup-error-messages').append(message + '<br/>');
}

function empty2null(data){
	if(data==="")
		return null;
	return data;
}

/**
 * Elementにセットされた属性、classをもとに、フィルタを設定する
 */
function initFieldFilter(){
	 var jqEle = $('.notes');
	 if(jqEle.length > 0){
		 if(jqEle.attr("maxlength") == null){
			 jqEle.attr("maxlength",1000);						 
		 }						 
	 }
	 jqEle = $('.name');
	 if(jqEle.length > 0){
		 if(jqEle.attr("maxlength") == null){
			 jqEle.attr("maxlength",50);						 
		 }						 
	 }
	 jqEle = $('.code');
	 if(jqEle.length > 0){
		 if(jqEle.attr("maxlength") == null){
			 jqEle.attr("maxlength",20);						 
		 }						 
		 jqEle.filter_input({regex : '[a-zA-Z0-9-_]'});
	 }
	 jqEle = $('.phone');
	 if(jqEle.length > 0){
		 if(jqEle.attr("maxlength") == null){
			 jqEle.attr("maxlength",12);						 
		 }						 
		 jqEle.filter_input({regex : '[0-9-]'});
	 }
	 jqEle = $('.yyyymmdd');
	 if(jqEle.length > 0){
		 if(jqEle.attr("maxlength") == null){
			 jqEle.attr("maxlength",10);						 
		 }
		 jqEle.filter_input({regex : '[0-9/]'});
	 }
	 jqEle = $('.number');
	 if(jqEle.length > 0){
		 if(jqEle.attr("maxlength") == null){
			 jqEle.attr("maxlength",20);						 
		 }						 
		 jqEle.filter_input({regex : '[0-9-.]'});
	 }
	 jqEle = $('.digits');
	 if(jqEle.length > 0){
		 if(jqEle.attr("maxlength") == null){
			 jqEle.attr("maxlength",10);
		 }
		 jqEle.filter_input({regex : '[0-9]'});
	 }
}
//---------------------------------------------------------------------------
// 以下から追加してください
//---------------------------------------------------------------------------

