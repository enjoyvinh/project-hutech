/**
 * マスターページ
 * $Revision:  $  $Date:  $
 */
/**
 * MasterPage用初期処理
 */
$(document).ready(
				function() {
					$("#datepicker").datepicker({
						numberOfMonths : 3,
						showButtonPanel : true
					});
					
					//-------------------------------------------------------------
					// Element初期設定
					// typeに対応する標準maxlengthとinputFilterを設定する
					// inputタグ内にmaxlengthが指定されている場合は、そちらが有効
					// type: notes,name,code,phone,yyyymmdd,number,digits
					//-------------------------------------------------------------
					 initAttribute();

					$("#menu-toggle").click(function(e) {
						e.preventDefault();
						$("#wrapper").toggleClass("active");
					});

					var ms1 = $('#txtSearch')
							.magicSuggest(
									{
										data : 'suggest/cust',
										cls : 'cust-suggest',
										displayField : 'custNm',
										valueField: 'custCd',
										sortDir : 'desc',
										highlight : false,
										allowFreeEntries : false,
										selectionStacked : false,
										preselectSingleSuggestion : false,
										resultAsString : false,
										typeDelay : 0,
										maxSelection : 1,
										minChars : 2,
										// bJQueryUI: false,
										width : 300,
										maxDropHeight : 500,
										hideTrigger : true,
										suggestField1 : 'custNm',
										suggestField2 : 'custCd',
										emptyText : customer_emptyText,
										renderer : function(v) {
											return '<div>'
													+ '<div style="float:left;color:#333;">'
													+ v.custCd
													+ '</div>'
													+ '<div style="padding-left:5px; float:left; color: #3c465a; font-weight: bold;">'
													+ v.custNm
													+ '</div>'
													+ '</div>'
													+ '</div><div style="clear:both;"></div>';
										}
									});
					$(ms1).on('selectionchange',
							function(event, combo, selection) {
								if (selection.length > 0) {
									alert('顧客情報画面に遷移する');
								}

							});
				});

function initAttribute(){
	initFieldFilter();
};
