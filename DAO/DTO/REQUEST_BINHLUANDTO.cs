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
    public class REQUEST_BINHLUANDTO
    {
        public String MABINHLUAN { get; set; }
        public String MABINHLUANCHA { get; set; }
        public String MASANPHAM { get; set; }
        public String MAKHACHHANG { get; set; }
        public String NOIDUNG { get; set; }
        public DateTime NGAYBINHLUAN { get; set; }
    }
}
