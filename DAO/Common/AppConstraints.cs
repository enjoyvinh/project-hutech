/*
 *  
 *  Filename:   AppConstraints.cs
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */

namespace DAOs.Common
{
    public static class AppConstraints
    {
        #region Numeric
        public static string ZERO { get { return "0"; } }
        public static string ONE { get { return "1"; } }
        public static string TWO { get { return "2"; } }
        public static string THREE { get { return "3"; } }
        public static string FOUR { get { return "4"; } }
        public static string FIVE { get { return "5"; } }
        public static string SIX { get { return "6"; } }
        public static string SEVEN { get { return "7"; } }
        public static string EIGHT { get { return "8"; } }
        public static string NIGHT { get { return "9"; } }
        public static string VND { get { return " VNĐ"; } }
        public static string EMPTY { get { return ""; } }
        public static string BACKFLASH { get { return "/"; } }
        public static string SHOP_NOIMAGE { get { return "SHOP_NOIMAGE"; } }

        #endregion

        #region MessageResult
        public static string MESSAGEBOX_TITLE_CONFIRM { get { return "Xác Nhận"; } }
        public static string MESSAGEBOX_TITLE_SUCCESS { get { return "Chúc Mừng"; } }
        public static string MESSAGEBOX_TITLE_WARNING { get { return "Thông Báo"; } }
        public static string MESSAGEBOX_TITLE_ERROR { get { return "Thông Báo"; } }
        public static string SUCCESS { get { return "SUCCESS"; } }
        public static string WARNING { get { return "WARNING"; } }
        public static string ERROR { get { return "ERROR"; } }
        public static string SUCCESS_INSERT_MESSAGE { get { return "Thêm Thành Công."; } }
        public static string SUCCESS_UPDATE_MESSAGE { get { return "Cập Nhật Thành Công."; } }
        public static string SUCCESS_DELETE_MESSAGE { get { return "Xóa Thành Công."; } }
        public static string SUCCESS_PAYMENT_MESSAGE { get { return "Thanh Toán Thành Công."; } }
        public static string WARNING_MESSAGE { get { return "Thất Bại."; } }
        public static string ERROR_MESSAGE { get { return "Có lỗi xãy ra, vui lòng liên hệ quản trị viên."; } }
        #endregion

        #region TABLE HOADONBANHANG
        public static string TABLE_HOADONBANHANG { get { return "HoaDonBanHang"; } }
        public static string TABLE_HOADONBANHANG_SOHOADON_COLUMN { get { return "SoHoaDon"; } }
        public static string TABLE_HOADONBANHANG_SOHOADON_PREFIX { get { return "HDBH"; } }
        #endregion

        #region MESSAGE
        //public static string COL_0000001 { get { return "HoVaTenNV"; } }
        //public static string COL_0000002 { get { return "NhanVienGuid"; } }

        //public static string COL_0000003 { get { return "HoTenKH"; } }
        //public static string COL_0000004 { get { return "CustomerGuid"; } }

        //public static string COL_0000005 { get { return "HoaDonBanHangGuid"; } }
        public static string MESS_0000001 { get { return "0.0000"; } }
        public static string MESS_0000002 { get { return "Danh Sách Hóa Đơn"; } }
        public static string MESS_0000003 { get { return "Tạo Hóa Đơn"; } }
        
        

        #endregion

        #region DIALOG MESSAGE
        public static string DIALOG_0000001 { get { return "Chọn Ngày Tìm Kiếm Không Chính Xác."; } }
        public static string DIALOG_0000002 { get { return "Bạn Có Muốn Thanh Toán Hoá Đơn Này?"; } }
        public static string DIALOG_0000003 { get { return "Bạn Có Muốn Đặt Bàn Này?"; } }
        public static string DIALOG_0000004 { get { return "Bạn Có Muốn Cập Nhật Hoá Đơn Này?"; } }
        public static string DIALOG_0000005 { get { return "Bạn Có Muốn Huỷ Bàn Này?"; } }
        
        //public static string DIALOG_TITLE_ { get { return "Vui Lòng Chọn Nhân Viên."; } }
        //public static string WARN_0000002 { get { return "Vui Lòng Chọn Khách Hàng."; } }
        //public static string WARN_0000003 { get { return "Vui Lòng Chọn Bàn."; } }
        //public static string WARN_0000004 { get { return "Hãy Chọn Danh Sách Món Ăn."; } }
        #endregion

        #region WARNING MESSAGE
        public static string WARN_0000001 { get { return "Vui Lòng Chọn Nhân Viên."; } }
        public static string WARN_0000002 { get { return "Vui Lòng Chọn Khách Hàng."; } }
        public static string WARN_0000003 { get { return "Vui Lòng Chọn Bàn."; } }
        public static string WARN_0000004 { get { return "Hãy Chọn Danh Sách Món Ăn."; } }
        public static string WARN_0000005 { get { return "Vui Lòng Nhập Giá Bán."; } }
        public static string WARN_0000006 { get { return "Vui Lòng Nhập Khuyến Mãi."; } }
        public static string WARN_0000007 { get { return "Vui Lòng Nhập Giá Bán Lớn Hơn Khuyến Mãi."; } }
        
        
        #endregion
    }
}
