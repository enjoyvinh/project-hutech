﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TMDTDB11Entities : DbContext
    {
        public TMDTDB11Entities()
            : base("name=TMDTDB11Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SF_BANTINCUAHANG> SF_BANTINCUAHANG { get; set; }
        public virtual DbSet<SF_BINHLUAN> SF_BINHLUAN { get; set; }
        public virtual DbSet<SF_CUAHANG> SF_CUAHANG { get; set; }
        public virtual DbSet<SF_CUAHANGYEUTHICH> SF_CUAHANGYEUTHICH { get; set; }
        public virtual DbSet<SF_CHITIETGIAMGIA> SF_CHITIETGIAMGIA { get; set; }
        public virtual DbSet<SF_CHITIETTHUOCTINHSANPHAM> SF_CHITIETTHUOCTINHSANPHAM { get; set; }
        public virtual DbSet<SF_CHITIETVANCHUYEN> SF_CHITIETVANCHUYEN { get; set; }
        public virtual DbSet<SF_CHITIETHINHANHSANPHAM> SF_CHITIETHINHANHSANPHAM { get; set; }
        public virtual DbSet<SF_CHITIETHOADON> SF_CHITIETHOADON { get; set; }
        public virtual DbSet<SF_CHUONGTRINHGIAMGIA> SF_CHUONGTRINHGIAMGIA { get; set; }
        public virtual DbSet<SF_CHUYENMUC> SF_CHUYENMUC { get; set; }
        public virtual DbSet<SF_DANHGIASANPHAM> SF_DANHGIASANPHAM { get; set; }
        public virtual DbSet<SF_DONVITINH> SF_DONVITINH { get; set; }
        public virtual DbSet<SF_GIATRITHUOCTINH> SF_GIATRITHUOCTINH { get; set; }
        public virtual DbSet<SF_HINHANHSANPHAM> SF_HINHANHSANPHAM { get; set; }
        public virtual DbSet<SF_HOADON> SF_HOADON { get; set; }
        public virtual DbSet<SF_KHACHHANG> SF_KHACHHANG { get; set; }
        public virtual DbSet<SF_KHOANGCACH> SF_KHOANGCACH { get; set; }
        public virtual DbSet<SF_NHANVIENQUANTRI> SF_NHANVIENQUANTRI { get; set; }
        public virtual DbSet<SF_NHOMQUYEN> SF_NHOMQUYEN { get; set; }
        public virtual DbSet<SF_PHUONGTHUCVANCHUYEN> SF_PHUONGTHUCVANCHUYEN { get; set; }
        public virtual DbSet<SF_QUANHUYEN> SF_QUANHUYEN { get; set; }
        public virtual DbSet<SF_SANPHAM> SF_SANPHAM { get; set; }
        public virtual DbSet<SF_THANHPHO> SF_THANHPHO { get; set; }
        public virtual DbSet<SF_THUOCTINH> SF_THUOCTINH { get; set; }
    }
}
