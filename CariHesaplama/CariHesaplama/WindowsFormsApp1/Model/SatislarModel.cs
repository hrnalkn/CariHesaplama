using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1.Model
{
    public class SatislarModel
    {
        public int SatisId { get; set; }
        public int Adet { get; set; }
        public System.DateTime Tarih { get; set; }

        public Musteriler Musteriler { get; set; }
        public Urunler Urunler { get; set; }
    }
}
