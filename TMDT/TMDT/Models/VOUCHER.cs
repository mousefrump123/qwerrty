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
    
    public partial class VOUCHER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VOUCHER()
        {
            this.DONHANGs = new HashSet<DONHANG>();
            this.NGUOIDUNGs = new HashSet<NGUOIDUNG>();
        }
    
        public int IDVOUCHER { get; set; }
        public string TENVC { get; set; }
        public Nullable<System.DateTime> NGAYBD { get; set; }
        public Nullable<System.DateTime> NGAYKT { get; set; }
        public Nullable<int> GIATRIVC { get; set; }
        public string DIEUKIEN { get; set; }
        public Nullable<int> SOLUONGSD { get; set; }
        public Nullable<int> DADUNG { get; set; }
        public Nullable<int> GIATRITOITHIEU { get; set; }
        public Nullable<int> IDTRANGTHAIVC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
        public virtual TRANGTHAIVC TRANGTHAIVC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGUOIDUNG> NGUOIDUNGs { get; set; }
    }
}
