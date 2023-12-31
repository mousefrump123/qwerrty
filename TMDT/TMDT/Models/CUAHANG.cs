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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class CUAHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUAHANG()
        {
            HINHANH = "~/Areas/Admin/Content/img/iconanh.png";
            ANHDAIDIEN = "~/Areas/Admin/Content/img/iconanh.png";
            this.DONHANGs = new HashSet<DONHANG>();
            this.QUANGCAOs = new HashSet<QUANGCAO>();
            this.SANPHAMs = new HashSet<SANPHAM>();
            this.VOUCHERSHOPs = new HashSet<VOUCHERSHOP>();
        }
        [NotMapped]
        public HttpPostedFileBase UploadImage1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImage2 { get; set; }
        public int IDCUAHANG { get; set; }
        public string DIACHI { get; set; }
        public string HINHANH { get; set; }
        public string ANHDAIDIEN { get; set; }
        public Nullable<int> IDND { get; set; }
        public string TENCH { get; set; }
        public Nullable<int> IDTP { get; set; }
    
        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
        public virtual THANHPHO THANHPHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUANGCAO> QUANGCAOs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VOUCHERSHOP> VOUCHERSHOPs { get; set; }
    }
}
