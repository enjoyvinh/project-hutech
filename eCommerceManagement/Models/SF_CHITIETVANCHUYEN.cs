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
    
    public partial class SF_CHITIETVANCHUYEN
    {
        public string SOHOADON { get; set; }
        public string MAPHUONGTHUC { get; set; }
        public string MATHANHPHODI { get; set; }
        public string MATHANHPHODEN { get; set; }
        public Nullable<decimal> TONGPHIVANCHUYEN { get; set; }
    
        public virtual SF_PHUONGTHUCVANCHUYEN SF_PHUONGTHUCVANCHUYEN { get; set; }
        public virtual SF_HOADON SF_HOADON { get; set; }
        public virtual SF_KHOANGCACH SF_KHOANGCACH { get; set; }
    }
}
