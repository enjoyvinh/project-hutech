﻿using System;

/*
 *  
 *  Author:     Vinh Nguyễn - 1216061133
 *  Class:      12LDTHC2
 *  Version:    1.0
 *  Copyright @ 2015 HUTECH
 * 
 */
namespace DAOs.Entities
{
    public class SF_SANPHAM
    {
        public String MASANPHAM { get; set; }
        public String MACHUYENMUC { get; set; }
        public String MADONVITINH { get; set; }
        public String MACUAHANG { get; set; }
        public String TENSANPHAM { get; set; }
        public Decimal DONGIACU { get; set; }
        public Decimal DONGIAMOI { get; set; }
        public Int32 LUOTXEM { get; set; }
        public Int16 TINHTRANG { get; set; }
        public String MOTA { get; set; }
        public Int16 LUUNHAP { get; set; }
        public DateTime NGAYTAO { get; set; }
        public Int32 SOLUONGTONKHO { get; set; }
    }
}
