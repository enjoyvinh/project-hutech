using System;

/*
 *  
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */
namespace DAOs.DTO
{
    public class REQUEST_NHANVIENQUANTRIDTO
    {
        public String MANHANVIEN { get; set; }
        public String MATKHAUNHANVIEN { get; set; }
        public Int16 MAQUYEN { get; set; }
        public String HOTENDEM { get; set; }
        public String TENNHANVIEN { get; set; }
        public String DIENTHOAI { get; set; }
        public String DIACHI { get; set; }
        public DateTime NGAYSINH { get; set; }
        public String SOCMND { get; set; }
        public Int16 TRANGTHAI { get; set; }
        public DateTime NGAYTAO { get; set; }
    }
}
