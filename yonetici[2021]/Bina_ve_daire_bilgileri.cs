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
    public partial class Bina_ve_daire_bilgileri : Form
    {
        public Bina_ve_daire_bilgileri()
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
            
            komut.CommandText = ("Select * From Binalar");
            
            OleDbDataReader oku = komut.ExecuteReader();
           


            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["Bina_ad"].ToString());
                ekle1.SubItems.Add(oku["Yapim_yili"].ToString());
                listView1.Items.Add(ekle1);
                comboBox1.Items.Add(oku["Bina_ad"]);







            }
            baglanti.Close();



        }
        private void verilerigoruntule2()
        {  
            listView2.Items.Clear();
            baglanti.Open();
         
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;

            komut.CommandText = ("Select * From Daireler");

            OleDbDataReader oku = komut.ExecuteReader();



            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
               
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["daire_no"].ToString());
                ekle1.SubItems.Add(oku["Bina_adi"].ToString());
                listView2.Items.Add(ekle1);
                
               







            }
            baglanti.Close();



        }
        private void Bina_ve_daire_bilgileri_Load(object sender, EventArgs e)
        {

            verilerigoruntule();
            verilerigoruntule2();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ( textBox3.Text == "" || textBox2.Text == "")
            {
                textBox2.BackColor = Color.Yellow;
                textBox3.BackColor = Color.Yellow;
                
                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            { 

                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("insert into Binalar(Bina_ad,yapim_yili) values('" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                verilerigoruntule();

                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Bina eklendi");
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


            textBox2.Text = listView1.Items[var2].SubItems[1].Text;
            textBox3.Text = listView1.Items[var2].SubItems[2].Text;
            textBox1.Text = listView1.Items[var2].SubItems[0].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                textBox2.BackColor = Color.Yellow;
                textBox3.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int kim = Convert.ToInt32(textBox1.Text);

                komut.CommandText = "update Binalar set Bina_ad='" + textBox2.Text + "',Yapim_yili='" + textBox3.Text + "'where kimlik=" + kim;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                MessageBox.Show("Bina güncellendi");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.Yellow;
                textBox3.BackColor = Color.Yellow;
                
                MessageBox.Show("Lütfen silmek istediğiniz alanı seçin!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox1.Text);

                komut.CommandText = "Delete from Binalar where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Veriler silindi!");
            }
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lcount;
            int var2 = 0;
            if (listView2.SelectedItems.Count > 0)
            {
                for (lcount = 0; lcount <= listView2.Items.Count - 1; lcount++)
                {
                    if (listView2.Items[lcount].Selected == true)
                    {
                        var2 = lcount;
                        break;
                    }
                }
            }


            textBox5.Text = listView2.Items[var2].SubItems[1].Text;
           
            textBox1.Text = listView2.Items[var2].SubItems[0].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || comboBox1.Text == "")
            {
                textBox5.BackColor = Color.Yellow;
                comboBox1.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("insert into Daireler(daire_no,Bina_adi) values('" + textBox5.Text.ToString() + "','" + comboBox1.SelectedItem.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                verilerigoruntule2();

                textBox5.Clear();
               
                MessageBox.Show("Veriler eklendi");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "")
            {
                textBox1.BackColor = Color.Yellow;
                comboBox1.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                int sayi = Convert.ToInt32(textBox5.Text);
                int kim = Convert.ToInt32(textBox1.Text);

                komut.CommandText = "update Daireler set daire_no=" + sayi + ",Bina_adi='" + comboBox1.SelectedItem.ToString() + "'where kimlik=" + kim;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule2();
                MessageBox.Show("Veriler güncellendi");
            }
        }

        private void button6_Click(object sender, EventArgs e)
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

                komut.CommandText = "Delete from Daireler where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule2();
                textBox1.Clear();
                textBox5.Clear();

               
                MessageBox.Show("Veriler silindi!");
           
               
            }
        }
    }
}
