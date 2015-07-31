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
    public class VIEW_DANHGIASANPHAMDTO
    {
        public String MAKHACHHANG { get; set; }
        public String MASANPHAM { get; set; }
        public DateTime NGAY { get; set; }
        public Int16 DIEM { get; set; }
        public String NOIDUNGDANHGIA { get; set; }
    }
}
