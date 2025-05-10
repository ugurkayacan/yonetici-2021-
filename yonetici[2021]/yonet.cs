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
    public partial class yonet : Form
    {
        public yonet()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\yonetici.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void verilerigoruntule()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From yoneticiye_ileti");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["gonderen_ad"].ToString());
                ekle1.SubItems.Add(oku["gonderen_soyad"].ToString());
                ekle1.SubItems.Add(oku["tarih"].ToString());
                ekle1.SubItems.Add(oku["bina"].ToString());
                ekle1.SubItems.Add(oku["daire"].ToString());

                listView1.Items.Add(ekle1);


            }
            baglanti.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aydat_Bilgisi_Ve_Gelirler a = new Aydat_Bilgisi_Ve_Gelirler();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bina_ve_daire_bilgileri b = new Bina_ve_daire_bilgileri();
            b.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Personel p = new Personel();
            p.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Giderler g = new Giderler();
            g.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rapor r = new Rapor();
            r.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bina_sakinleri bs = new Bina_sakinleri();
            bs.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Yeni_Kullanici_ekle y = new Yeni_Kullanici_ekle();
            y.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bina_sakinlerine_ileti bi = new Bina_sakinlerine_ileti();
            bi.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Yonetici_arizalari_goruntule yg = new Yonetici_arizalari_goruntule();
            yg.Show();
        }

        private void yonet_Load(object sender, EventArgs e)
        {
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
            textBox1.Text = listView1.Items[var2].SubItems[0].Text;
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From yoneticiye_ileti where kimlik=" + Convert.ToInt32(listView1.Items[var2].SubItems[0].Text));
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                 richTextBox1.Text= oku["ileti"].ToString();


            }

            baglanti.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {


                textBox1.BackColor = Color.Yellow;

                MessageBox.Show("Lütfen silmek istediğiniz veriyi seçin!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox1.Text);

                komut.CommandText = "Delete from yoneticiye_ileti where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                textBox1.Clear();
                richTextBox1.Clear();
              
                MessageBox.Show("Veriler silindi!");
            }
        }
    }
}
