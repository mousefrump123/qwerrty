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
    
    public partial class THTHOITRANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THTHOITRANG()
        {
            this.CTTHOITRANGs = new HashSet<CTTHOITRANG>();
        }
        public List<THTHOITRANG> ListBrands { get; set; }
        public int IDTHTHOITRANG { get; set; }
        public string THUONGHIEUTT { get; set; }
        public Nullable<int> IDLOAISP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTHOITRANG> CTTHOITRANGs { get; set; }
        public virtual LOAISP LOAISP { get; set; }
    }
}
