using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.DAL
{
   public static class HelperKullanicilar
    {
        public static Kullanicilar GetByName(string MusteriAdi)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Kullanicilar.Where(x => x.KullaniciAd == MusteriAdi).FirstOrDefault();
            }
        }
        public static (Kullanicilar, bool) CUD(Kullanicilar user, EntityState entityState)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                cr.Entry(user).State = entityState;
                if (cr.SaveChanges() > 0)
                {
                    return (user, true);
                }
                else
                {
                    return (user, false);
                }
            }
        }
    }
}
