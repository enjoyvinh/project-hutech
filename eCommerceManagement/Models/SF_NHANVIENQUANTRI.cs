//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eCommerceManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SF_NHANVIENQUANTRI
    {
        public string MANHANVIEN { get; set; }
        public string MATKHAUNHANVIEN { get; set; }
        public int MAQUYEN { get; set; }
        public string HOTENDEM { get; set; }
        public string TENNHANVIEN { get; set; }
        public string DIENTHOAI { get; set; }
        public string DIACHI { get; set; }
        public System.DateTime NGAYSINH { get; set; }
        public string SOCMND { get; set; }
        public byte TRANGTHAI { get; set; }
        public System.DateTime NGAYTAO { get; set; }
    
        public virtual SF_NHOMQUYEN SF_NHOMQUYEN { get; set; }
    }
}