//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Satislar
    {
        public int SatisId { get; set; }
        public int UrunId { get; set; }
        public int MusteriId { get; set; }
        public int Adet { get; set; }
        public System.DateTime Tarih { get; set; }
    
        public virtual Musteriler Musteriler { get; set; }
        public virtual Urunler Urunler { get; set; }
    }
}