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
    
    public partial class SF_CHUONGTRINHGIAMGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SF_CHUONGTRINHGIAMGIA()
        {
            this.SF_CHITIETGIAMGIA = new HashSet<SF_CHITIETGIAMGIA>();
            this.SF_HOADON = new HashSet<SF_HOADON>();
        }
    
        public string MACHUONGTRINHGIAMGIA { get; set; }
        public string MACUAHANG { get; set; }
        public string TENGIAMGIA { get; set; }
        public string NOIDUNG { get; set; }
        public System.DateTime NGAYBATDAU { get; set; }
        public System.DateTime NGAYKETTHUC { get; set; }
    
        public virtual SF_CUAHANG SF_CUAHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SF_CHITIETGIAMGIA> SF_CHITIETGIAMGIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SF_HOADON> SF_HOADON { get; set; }
    }
}
