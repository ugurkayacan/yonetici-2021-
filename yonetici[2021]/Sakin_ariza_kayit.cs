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
    public partial class Sakin_ariza_kayit : Form
    {
        public Sakin_ariza_kayit()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\yonetici.accdb");
        OleDbCommand komut = new OleDbCommand();
       
        private void Sakin_ariza_kayit_Load(object sender, EventArgs e)
        {
            
            
           


            


            sakin_yasam s = new sakin_yasam();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == ""  || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || richTextBox1.Text == "")
            {

                textBox1.BackColor = Color.Yellow;
                textBox2.BackColor = Color.Yellow;
                textBox3.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                richTextBox1.BackColor = Color.Yellow;


                textBox5.BackColor = Color.Yellow;



                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("insert into Arizalar(Ariza_aciklama,isim,soy_isim,telefon,daire_no,bina_adi,tarih) values('" + richTextBox1.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + dateTimePicker1.Value.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();


                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                richTextBox1.Clear();
                MessageBox.Show("Arıza kaydınız başarıyla alınmıştır!");
            }

        }
    }
}
