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
    public class VIEW_NHANVIENQUANTRI
    {
        public String MANHANVIEN { get; set; }
        public String MATKHAUNHANVIEN { get; set; }
        public Int16 MAQUYENNHANVIEN { get; set; }
        public String HOTENDEM { get; set; }
        public String TENNHANVIEN { get; set; }
        public String DIENTHOAI { get; set; }
        public String DIACHI { get; set; }
        public DateTime NGAYSINH { get; set; }
        public String SOCMND { get; set; }
        public Int16 TRANGTHAI { get; set; }
    }
}
