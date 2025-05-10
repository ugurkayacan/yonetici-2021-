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
    public partial class sakin_yasam : Form
    {
        public sakin_yasam()
        {
            InitializeComponent();
        }
        public String Kullanici;
        public String Bina;
        public String daire;
        public String ad;
        public String soyad;
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\yonetici.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void verilerigoruntule()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Yonetici_ileti");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                
                ekle1.SubItems.Add(oku["tarih"].ToString());
                

                listView1.Items.Add(ekle1);


            }
            baglanti.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sakin_aydat_bilgisi_görüntüle b = new Sakin_aydat_bilgisi_görüntüle();
            b.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sakin_bilgileri_goruntulemesi s = new Sakin_bilgileri_goruntulemesi();
            s.KullaniciG = Kullanici;
            s.BinaG = Bina;
            s.daireG = daire;
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sakin_ariza_kayit a = new Sakin_ariza_kayit();
            
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Yoneticiye_ileti_gonder ye = new Yoneticiye_ileti_gonder();
            ye.Kullanici = Kullanici;
            ye.Bina = Bina;
            ye.daire = daire;
            ye.ad = ad;
            ye.soyad = soyad;
            ye.Show();
        }

        private void sakin_yasam_Load(object sender, EventArgs e)
        {
            textBox1.Text = Kullanici;
            textBox2.Text = Bina;
            textBox3.Text = daire;
            textBox5.Text = ad;
            textBox4.Text = soyad;
            verilerigoruntule();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lcount;
            int var2 = 0;
            if (listView1.SelectedItems.Count > 0)
            {
                for (lcount = 0; lcount <= listView1.Items.Count - 1; lcount++)
                {
                    if (listView1.Items[lcount].Selected == true)
                    {
                        var2 = lcount;
                        break;
                    }
                }
            }
            
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            
            komut.CommandText = ("Select yileti From Yonetici_ileti where kimlik=" + Convert.ToInt32(listView1.Items[var2].SubItems[0].Text));
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                richTextBox1.Text = oku["yileti"].ToString();
            }
            baglanti.Close();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
