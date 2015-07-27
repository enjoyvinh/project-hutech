using System;

/*
 *  
 *  Author:     Đỗ Thị Ngọc - 1216061071
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */
namespace DAOs.Entities
{
    public class SF_KHACHHANG
    {
        public String MAKHACHHANG { get; set; }
        public String MATKHAU { get; set; }
        public Int16 MAQUYENKHACHHANG { get; set; }
        public String HOTENLOT { get; set; }
        public String TEN { get; set; }
        public Int16 GIOITINH { get; set; }
        public String DIENTHOAI { get; set; }
        public DateTime NGAYSINH { get; set; }
        public String DIACHI { get; set; }
        public Int16 TRANGTHAI { get; set; }
    }
}
