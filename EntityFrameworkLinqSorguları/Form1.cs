using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkLinqSorguları
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OkulEntities okulEntities = new OkulEntities();
        private void btn_LinqEntity_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                var degerler = okulEntities.Notlar.Where(n => n.Sinav1 > 50);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton2.Checked==true)
            {
                var degerler = okulEntities.Ogrenci.Where(a => a.OgrAd == "leyla");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton3.Checked == true)
            {
                var degerler = okulEntities.Ogrenci.Where(a => a.OgrAd == textBox1.Text || a.OgrSoyad==textBox1.Text);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton4.Checked == true)
            {
                var degerler = okulEntities.Ogrenci.Select(a => new { Soyad = a.OgrSoyad });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton5.Checked == true)
            {
                var degerler = okulEntities.Ogrenci.Select(a => new { Ad=a.OgrAd.ToUpper(), Soyad = a.OgrSoyad.ToLower() });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton6.Checked == true)
            {
                var degerler = okulEntities.Ogrenci.Select(a => new { Ad = a.OgrAd.ToUpper(), Soyad = a.OgrSoyad.ToLower() }).Where(a=> a.Ad !="Leyla");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton7.Checked==true)
            {
                var degerler = okulEntities.Notlar.Select(a =>
                new
                {
                    OgrenciAd = a.Ogr,
                    Ortalaması = a.Ortalama,
                    Durum = a.Durum ==true ? "Geçti" : "Kaldı"
                });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton8.Checked==true)
            {
                var degerler = okulEntities.Notlar.SelectMany(x => okulEntities.Ogrenci.Where(y => y.Id == x.Ogr),
                    (x, y) => new { y.OgrAd, x.Ortalama });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton9.Checked == true)
            {
                var degerler = okulEntities.Ogrenci.OrderBy(a => a.Id).Take(3);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton10.Checked == true)
            {
                var degerler = okulEntities.Ogrenci.OrderByDescending(a => a.Id).Take(3);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton11.Checked == true)
            {
                var degerler = okulEntities.Ogrenci.OrderBy(a => a.OgrAd);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton12.Checked == true)
            {
                var degerler = okulEntities.Ogrenci.OrderBy(a => a.Id).Skip(5);
                dataGridView1.DataSource = degerler.ToList();
            }
        }
    }
}
