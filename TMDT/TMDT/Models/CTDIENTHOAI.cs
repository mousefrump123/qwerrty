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
    
    public partial class CTDIENTHOAI
    {
        public int IDCTDIENTHOAI { get; set; }
        public string MANHINH { get; set; }
        public string DOPHANGIAI { get; set; }
        public string CAMERA { get; set; }
        public string HEDH { get; set; }
        public string CHIPXULY { get; set; }
        public string ROM { get; set; }
        public string RAM { get; set; }
        public string MANGDIDONG { get; set; }
        public string SOKHESIM { get; set; }
        public string PIN { get; set; }
        public Nullable<int> IDLOAISP { get; set; }
        public Nullable<int> IDTHDIENTHOAI { get; set; }
        public Nullable<int> IDSANPHAM { get; set; }
    
        public virtual LOAISP LOAISP { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
        public virtual THDIENTHOAI THDIENTHOAI { get; set; }
    }
}