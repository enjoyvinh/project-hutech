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
    public class VIEW_KHACHHANGDTO
    {
        public String MAKHACHHANG { get; set; }
        public String MATKHAU { get; set; }
        public Int16 MAQUYEN { get; set; }
        public String HOTENLOT { get; set; }
        public String TEN { get; set; }
        public Int16 GIOITINH { get; set; }
        public String EMAIL { get; set; }
        public String DIENTHOAI { get; set; }
        public DateTime NGAYSINH { get; set; }
        public String DIACHI { get; set; }
        public DateTime NGAYTAO { get; set; }
        public Int16 TRANGTHAI { get; set; }
    }
}
