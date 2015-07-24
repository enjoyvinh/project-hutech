﻿using System.Web;
using System.Web.Optimization;

namespace SaleManagement
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*Module Chức Năng*/
            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                        "~/Scripts/common/AdminLTE/dashboard2.js"
                        , "~/Scripts/common/AdminLTE/demo.js"
                        , "~/Scripts/quanly/QuanLyTrangChu.js"));
            bundles.Add(new ScriptBundle("~/bundles/quanlydangnhapjs").Include(
                        "~/Scripts/quanly/QuanLyDangNhap.js"));
            /*Module Chức Năng*/


            bundles.Add(new ScriptBundle("~/bundles/hethongheaderjs").Include(
                        "~/Scripts/quanly/QuanLyHeader.js"));

            bundles.Add(new ScriptBundle("~/bundles/hethongmenujs").Include(
                        "~/Scripts/quanly/QuanLyMenu.js"));


            bundles.Add(new ScriptBundle("~/bundles/quanlytheloaijs").Include(
                        "~/Scripts/quanly/QuanLyTheLoai.js"));
            bundles.Add(new ScriptBundle("~/bundles/quanlythemtheloaijs").Include(
                        "~/Scripts/quanly/QuanLyThemTheLoai.js"));
            bundles.Add(new ScriptBundle("~/bundles/quanlycapnhattheloaijs").Include(
                        "~/Scripts/quanly/QuanLyCapNhatTheLoai.js"));
            bundles.Add(new ScriptBundle("~/bundles/quanlybantinjs").Include(
                        "~/Scripts/quanly/QuanLyBanTin.js"));
            bundles.Add(new ScriptBundle("~/bundles/quanlythembantinjs").Include(
                        "~/Scripts/quanly/QuanLyThemBanTin.js"));
            bundles.Add(new ScriptBundle("~/bundles/quanlycapnhatbantinjs").Include(
                        "~/Scripts/quanly/QuanLyCapNhatBanTin.js"));

            bundles.Add(new ScriptBundle("~/bundles/quanlydanhmucjs").Include(
                        "~/Scripts/quanly/QuanLyDanhMuc.js"));
            bundles.Add(new ScriptBundle("~/bundles/quanlythemdanhmucjs").Include(
                        "~/Scripts/quanly/QuanLyThemDanhMuc.js"));
            bundles.Add(new ScriptBundle("~/bundles/quanlynhanvienjs").Include(
                        "~/Scripts/quanly/QuanLyNhanVien.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/hethongjs").Include(
                //"~/Scripts/quanly/common/jquery-1.11.2.js"
                    "~/Scripts/common/jquery-2.1.3.js"
                    , "~/Scripts/common/bootstrap.js"
                    , "~/Content/common/plugins/morris/morris.js"
                    , "~/Scripts/common/jquery.filter_input.js"
                    , "~/Scripts/common/angular-1.4.0-rc/angular.js"
                    , "~/Scripts/common/angular-1.4.0-rc/angular-sanitize.js"
                    , "~/Scripts/common/angular-translate.js"
                    , "~/Scripts/common/moment.js"
                    , "~/Scripts/common/ui-bootstrap-tpls-0.13.0.js"
                    , "~/Scripts/common/autoNumeric.js"
                    , "~/Scripts/common/chosen.jquery.js"
                    , "~/Scripts/common/chosen.js"
                    , "~/Scripts/common/plugins/ckeditor/ckeditor.js"
                    , "~/Scripts/common/angular.dcb-img-fallback.js"
                    , "~/Scripts/common/bootstrap-switch.js"
                    , "~/Scripts/common/angular-bootstrap-switch.js"
                    , "~/Scripts/common/skyfire-angularjs.js"
                    , "~/Scripts/common/skyfire-bootstrap-angularjs.js"
                    , "~/Scripts/common/skyfire-bootstrap-ui.js"
                    , "~/Scripts/common/skyfire-common.js"
                    , "~/Scripts/common/skyfire-javascript-ext.js"
                    , "~/Scripts/common/dialogs.js"
                    , "~/Scripts/common/exexTable.js"
                    , "~/Scripts/common/pagination.js"
                    , "~/Scripts/common/common-suggest.js"
                    , "~/Scripts/common/jquery.formance.min.js"
                    , "~/Scripts/common/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js"
                    , "~/Scripts/common/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"
                    , "~/Scripts/common/AdminLTE/app.js"
                    , "~/Scripts/common/plugins/iCheck/icheck.js"
                    , "~/Scripts/common/plugins/bootstrap-slider/bootstrap-slider.js"
                    , "~/Scripts/common/plugins/chartjs/Chart.js"
                    , "~/Scripts/common/plugins/colorpicker/bootstrap-colorpicker.js"
                    , "~/Scripts/common/plugins/datatables/jquery.dataTables.js"
                    , "~/Scripts/common/plugins/datatables/dataTables.bootstrap.js"
                    //, "~/Scripts/common/plugins/datepicker/bootstrap-datepicker.js"
                    //, "~/Scripts/common/plugins/datepicker/locales/bootstrap-datepicker.vi.js"
                    , "~/Scripts/common/plugins/fastclick/fastclick.js"
                    , "~/Scripts/common/plugins/fullcalendar/fullcalendar.js"
                    , "~/Scripts/common/plugins/input-mask/jquery.inputmask.js"
                    , "~/Scripts/common/plugins/input-mask/jquery.inputmask.date.extensions.js"
                    , "~/Scripts/common/plugins/input-mask/jquery.inputmask.extensions.js"
                    , "~/Scripts/common/plugins/input-mask/jquery.inputmask.numeric.extensions.js"
                    , "~/Scripts/common/plugins/input-mask/jquery.inputmask.phone.extensions.js"
                    , "~/Scripts/common/plugins/input-mask/jquery.inputmask.regex.extensions.js"
                    , "~/Scripts/common/plugins/ionslider/ion.rangeSlider.min.js"
                    , "~/Scripts/common/plugins/knob/jquery.knob.js"
                    , "~/Scripts/common/plugins/pace/pace.js"
                    , "~/Scripts/common/plugins/slimScroll/jquery.slimscroll.js"
                    , "~/Scripts/common/plugins/sparkline/jquery.sparkline.js"
                    , "~/Scripts/common/plugins/daterangepicker/daterangepicker.js"
                    , "~/Scripts/common/plugins/timepicker/bootstrap-timepicker.js"
                    , "~/Scripts/common/showErrors.js"
                    , "~/Scripts/common/jquery.powertip.js"
                    , "~/Scripts/common/plugins/jqueryvalidation/jquery.validate.js"
                    , "~/Scripts/common/angular-ckeditor.js"
                    , "~/Scripts/common/plugins/nguploadfile/ng-file-upload-shim.js"
                    , "~/Scripts/common/plugins/nguploadfile/ng-file-upload.js"
                    , "~/Scripts/common/plugins/nguploadfile/upload.js"
                    , "~/Scripts/common/angular-ui-tree.js"
                    
                    
                    //, "~/Scripts/common/chosen.proto.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/hethong/bootstrap.css"
                    , "~/Content/hethong/checkbox.css"
                    , "~/Content/hethong/font-awesome.css"
                    , "~/Content/hethong/skyfire-bootstrap.css"
                    , "~/Content/quanly/AdminLTE.css"
                    , "~/Content/quanly/skins/_all-skins.css"
                    , "~/Content/hethong/skyfire-extention.css"
                    , "~/Content/hethong/widths.css"
                    , "~/Content/hethong/chosen.css"
                    , "~/Content/hethong/chosen-spinner.css"
                    , "~/Content/hethong/bootstrap-switch.css"
                    , "~/Scripts/quanly/common/jquery-ui-1.11.4/jquery-ui.css"
                    , "~/Scripts/quanly/common/jquery-ui-1.11.4/jquery-ui.structure.css"
                    , "~/Scripts/quanly/common/jquery-ui-1.11.4/jquery-ui.theme.css"
                    , "~/Content/quanly/iCheck/all.css"
                    , "~/Content/quanly/iCheck/square/_all.css"
                    , "~/Content/quanly/bootstrap-wysihtml5/bootstrap3-wysihtml5.css"
                    , "~/Content/quanly/bootstrap-slider/slider.css"
                    , "~/Content/quanly/colorpicker/bootstrap-colorpicker.css"
                    , "~/Content/quanly/datatables/dataTables.bootstrap.css"
                    , "~/Content/quanly/datepicker/datepicker3.css"
                    , "~/Content/quanly/fullcalendar/fullcalendar.css"
                    , "~/Content/quanly/ionslider/ion.rangeSlider.css"
                    , "~/Content/quanly/jvectormap/jquery-jvectormap-1.2.2.css"
                    , "~/Content/quanly/morris/morris.css"
                    , "~/Content/quanly/daterangepicker/daterangepicker-bs3.css"
                    , "~/Content/quanly/timepicker/bootstrap-timepicker.css"
                    , "~/Scripts/common/plugins/ckeditor/contents.css"
                    , "~/Content/hethong/jquery.powertip.css"
                    , "~/Content/hethong/jquery.powertip-red.css"
                    , "~/Content/hethong/nguploadfile.css"
                    , "~/Content/hethong/angular-ui-tree.min.css"
                    , "~/Content/hethong/ionicons-2.0.1/css/ionicons.css"
            ));

            bundles.Add(new StyleBundle("~/TinTuc/css").Include(
                    "~/Content/tintuc/style.css"
                    , "~/Content/tintuc/function2.css"
                    , "~/Content/tintuc/custom.css"
            ));
        }
    }
}