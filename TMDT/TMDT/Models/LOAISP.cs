//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMDT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOAISP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAISP()
        {
            this.CTDIENTHOAIs = new HashSet<CTDIENTHOAI>();
            this.CTGIAYs = new HashSet<CTGIAY>();
            this.CTTHOITRANGs = new HashSet<CTTHOITRANG>();
            this.SANPHAMs = new HashSet<SANPHAM>();
            this.THDIENTHOAIs = new HashSet<THDIENTHOAI>();
            this.THGIAYs = new HashSet<THGIAY>();
            this.THTHOITRANGs = new HashSet<THTHOITRANG>();
        }

        public List<LOAISP> ListCate { get; set; }
        public int IDLOAISP { get; set; }
        public string TENLOAISP { get; set; }
        public string HINHANH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDIENTHOAI> CTDIENTHOAIs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTGIAY> CTGIAYs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTHOITRANG> CTTHOITRANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THDIENTHOAI> THDIENTHOAIs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THGIAY> THGIAYs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THTHOITRANG> THTHOITRANGs { get; set; }
    }
}
