//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_KasaTakip.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Islemler
    {
        public int islem_no { get; set; }
        public Nullable<System.DateTime> islem_tarih { get; set; }
        public string islem_tur { get; set; }
        public string islem_aciklama { get; set; }
        public string islem_odemesekli { get; set; }
        public string islem_girenmiktar { get; set; }
        public string islem_cikanmiktar { get; set; }
        public Nullable<int> kullanici_id { get; set; }
    
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}