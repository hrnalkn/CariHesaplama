using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.DAL
{
    public static class HelperUrunler
    {
        public static (Urunler, bool) CUD(Urunler u, EntityState state)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                cr.Entry(u).State = state;
                if (cr.SaveChanges() > 0)
                {
                    return (u, true);
                }
                else
                {
                    return (u, false);
                }
            }
        }
        public static List<Urunler> GetList()
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Urunler.ToList();
            }
        }
        public static Urunler GetByID(int urunId)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Urunler.Find(urunId);
            }
        }
        public static List<UrunlerModel> GetList1()
        {
            List<UrunlerModel> uml = new List<UrunlerModel>();
            using (carihesapEntities cr = new carihesapEntities())
            {
                var ff = cr.Urunler.ToList();
                foreach (var item in ff)
                {
                    UrunlerModel um = new UrunlerModel();
                    um.UrunId = item.UrunId;
                    um.UrunAdi = item.UrunAdi;
                    um.AlisFiyat = item.AlisFiyat;
                    um.SatisFiyat = item.SatisFiyat;
                    um.Stok = item.Stok;
                    um.Aciklama = item.Aciklama;
                    um.kategoriler.KategoriId = item.Kategoriler.KategoriId;
                    um.kategoriler.Kategori = item.Kategoriler.Kategori;
                    um.AktifMi = true;
                    uml.Add(um);
                }
                return uml;
            }
        }
        public static List<Urunler> GetUrunByKateroiId(int kategroriId)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Urunler.Where(x => x.KategoriId == kategroriId).ToList();
            }
        }
    }
}
