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
    public class SF_DANHGIASANPHAM
    {
        public String MAKHACHHANG { get; set; }
        public String MASANPHAM { get; set; }
        public DateTime NGAY { get; set; }
        public Int32 DIEM { get; set; }
        public String NOIDUNGDANHGIA { get; set; }
    }
}
