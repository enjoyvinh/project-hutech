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
    public class SF_CUAHANG
    { 
        public String MACUAHANG { get; set; }
        public String MAQUANHUYEN { get; set; }
        public Int16 MAQUYEN { get; set; }
        public String HINHLOGO { get; set; }
        public String TENCUAHANG { get; set; }
        public String HOTENCHUCUAHANG { get; set; }
        public String KHAUHIEU { get; set; }
        public String DIACHI { get; set; }
        public String DIENTHOAICHINH { get; set; }
        public String DIENTHOAIPHU { get; set; }
        public String MOTA { get; set; }
        public Int16 CHUNGNHAN { get; set; }
        public string TAIKHOANCUAHANG { get; set; }
        public string MATKHAUCUAHANG { get; set; }
        public System.DateTime NGAYTAO { get; set; }
        public byte TRANGTHAI { get; set; }
    }
}
