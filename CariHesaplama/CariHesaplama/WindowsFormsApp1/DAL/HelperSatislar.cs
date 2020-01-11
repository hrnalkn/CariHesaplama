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
   public static class HelperSatislar
    {
        public static (Satislar, bool) CUD(Satislar s, EntityState state)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                cr.Entry(s).State = state;
                if (cr.SaveChanges() > 0)
                {
                    return (s, true);
                }
                else
                {
                    return (s, false);
                }
            }
        }
        public static List<Satislar> GetList()
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Satislar.ToList();
            }
        }
        public static List<SatislarModel> GetSatislarModelList()
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                List<Satislar> satislar = GetList();
                List<SatislarModel> satisModel = new List<SatislarModel>();
                foreach (var item in satislar)
                {
                    SatislarModel satisModel1 = new SatislarModel();
                    satisModel1.SatisId = item.SatisId;
                    satisModel1.Adet = item.Adet;
                    satisModel1.Tarih = item.Tarih;
                    satisModel1.Urunler = HelperUrunler.GetByID((int)item.UrunId);
                    satisModel1.Musteriler = HelperMusteriler.GetByID((int)item.MusteriId);
                    satisModel.Add(satisModel1);
                }
                return satisModel;
            }
        }
        public static List<SatislarModel> GetSatisModelByMüsteriAd(string musteriAd)
        {
            using (carihesapEntities cr=new carihesapEntities())
            {
                List<SatislarModel> satisModel1 = new List<SatislarModel>();
                List<SatislarModel> satisModel2 = GetSatislarModelList();
                foreach (var item in satisModel2)
                {
                    if (item.Musteriler.Ad.ToLower().Contains(musteriAd.ToLower()))
                    {
                        satisModel1.Add(item);
                    }
                }
                return satisModel1;
            }
        }
        public static List<SatislarModel> GetSatisModelByUrunAd(string urunAd)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                List<SatislarModel> satisModel1 = new List<SatislarModel>();
                List<SatislarModel> satisModel2 = GetSatislarModelList();
                foreach (var item in satisModel2)
                {
                    if (item.Urunler.UrunAdi.ToLower().Contains(urunAd.ToLower()))
                    {
                        satisModel1.Add(item);
                    }
                }
                return satisModel1;
            }
        }
        public static List<SatislarModel> GetSatisModelByKategoriad(string kategoriAd)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                List<SatislarModel> satisModel1 = new List<SatislarModel>();
                List<SatislarModel> satisModel2 = GetSatislarModelList();
                foreach (var item in satisModel2)
                {
                    Kategoriler kategori = HelperKategoriler.GetByID((int)item.Urunler.KategoriId);
                    if (kategori.Kategori.ToLower().Contains(kategoriAd.ToLower()))
                    {
                        satisModel1.Add(item);
                    }
                }
                return satisModel1;
            }
        }
    }
}
