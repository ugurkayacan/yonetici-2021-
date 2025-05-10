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
    public partial class Sakin_aidat_bilgisi_görüntüle : Form
    {
        public Sakin_aidat_bilgisi_görüntüle()
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
            komut.CommandText = ("Select *  From Aydat_yonetici");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["miktar"].ToString());
                ekle1.SubItems.Add(oku["yururluk_tarihi"].ToString());
                ekle1.SubItems.Add(oku["odeme_tarihi"].ToString());
                
                listView1.Items.Add(ekle1);


            }

            baglanti.Close();



        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sakin_aydat_bilgisi_görüntüle_Load(object sender, EventArgs e)
        {
            verilerigoruntule();
        }
    }
}
