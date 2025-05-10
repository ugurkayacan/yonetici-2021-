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
    public partial class Yeni_Kullanici_ekle : Form
    {
        public Yeni_Kullanici_ekle()
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
            komut.CommandText = ("Select * From Kullaniciler");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["kullanici_ad"].ToString());
                ekle1.SubItems.Add(oku["sifre"].ToString());
                ekle1.SubItems.Add(oku["ad"].ToString());
                ekle1.SubItems.Add(oku["soyad"].ToString());
                ekle1.SubItems.Add(oku["sifat"].ToString());
                ekle1.SubItems.Add(oku["daire"].ToString());
                ekle1.SubItems.Add(oku["Bina"].ToString());


                listView1.Items.Add(ekle1);


            }

            baglanti.Close();



        }
        private void verilerigoruntule2()
        {
          
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Binalar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["Bina_ad"].ToString());


            }

            baglanti.Close();



        }
        private void Yeni_Kullanici_ekle_Load(object sender, EventArgs e)
        {
            verilerigoruntule();
            verilerigoruntule2();
            comboBox1.Items.Add("Yönetici");
            comboBox1.Items.Add("Sakin");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""  || textBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {

                textBox3.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                comboBox1.BackColor = Color.Yellow;
                comboBox2.BackColor = Color.Yellow;
                textBox1.BackColor = Color.Yellow;
                textBox2.BackColor = Color.Yellow;
                
                textBox6.BackColor = Color.Yellow;
                comboBox1.BackColor = Color.Yellow;
                comboBox2.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("insert into Kullaniciler(kullanici_ad,sifre,ad,soyad,sifat,daire,Bina) values('" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox6.Text.ToString() + "','" + comboBox2.SelectedItem.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                verilerigoruntule();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
                MessageBox.Show("Veriler eklendi!");
            }


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

            textBox1.Text = listView1.Items[var2].SubItems[3].Text;
            textBox2.Text = listView1.Items[var2].SubItems[4].Text;
            textBox3.Text = listView1.Items[var2].SubItems[1].Text;
            textBox4.Text = listView1.Items[var2].SubItems[2].Text;
            textBox5.Text = listView1.Items[var2].SubItems[0].Text;
            comboBox1.Text= listView1.Items[var2].SubItems[5].Text;
            textBox6.Text = listView1.Items[var2].SubItems[6].Text;
            comboBox2.Text = listView1.Items[var2].SubItems[7].Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {


                textBox5.BackColor = Color.Yellow;

                MessageBox.Show("Lütfen silmek istediğiniz veriyi seçin!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox5.Text);

                komut.CommandText = "Delete from Kullaniciler where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox6.Clear();
                textBox5.Clear();
                MessageBox.Show("Veriler silindi!");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {

                textBox3.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                comboBox1.BackColor = Color.Yellow;
                comboBox2.BackColor = Color.Yellow;
                textBox5.BackColor = Color.Yellow;
                textBox6.BackColor = Color.Yellow;
                comboBox1.BackColor = Color.Yellow;
                comboBox2.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            { 
            baglanti.Open();
            komut.Connection = baglanti;
               
                    int kim = Convert.ToInt32(textBox5.Text);

                    komut.CommandText = "update Kullaniciler set kullanici_ad='" + textBox3.Text + "',sifre='" + textBox4.Text + "',ad='" + textBox1.Text + "',soyad='" + textBox2.Text + "',sifat='" + comboBox1.SelectedItem.ToString() + "',daire='" + textBox6.Text + "',Bina='" + comboBox2.SelectedItem.ToString() + "'where kimlik=" + kim;
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                
                 baglanti.Close();
                 
                    verilerigoruntule();
                    MessageBox.Show("Veriler güncellendi!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
