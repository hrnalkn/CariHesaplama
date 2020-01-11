using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.Model
{
    public class UrunlerModel
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int KategoriId { get; set; }
        public int AlisFiyat { get; set; }
        public int SatisFiyat { get; set; }
        public int Stok { get; set; }
        public string Aciklama { get; set; }
        public System.DateTime KayitTarihi { get; set; }
        public bool AktifMi { get; set; }

        public  Kategoriler kategoriler = new Kategoriler();

        public virtual ICollection<Satislar> Satislar { get; set; }
    }
}
