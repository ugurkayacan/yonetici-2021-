using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace yonetici_2021_
{
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\yonetici.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void Genel_Gider_goruntule()
        {
           
            baglanti.Open();
            int genel_gider=0;
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select gider_miktar From Giderler");
            OleDbDataReader oku = komut.ExecuteReader();
            
            
            while (oku.Read())
            {
                genel_gider +=Convert.ToInt32( oku["gider_miktar"]);


            }
            baglanti.Close();

            textBox3.Text = Convert.ToString(genel_gider);

        }
        private void fatura_Gider_goruntule()
        {

            baglanti.Open();
            int fatura_gider = 0;
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select fatura_miktar From Faturalar");
            OleDbDataReader oku = komut.ExecuteReader();


            while (oku.Read())
            {
                fatura_gider += Convert.ToInt32(oku["fatura_miktar"]);


            }
            baglanti.Close();

            textBox1.Text = Convert.ToString(fatura_gider);

        }
        private void personel_Gider_goruntule()
        {

            baglanti.Open();
            int personel_gider = 0;
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select maas From Personel");
            OleDbDataReader oku = komut.ExecuteReader();


            while (oku.Read())
            {
                personel_gider += Convert.ToInt32(oku["maas"]);


            }
            baglanti.Close();

            textBox2.Text = Convert.ToString(personel_gider);

        }
        private void Rapor_Load(object sender, EventArgs e)
        {
            Genel_Gider_goruntule();
            fatura_Gider_goruntule();
            personel_Gider_goruntule();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float d1, d2, d3, toplam;
            d1 = int.Parse(textBox1.Text);
            d2 = int.Parse(textBox2.Text);
            d3 = int.Parse(textBox3.Text);
            toplam = d1 + d2 + d3;
            textBox4.Text = Convert.ToString(toplam);
            float pd1, pd2, pd3;
            pd1 = (d1 / toplam) * 360;
            pd2 = (d2 / toplam) * 360;
            pd3 = (d3 / toplam) * 360;
            Pen p = new Pen(Color.White, 4);
            Graphics g = this.CreateGraphics();
            Rectangle rec = new Rectangle(textBox1.Location.X + textBox1.Size.Width + 100, 50, 250, 250);
            Brush b1 = new SolidBrush(Color.Red);
            Brush b2 = new SolidBrush(Color.Yellow);
            Brush b3 = new SolidBrush(Color.Blue);
            
            g.DrawPie(p, rec, 0, pd1);
            g.FillPie(b1, rec, 0, pd1);
            g.DrawPie(p, rec, pd1, pd2);
            g.FillPie(b2, rec, pd1, pd2);
            g.DrawPie(p, rec, pd1 + pd2, pd3);
            g.FillPie(b3, rec, pd1 + pd2, pd3);
        }

        private void fatura_Click(object sender, EventArgs e)
        {

        }
    }
}
