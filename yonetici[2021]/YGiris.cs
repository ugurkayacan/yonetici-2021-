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
    public partial class YGiris : Form
    {
        public YGiris()
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
            komut.CommandText = ("Select * From Kullaniciler where kullanici_ad='"+textBox1.Text+"'AND sifre='"+textBox2.Text+ "'AND sifat='"+"Yönetici"+"'");
            OleDbDataReader oku = komut.ExecuteReader(); 
           
            if (oku.Read())
            {
                yonet y = new yonet();
                y.Show();
            }
           
               
                else
                {
                    MessageBox.Show("Kullanıcı adı, şifre yanlış ya da erişim yetkiniz yok");
                }
            
            
           


            baglanti.Close();

        }

        private void YGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
