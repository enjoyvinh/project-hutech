using System;

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
    public class SF_HOADON
    {  
        public String SOHOADON { get; set; }
        public String MACUAHANG { get; set; }
        public String MAKHACHHANG { get; set; }
        public String MACHUONGTRINHGIAMGIA { get; set; }
        public DateTime NGAYLAP { get; set; }
        public Int16 TRANGTHAIHOADON { get; set; }
        public Decimal TONGTIEN { get; set; }
    }
}
