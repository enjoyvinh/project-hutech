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
    
    public partial class SF_DANHGIASANPHAM
    {
        public string MAKHACHHANG { get; set; }
        public string MASANPHAM { get; set; }
        public System.DateTime NGAY { get; set; }
        public byte DIEM { get; set; }
        public string NOIDUNGDANHGIA { get; set; }
    
        public virtual SF_KHACHHANG SF_KHACHHANG { get; set; }
        public virtual SF_SANPHAM SF_SANPHAM { get; set; }
    }
}
