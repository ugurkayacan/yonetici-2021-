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
    public partial class SGiriş : Form
    {
        public SGiriş()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\yonetici.accdb");
        OleDbCommand komut = new OleDbCommand();

       
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
 
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Kullaniciler where kullanici_ad='" + textBox1.Text + "'AND sifre='" + textBox2.Text+ "'AND sifat='" + "Sakin" + "'");
            OleDbDataReader oku = komut.ExecuteReader(); 
         
            if (oku.Read())
            {
                
               
                sakin_yasam s = new sakin_yasam();
               
                s.Kullanici = textBox1.Text;
                s.Bina = oku["Bina"].ToString();
                s.daire = oku["daire"].ToString();
                s.ad = oku["ad"].ToString();
                s.soyad = oku["soyad"].ToString();
               
                s.Show();
              
                
             
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış veya giriş yetkiniz  yok!");
            }


            baglanti.Close();
        }

        private void SGiriş_Load(object sender, EventArgs e)
        {

        }
    }
}
