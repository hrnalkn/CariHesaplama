using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.Entity;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string kullaniciAd, sifre = null;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullaniciAd = textBox1.Text.Trim();
            sifre = textBox2.Text.Trim();
            Kullanicilar k = HelperKullanicilar.GetByName(kullaniciAd);
            if (k==null)
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış");
            }
            else
            {
                if (k.KullaniciAd == kullaniciAd && k.Sifre == sifre)
                {
                    Form2 frm2 = new Form2(k);
                    frm2.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hatalı giriş !","HATALI GİRİŞ !",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }

        }
    }
}
