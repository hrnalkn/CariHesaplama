using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.DAL
{
    public static class HelperMusteriler
    {
        public static (Musteriler,bool) CUD(Musteriler m,EntityState state)
        {
            using (carihesapEntities cr=new carihesapEntities())
            {
                cr.Entry(m).State = state;
                if (cr.SaveChanges()>0)
                {
                    return (m, true);
                }
                else
                {
                    return (m, false);
                }
            }
        }
        public static List<Musteriler> GetList()
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Musteriler.ToList();
            }
        }
        public static Musteriler GetByID(int musteriId)
        {
            using (carihesapEntities cr = new carihesapEntities())
            {
                return cr.Musteriler.Find(musteriId);
            }
        }

    }
}
