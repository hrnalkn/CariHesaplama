using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.DAL
{
    public static class HelperKategoriler
    {
        public static (Kategoriler, bool) CUD(Kategoriler k, EntityState state)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                cr.Entry(k).State = state;
                if (cr.SaveChanges() > 0)
                {
                    return (k, true);
                }
                else
                {
                    return (k, false);
                }
            }
        }
        public static List<Kategoriler> GetList()
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Kategoriler.ToList();
            }
        }
        public static Kategoriler GetByID(int kategoriId)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Kategoriler.Find(kategoriId);
            }
        }
        public static List<Kategoriler> GetByName(string kategoriAd)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Kategoriler.Where(x => x.Kategori.Contains(kategoriAd)).ToList();
            }
        }
    }
}
