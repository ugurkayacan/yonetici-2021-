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
    public partial class Yonetici_arizalari_goruntule : Form
    {
        public Yonetici_arizalari_goruntule()
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
            komut.CommandText = ("Select * From Arizalar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["isim"].ToString());
                ekle1.SubItems.Add(oku["soy_isim"].ToString());
                ekle1.SubItems.Add(oku["telefon"].ToString());
                ekle1.SubItems.Add(oku["daire_no"].ToString());
                ekle1.SubItems.Add(oku["bina_adi"].ToString());
                ekle1.SubItems.Add(oku["tarih"].ToString());

                listView1.Items.Add(ekle1);


            }

            baglanti.Close();



        }
        private void Yonetici_arizalari_goruntule_Load(object sender, EventArgs e)
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
            komut.CommandText = ("Select * From Arizalar where kimlik="+ Convert.ToInt32(listView1.Items[var2].SubItems[0].Text) );
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                richTextBox1.Text = oku["ariza_aciklama"].ToString();


            }

            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        
               
            
            if (textBox1.Text=="")
            {

               


                MessageBox.Show("Lütfen silmek istediğiniz veriyi seçin!");

            }
            else
            {


                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox1.Text);

                komut.CommandText = "Delete from Arizalar where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();


                verilerigoruntule();
                richTextBox1.Clear();

                MessageBox.Show("Veriler silindi!");


            }
        }
    }
}
