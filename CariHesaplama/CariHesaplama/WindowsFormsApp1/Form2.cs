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
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Kullanicilar user = new Kullanicilar();
        public Form2(Kullanicilar user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Musteriler m = new Musteriler()
            {
                Ad = textBox1.Text,
                Soyad = textBox2.Text,
                Tel = maskedTextBox1.Text,
                Adres = textBox3.Text,
                AktifMi = true,
                KayitTarihi=DateTime.Now
            };
            var ekle = HelperMusteriler.CUD(m, System.Data.Entity.EntityState.Added);
            if (ekle.Item2)
            {
                MessageBox.Show("Ekleme Başarılı.");
            }
            else
            {
                MessageBox.Show("Ekleme Yapılamadı..");
            }
            Refresh();
        }
        public void Refresh()
        {
            dataGridView1.Rows.Clear();
            List<Musteriler> musteri = HelperMusteriler.GetList();
            foreach (var item in musteri)
            {
                if (item.AktifMi == true)
                {
                    dataGridView1.Rows.Add(item.müsteriId,item.Ad, item.Soyad, item.Tel, item.Adres);
                }
            }
        }
        public void ProductRefresh()
        {
            dataGridView2.Rows.Clear();
            List<Urunler> urun = HelperUrunler.GetList();
            foreach (var item in urun)
            {
                Kategoriler kategori = HelperKategoriler.GetByID(item.KategoriId);
                if (item.AktifMi == true)
                {
                    dataGridView2.Rows.Add(item.UrunId,item.UrunAdi, kategori.Kategori, item.AlisFiyat, item.SatisFiyat, item.Stok,item.Aciklama);
                }
            }
        }
        public void CategoryRefresh()
        {
            dataGridView3.Rows.Clear();
            List<Kategoriler> kategori = HelperKategoriler.GetList();
            foreach (var item in kategori)
            {
                if (item.AktifMi == true)
                {
                    dataGridView3.Rows.Add(item.KategoriId, item.Kategori, item.Aciklama);
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label10.Text = $"{user.KullaniciAd}";
            dataGridView4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            button4.Enabled = false;
            Refresh();
            CategoryRefresh();
            ProductRefresh();
            List<Kategoriler> kategori = HelperKategoriler.GetList();
            foreach (var item in kategori)
            {
                if (item.AktifMi==true)
                {
                    comboBox1.Items.Add(item.Kategori);
                    comboBox2.Items.Add(item.Kategori);
                    comboBox3.Items.Add(item.Kategori);
                    comboBox5.Items.Add(item.Kategori);
                    comboBox6.Items.Add(item.KategoriId);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Musteriler mn = HelperMusteriler.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            mn.Ad = textBox6.Text;
            mn.Soyad = textBox5.Text;
            mn.Adres = textBox4.Text;
            mn.Tel = maskedTextBox2.Text;
            var degistir = HelperMusteriler.CUD(mn, System.Data.Entity.EntityState.Modified);
            if (degistir.Item2)
            {
                MessageBox.Show("Güncelleme başarılı.");
            }
            else
            {
                MessageBox.Show("Güncelleme yapılamadı.");
            }
            Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteriler m = HelperMusteriler.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
            textBox6.Text = m.Ad;
            textBox5.Text = m.Soyad;
            textBox4.Text = m.Adres;
            maskedTextBox2.Text = m.Tel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show(" Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                Musteriler m = HelperMusteriler.GetByID(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));
                m.AktifMi = false;
                var b = HelperMusteriler.CUD(m,System.Data.Entity.EntityState.Modified);
                if (b.Item2)
                {
                    MessageBox.Show("Silme işlemi başarılı");
                }
                else
                {
                    MessageBox.Show("Silme yapılamadı");
                }
            }
            Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<Kategoriler> kategori = HelperKategoriler.GetList();
            Urunler u = new Urunler();
            u.UrunAdi = textBox7.Text;
            u.AlisFiyat = Convert.ToInt32(textBox8.Text);
            u.SatisFiyat = Convert.ToInt32(textBox9.Text);
            u.Stok = Convert.ToInt32(textBox10.Text);
            u.AktifMi = true;
            u.KayitTarihi = DateTime.Now;
            foreach (var item in kategori)
            {
                if (item.Kategori.ToLower()==comboBox1.Text.ToLower())
                {
                    u.KategoriId = item.KategoriId;
                    break;
                }
            }
            u.Aciklama = textBox11.Text;
            var ekle = HelperUrunler.CUD(u, System.Data.Entity.EntityState.Added);
            if (ekle.Item2)
            {
                MessageBox.Show("Ekleme Başarılı.");
            }
            else
            {
                MessageBox.Show("Ekleme Yapılamadı..");
            }
            ProductRefresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Kategoriler k = new Kategoriler()
            {
                Kategori = textBox17.Text,
                Aciklama = textBox18.Text,
                AktifMi = true,
                KayitTarih = DateTime.Now
            };
            var ekle = HelperKategoriler.CUD(k, System.Data.Entity.EntityState.Added);
            if (ekle.Item2)
            {
                MessageBox.Show("Ekleme Başarılı.");
            }
            else
            {
                MessageBox.Show("Ekleme Yapılamadı..");
            }
            CategoryRefresh();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Kategoriler k = HelperKategoriler.GetByID(Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value));
            textBox20.Text = k.Kategori;
            textBox19.Text = k.Aciklama;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Kategoriler kk = HelperKategoriler.GetByID(Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value));
            kk.Kategori = textBox20.Text;
            kk.Aciklama= textBox19.Text;
            var degistir = HelperKategoriler.CUD(kk, System.Data.Entity.EntityState.Modified);
            if (degistir.Item2)
            {
                MessageBox.Show("Güncelleme başarılı.");
            }
            else
            {
                MessageBox.Show("Güncelleme yapılamadı.");
            }
            CategoryRefresh();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show(" Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                Kategoriler k = HelperKategoriler.GetByID(Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value));
                k.AktifMi = false;
                var b = HelperKategoriler.CUD(k, System.Data.Entity.EntityState.Modified);
                if (b.Item2)
                {
                    MessageBox.Show("Silme işlemi başarılı");
                }
                else
                {
                    MessageBox.Show("Silme yapılamadı");
                }
            }
            CategoryRefresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Urunler u = HelperUrunler.GetByID(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value));
            Kategoriler k = HelperKategoriler.GetByID(u.KategoriId);
            comboBox2.Text = k.Kategori;
            textBox16.Text = u.UrunAdi;
            textBox15.Text = u.AlisFiyat.ToString();
            textBox14.Text = u.SatisFiyat.ToString();
            textBox13.Text = u.Stok.ToString();
            textBox12.Text = u.Aciklama;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            List<Kategoriler> kategori = HelperKategoriler.GetList();
            Urunler u = HelperUrunler.GetByID(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value));
            u.UrunAdi = textBox16.Text;
            u.AlisFiyat = Convert.ToInt32(textBox15.Text);
            u.SatisFiyat = Convert.ToInt32(textBox14.Text);
            u.Stok = Convert.ToInt32(textBox13.Text);
            u.Aciklama = textBox12.Text;

            foreach (var item in kategori)
            {
                if (item.Kategori.ToLower()==comboBox2.Text.ToLower())
                {
                    u.KategoriId = item.KategoriId;
                    break;
                }
            }
            var degistir = HelperUrunler.CUD(u, System.Data.Entity.EntityState.Modified);
            if (degistir.Item2)
            {
                MessageBox.Show("Güncelleme başarılı.");
            }
            else
            {
                MessageBox.Show("Güncelleme yapılamadı.");
            }
            ProductRefresh();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var a = MessageBox.Show(" Silmek istediğinize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                Urunler u = HelperUrunler.GetByID(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value));
                u.AktifMi = false;
                var b = HelperUrunler.CUD(u, System.Data.Entity.EntityState.Modified);
                if (b.Item2)
                {
                    MessageBox.Show("Silme işlemi başarılı");
                }
                else
                {
                    MessageBox.Show("Silme yapılamadı");
                }
            }
            ProductRefresh();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            if (textBox21.Text == user.Sifre)
            {
                if (textBox22.Text == textBox23.Text)
                {
                    user.Sifre = textBox23.Text;
                    var a = HelperKullanicilar.CUD(user, System.Data.Entity.EntityState.Modified);
                    if (a.Item2)
                    {
                        textBox23.Clear();
                        textBox24.Clear();
                        textBox25.Clear();
                        label32.Text = null;
                        MessageBox.Show("Kullanıcı şifreniz değiştirildi.");
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı şifreniz değiştirilemedi.");
                    }
                }
                else
                {
                    MessageBox.Show( "Girdiğiniz yeni şifreler uyuşmuyor.");
                }
            }
            else
            {
                MessageBox.Show("Geçerli şifreyi yanlış girdiniz. ");
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            dataGridView4.Rows.Clear();
            dataGridView4.Visible = true;
            comboBox5.Items.Clear();
            comboBox4.Items.Clear();
            List<Urunler> urun = HelperUrunler.GetUrunByKateroiId(Convert.ToInt32(comboBox6.Items[comboBox3.SelectedIndex]));
            foreach (var item in urun)
            {
                if (item.AktifMi==true)
                {
                    dataGridView4.Rows.Add(item.UrunId,item.UrunAdi, item.SatisFiyat, item.Aciklama);
                }
            }
            List<Musteriler> mus = HelperMusteriler.GetList();
            foreach (var item in mus)
            {
                if (item.AktifMi==true)
                {
                    comboBox5.Items.Add(item.müsteriId);
                    comboBox4.Items.Add(item.Ad + " " + item.Soyad);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Urunler u = HelperUrunler.GetByID(Convert.ToInt32(dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[0].Value));
            if (u.Stok==0)
            {
                MessageBox.Show("Stokta ürün bulunmamaktadır.");
            }
            else if (u.Stok<Convert.ToInt32(textBox25.Text))
            {
                MessageBox.Show($"Stokta {u.Stok} adet ürün kalmıştır.Adeti düşürünüz.");
            }
            else
            {
                Satislar s = new Satislar();
                s.UrunId = (Convert.ToInt32(dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[0].Value));
                s.Adet =Convert.ToInt32(textBox25.Text);
                s.MusteriId = Convert.ToInt32(comboBox5.Items[comboBox4.SelectedIndex]);
                s.Tarih = DateTime.Now;
                var a = HelperSatislar.CUD(s, System.Data.Entity.EntityState.Added);
                if (a.Item2)
                {
                    MessageBox.Show("Satış eklendi.");
                    u.Stok -= s.Adet;
                    var c = HelperUrunler.CUD(u, System.Data.Entity.EntityState.Modified);
                    if (c.Item2==false)
                    {
                        MessageBox.Show("Stoktan azalma yapılamadı.");
                    }
                }
            }
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            textBox24.Text = dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Lütfen arama yapacağınızı bölgeyi seçiniz.","Bilgilendirme" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                RdbAra();
            }
        }
        public void RdbAra()
        {
            List<SatislarModel> satismodel = new List<SatislarModel>();
            if (radioButton1.Checked)
            {
                satismodel = HelperSatislar.GetSatisModelByUrunAd(textBox26.Text);
            }
            else if (radioButton2.Checked)
            {
                satismodel = HelperSatislar.GetSatisModelByMüsteriAd(textBox26.Text);
            }
            else if (radioButton3.Checked)
            {
                satismodel = HelperSatislar.GetSatisModelByKategoriad(textBox26.Text);
            }
            dataGridView5.Rows.Clear();
            DateTime date1 = new DateTime((int)numericUpDown3.Value, (int)numericUpDown2.Value, (int)numericUpDown1.Value);
            DateTime date2 = new DateTime((int)numericUpDown4.Value, (int)numericUpDown5.Value, (int)numericUpDown6.Value);
            foreach (var item in satismodel)
            {
                if (item.Tarih >= date1 && item.Tarih <= date2)
                {
                    Kategoriler kategori = HelperKategoriler.GetByID((int)item.Urunler.KategoriId);
                    dataGridView5.Rows.Add(item.Musteriler.Ad + " " + item.Musteriler.Soyad, kategori.Kategori, item.Urunler.UrunAdi, item.Adet, item.Urunler.SatisFiyat, item.Tarih);
                }
            }
        }
        public void Ara()
        {
            List<SatislarModel> satismodel = new List<SatislarModel>();
            dataGridView5.Rows.Clear();
            DateTime dateTime1 = new DateTime((int)numericUpDown3.Value, (int)numericUpDown2.Value, (int)numericUpDown1.Value);
            DateTime dateTime2 = new DateTime((int)numericUpDown4.Value, (int)numericUpDown5.Value, (int)numericUpDown6.Value);
            foreach (var item in satismodel)
            {
                if (item.Tarih >= dateTime1 && item.Tarih <= dateTime2)
                {
                    Kategoriler kategori = HelperKategoriler.GetByID((int)item.Urunler.KategoriId);
                    dataGridView5.Rows.Add(item.Musteriler.Ad + " " + item.Musteriler.Soyad, kategori.Kategori, item.Urunler.UrunAdi, item.Adet, item.Urunler.SatisFiyat, item.Tarih);
                }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RdbAra();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           RdbAra();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RdbAra();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ara();
            double a = 0.0;
            List<Satislar> s1 = HelperSatislar.GetList();
            foreach (var item in s1)
            {
                int adet= item.Adet;
                Urunler u1 = HelperUrunler.GetByID(item.UrunId);
                int satis = u1.SatisFiyat;
                int alis = u1.AlisFiyat;
                a += (satis - alis) * adet;
            }
            label44.Text = a.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
