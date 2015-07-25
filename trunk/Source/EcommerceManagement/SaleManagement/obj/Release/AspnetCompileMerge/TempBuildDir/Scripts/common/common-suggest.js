/**
 * 共通サジェスト
 * @version $Revision:  $  $Date:  $
 */

	/* 案件サジェスト */
	$.fn.projectSuggest = function(options) {
    	var target = $(this);

		var options = $.extend({
		}, options);

		var ms = target.magicSuggest({
			data : 'suggest/project',
			displayField : 'projectNm',
			valueField: 'projectCd',
			allowFreeEntries : true,
			maxEntryLength: 60,
			preselectSingleSuggestion : true,
			maxSelection : 1,
			minChars : 1,
			suggestField1 : 'projectCd',
			suggestField2 : 'projectNm',
			groupBy: 'custNm',
			emptyText : target[0].placeholder,
			maxSelectionRenderer: function(v) {
	                return '';
	        },
			renderer : function(v) {
				return v.projectNm;
			}
		});

		return ms;
	};


	/* 顧客サジェスト */
	$.fn.custSuggest = function(options) {
    	var target = $(this);

		var options = $.extend({
			exPreAjax: null
		}, options);

		var ms = target.magicSuggest({
			data : 'suggest/cust',
			displayField : 'custNm',
			valueField: 'custCd',
			allowFreeEntries : true,
			maxEntryLength: 60,
			preselectSingleSuggestion : true,
			maxSelection : 1,
			minChars : 1,
			suggestField1 : 'custNm',
			suggestField2 : 'custCd',
			emptyText : target[0].placeholder,
			maxSelectionRenderer: function(v) {
                return '';
			},
			exPreAjax: options.exPreAjax,
			renderer : function(v) {
				return v.custCd
				+ " " + v.custNm;
			}
		});

		return ms;
	};

	/* 顧客部署サジェスト */
	$.fn.custDeptSuggest = function(options) {
    	var target = $(this);
		var options = $.extend({
			exPreAjax: null
		}, options);

		var ms = target.magicSuggest({
			data : 'suggest/custDept',
			displayField : 'deptNm',
			valueField : 'deptCd',
			allowFreeEntries : true,
			maxEntryLength: 30,
			preselectSingleSuggestion : true,
			maxSelection : 1,
			minChars : 1,
			comboWidth: 500,
			suggestField1 : 'deptCd',
			suggestField2 : 'deptNm',
			emptyText : target[0].placeholder,
			groupBy: 'custNm',
			maxSelectionRenderer: function(v) {
                return '';
			},
			exPreAjax: options.exPreAjax,
			renderer : function(v) {
				return v.deptNm;
			}
		});

		return ms;
	};


	/* 顧客ユーザサジェスト */
	$.fn.custUserSuggest = function(options) {
    	var target = $(this);

		var options = $.extend({
			exPreAjax: null
		}, options);

		var ms = target.magicSuggest({
			data : 'suggest/custUser',
			displayField : 'custStaffNm',
			valueField: 'custStaffCd',
			allowFreeEntries : true,
			maxEntryLength: 30,
			preselectSingleSuggestion : true,
			comboWidth: 300,
			maxSelection : 1,
			minChars : 1,
			suggestField1 : 'custStaffNm',
			suggestField2 : 'custStaffCd',
			emptyText : target[0].placeholder,
			groupBy: 'deptNm',
			maxSelectionRenderer: function(v) {
                return '';
			},
			exPreAjax: options.exPreAjax,
			renderer : function(v) {
				return v.custStaffNm;
			}
		});

		return ms;
	};

	/* 敬称 */
	$.fn.custTitleSuggest = function(options) {
    	var target = $(this);

    	if(target.length < 1) return null;

		var options = $.extend({
			exPreAjax: null
		}, options);

		var ms = target.magicSuggest({
			data : 'suggest/custTitle',
			displayField : 'name',
			valueField : 'code',
			allowFreeEntries : true,
			maxEntryLength: 10,
			preselectSingleSuggestion : true,
			typeDelay : 100,
			maxSelection : 1,
			minChars : 0,
			hideTrigger : false,
			expandOnFocus: false,
			emptyText : target[0].placeholder,
			maxSelectionRenderer: function(v) {
                return '';
			},
			exPreAjax: options.exPreAjax,
			cache: true

		});
		return ms;
	};




	/* 自社グループサジェスト */
	$.fn.myGroupSuggest = function(options) {
    	var target = $(this);

		var options = $.extend({
			exPreAjax: null
		}, options);

		var ms = target.magicSuggest({
			data : 'suggest/myGroup',
			displayField : 'groupNm',
			valueField : 'groupCd',
			maxEntryLength: 50,
			expandOnFocus: false,
			allowFreeEntries : false,
			preselectSingleSuggestion : true,
			hideTrigger: false,
			maxSelection : 1,
			minChars : 0,
			suggestField1 : 'groupNm',
			suggestField2 : 'groupCd',
			emptyText : target[0].placeholder,
			maxSelectionRenderer: function(v) {
                return '';
			},
			exPreAjax: options.exPreAjax,
			renderer : function(v) {
				return v.groupCd + " " +v.groupNm
			},
			cache: true

		});

		return ms;
	};

	/* 自社ユーザサジェスト */
	$.fn.myStaffSuggest = function(options) {
    	var target = $(this);

		var options = $.extend({
			exPreAjax: null
		}, options);

		var ms = target.magicSuggest({
			data : 'suggest/myStaff',
			displayField : 'userNm',
			valueField : 'userCd',
			expandOnFocus: false,
			maxEntryLength: 40,
			allowFreeEntries : false,
			preselectSingleSuggestion : true,
			maxSelection : 1,
			minChars : 0,
			suggestField1 : 'userNm',
			suggestField2 : 'userCd',
			groupBy: 'groupNm',
			emptyText : target[0].placeholder,
			maxSelectionRenderer: function(v) {
	                return '';
	        },
			exPreAjax: options.exPreAjax,
			renderer : function(v) {
				return v.userCd + " " + v.userNm;
			}
		});

		return ms;
	};

	/* 品目サジェスト */
	$.fn.itemSuggest = function(options) {
	    	var target = $(this);

	    	if(target.length < 1) return null;

			var options = $.extend({
				exPreAjax: null
			}, options);
			var ms = target.magicSuggest({
				data : 'suggest/item',
				displayField : 'itemNm',
				valueField : 'itemCd',
				maxEntryLength: 30,
				allowFreeEntries : true,
				preselectSingleSuggestion : true,
				maxSelection : 1,
				minChars : 1,
				comboWidth: 500,
				suggestField1 : 'itemNm',
				suggestField2 : 'itemCd',
				emptyText : target[0].placeholder,
				maxSelectionRenderer: function(v) {
	                return '';
				},
				exAddHeader: function(){
					return '<div class="ms-header">'
					+ '<div class="pull-left" style="width:20%;">品番</div>'
					+ '<div class="pull-left" style="width:45%;">品目</div>'
					+ '<div class="pull-left text-right" style="width:15%;">単価</div>'
					+ '<div class="pull-left text-right" style="width:10%;">在庫数</div>'
					+ '<div class="pull-left" style="width:10%;">(単位)</div>'
					+ '</div>';
				},
				exPreAjax: options.exPreAjax,
				renderer : function(v) {
					return '<div class="pull-left" style="color:#333; width:20%; clear:both;">'
					+ v.itemCd
					+ '</div>'
					+ '<div class="pull-left" style="color: #3c465a; font-weight: bold; width:45%;">'
					+ v.itemNm
					+ '</div>'
					+ '<div class="pull-left text-right" style="color: #3c465a; font-weight: bold; width:15%;">'
					+ v.unitPrice
					+ '</div>'
					+ '<div class="pull-left text-right" style="color: #3c465a; font-weight: bold; width:10%;">'
					+ v.stok
					+ '</div>'
					+ '<div class="pull-left" style="color: #3c465a; font-weight: bold; width:10%;">'
					+ v.unitNm
					+ '</div><div style="clear:both"></div>';

				}
			});

			return ms;
		};

		/*  単位　*/
		$.fn.unitSuggest = function(options) {
	    	var target = $(this);

	    	if(target.length < 1) return null;

			var options = $.extend({
				exPreAjax: null
			}, options);

			var ms = target.magicSuggest({
				data : 'suggest/unit',
				displayField : 'unitNm',
				valueField : 'unitCd',
				maxEntryLength: 30,
				allowFreeEntries : true,
				preselectSingleSuggestion : true,
				typeDelay : 100,
				hideTrigger: false,
				maxSelection : 1,
				minChars : 0,
				expandOnFocus: false,
				emptyText : '',
				maxSelectionRenderer: function(v) {
	                return '';
				},
				exPreAjax: options.exPreAjax,
				cache: true

			});
			return ms;
		};

		//---------------------------------------------------------------------------------------------------------------------
		//以下に追加
