//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEB2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietGioHang
    {
        public int ID { get; set; }
        public int ID_GioHang { get; set; }
        public int ID_MonAn { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public System.DateTime NgayTao { get; set; }
        public System.DateTime ThayDoiCuoiCung { get; set; }
    
        public virtual GioHang GioHang { get; set; }
        public virtual MonAn MonAn { get; set; }
    }
}
