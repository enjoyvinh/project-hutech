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
    
    public partial class SF_CUAHANGYEUTHICH
    {
        public string MAKHACHHANG { get; set; }
        public string MACUAHANG { get; set; }
        public System.DateTime NGAYTHICH { get; set; }
    
        public virtual SF_CUAHANG SF_CUAHANG { get; set; }
        public virtual SF_KHACHHANG SF_KHACHHANG { get; set; }
    }
}
