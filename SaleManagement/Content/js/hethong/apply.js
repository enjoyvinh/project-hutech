/**
 * 申請依頼js
 * $Revision:  $  $Date:  $
 */
(function($) {
	$.fn.applyPopup = function(options) {
		var target = $(this);
		var options = $.extend({
			fnOk : function(data) {
				//OKボタン押下処理
			},
			fnCancel : function() {
				//CANCELボタン押下処理				
			},
			parameters: {
				//リクエストパラメータ
			}
		}, options);
		
		var viewModel = new ApplyViewModel(options);
		viewModel.loadPage(options.parameters);

		
	};		
})(jQuery);

// ViewModel定義
var ApplyViewModel = function(options) {
	var self = this;
	self.options = options;
	self.message = ko.observable('');
	self.item1 = ko.observable('');
	self.item2 = ko.observable('');

	self.load = function(){
		 ko.applyBindings(self, $('.popup-page')[0]);
	};
	
	self.unload = function(){
		ko.cleanNode($('.popup-page')[0]);
	};

	self.okClick = function(obj, e) {

		//申請依頼仕様に合わせて修正
		var model = new ApplyModel(self);

		//TODO:クライアントでチェック処理だけが必要であれば、ここでチェックする。
		/*		var items = $('.grp-wf');
				items.validate();
				if (!items.valid()) {
					return false;
				}
		*/		

		//TODO:サーバサイドでチェックや何等かの処理が必要であれば、ここでサーバにアクセスする。		
		$.fn.callservice({
			url: 'wf/apply/validate',
			request : model,
			autodisabled : true,
			validationtarget : '.grp-wf',
			success : function(response) {
				self.hidePopup();
				//親画面のfunctionを実行する
				self.options.fnOk(model);
			}
		});

	};

	self.cancelClick = function(obj, e) {
		self.hidePopup();
		self.options.fnCancel();
	};
	
	
	self.loadPage = function(parameters){
		   $.fn.callservice({
			   type: 'GET',
			   url: 'wf/apply',
			   dataType: 'html',
			   success: function(data) {
				   $('.popup-page').empty();
				   $('.popup-page').append(data);
				   initFieldFilter();
				   self.showPopup();
				   self.load();				   
			   }
		   });
		   
	};
		
	self.hidePopup = function(){
		$('.popup-page').hide();
		$(".modal-backdrop").hide();
		self.unload();		
	};

	self.showPopup = function(){
		$('.popup-page').show();
		$(".modal-backdrop").show();
	};

};

var ApplyModel = function(data){
	var self = this;
	//申請依頼仕様に合わせて修正
	self.message = ko.observable(data.message());
	self.item1 = ko.observable(data.item1());
	self.item2 = ko.observable(data.item2());	
};

