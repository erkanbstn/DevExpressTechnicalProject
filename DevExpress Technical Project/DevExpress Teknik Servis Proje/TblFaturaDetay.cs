//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevExpress_Teknik_Servis_Proje
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblFaturaDetay
    {
        public int FaturaDetayID { get; set; }
        public string Ürün { get; set; }
        public Nullable<short> Adet { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<decimal> Tutar { get; set; }
        public Nullable<int> FaturaID { get; set; }
    
        public virtual TblFaturaBilgi TblFaturaBilgi { get; set; }
    }
}
