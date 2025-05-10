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
    public partial class Yoneticiye_ileti_gonder : Form
    {
        public Yoneticiye_ileti_gonder()
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

        private void Yoneticiye_ileti_gonder_Load(object sender, EventArgs e)
        {
            label2.Text = Kullanici;
            label3.Text = Bina;
            label4.Text = daire;
            label6.Text = ad;
            label5.Text = soyad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {

                richTextBox1.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("insert into yoneticiye_ileti(ileti,gonderen_ad,gonderen_soyad,kul_ad,daire,Bina,tarih) values('" + richTextBox1.Text.ToString() + "','" + label6.Text.ToString() + "','" + label5.Text.ToString() + "','" + label2.Text.ToString() + "','" + label4.Text.ToString() + "','" + label3.Text.ToString() + "','" + dateTimePicker1.Value.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                richTextBox1.Clear();
                MessageBox.Show("İleti kaydınız başarıyla alınmıştır!!!");
            }

            
           
        }
    }
}
