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
    public partial class Sakin_bilgileri_goruntulemesi : Form
    {
        public Sakin_bilgileri_goruntulemesi()
        {
            InitializeComponent();
        }
        public String KullaniciG;
        public String BinaG;
        public String daireG;
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\yonetici.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void verilerigoruntule()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Sakinler");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                int sayi =Convert.ToInt32( oku["daire_no"]);
                String bina = oku["Bina_ad"].ToString();
                int karsilastirma = Convert.ToInt32(daireG);
                if(sayi==karsilastirma && bina==BinaG)
                { 
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["ad"].ToString());
                ekle1.SubItems.Add(oku["soyad"].ToString());
                ekle1.SubItems.Add(oku["Bina_ad"].ToString());
                ekle1.SubItems.Add(oku["daire_no"].ToString());
                ekle1.SubItems.Add(oku["kiraci_evsahibi"].ToString());
                listView1.Items.Add(ekle1);
                    }

            }

            baglanti.Close();



        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Sakin_bilgileri_goruntulemesi_Load(object sender, EventArgs e)
        {
            verilerigoruntule();
            label4.Text = KullaniciG;
            label5.Text = BinaG;
            label6.Text = daireG;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
