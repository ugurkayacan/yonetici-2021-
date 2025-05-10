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
    public partial class Aydat_Bilgisi_Ve_Gelirler : Form
    {
        public Aydat_Bilgisi_Ve_Gelirler()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = "+Application.StartupPath+"\\yonetici.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void verilerigoruntule()
        {
            listView2.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Aydat_yonetici");
            OleDbDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();

                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["miktar"].ToString());
                ekle1.SubItems.Add(oku["yururluk_tarihi"].ToString());
                ekle1.SubItems.Add(oku["odeme_tarihi"].ToString());
                listView2.Items.Add(ekle1);


            }
            baglanti.Close();



        }
        private void verilerigoruntule2()
        {
            listView3.Items.Clear();

            listView3.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Gelirler");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle2 = new ListViewItem();
                ekle2.Text = oku["kimlik"].ToString();
                ekle2.SubItems.Add(oku["gelir_miktar"].ToString());
                ekle2.SubItems.Add(oku["aciklama"].ToString());
                listView3.Items.Add(ekle2);


            }
            baglanti.Close();



        }

        private void Aydat_Bilgisi_Ve_Gelirler_Load(object sender, EventArgs e)
        {

           verilerigoruntule();
           verilerigoruntule2();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if(textBox1.Text==""|| textBox3.Text==""|| textBox4.Text=="")
            {
                textBox1.BackColor = Color.Yellow;
                textBox3.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
             else
            { 
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into Aydat_yonetici(miktar,yururluk_tarihi,odeme_tarihi) values('"+textBox1.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+textBox4.Text.ToString()+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
           
            verilerigoruntule();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
                MessageBox.Show("Aydat eklendi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {

                MessageBox.Show("Lütfen silmek istediğiniz alanı seçiniz!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox5.Text);

                komut.CommandText = "Delete from Aydat_yonetici where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                textBox5.Clear();
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
                MessageBox.Show("Veri silindi");
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

            textBox1.Text = listView2.Items[var2].SubItems[1].Text;
            textBox3.Text = listView2.Items[var2].SubItems[2].Text;
            textBox4.Text = listView2.Items[var2].SubItems[3].Text;
            textBox5.Text = listView2.Items[var2].SubItems[0].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                textBox1.BackColor = Color.Yellow;
                textBox3.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {

                baglanti.Open();
                komut.Connection = baglanti;
                int sayi = Convert.ToInt32(textBox5.Text);
                int deger = Convert.ToInt32(textBox1.Text);

                komut.CommandText = "update Aydat_yonetici set miktar=" + deger + ",yururluk_tarihi='" + textBox3.Text + "',odeme_tarihi='" + textBox4.Text + "'where kimlik=" + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                MessageBox.Show("Veriler güncellendi");
                textBox1.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "" )
            {
                textBox7.BackColor = Color.Yellow;
                textBox8.BackColor = Color.Yellow;
                
                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("insert into Gelirler(gelir_miktar,aciklama) values('" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                verilerigoruntule2();

                textBox7.Clear();
                textBox8.Clear();
                textBox5.Clear();
                MessageBox.Show("Veriler eklendi!");
            }
        }

        

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lcount;
            int var2 = 0;
            if (listView3.SelectedItems.Count > 0)
            {
                for (lcount = 0; lcount <= listView3.Items.Count - 1; lcount++)
                {
                    if (listView3.Items[lcount].Selected == true)
                    {
                        var2 = lcount;
                        break;
                    }
                }
            }

           
            textBox7.Text = listView3.Items[var2].SubItems[1].Text;
            textBox8.Text = listView3.Items[var2].SubItems[2].Text;
            textBox5.Text = listView3.Items[var2].SubItems[0].Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.BackColor = Color.Yellow;
              
                MessageBox.Show("Lütfen silmek istediğiniz bir alan seçin!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox5.Text);

                komut.CommandText = "Delete from Gelirler where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule2();
                textBox5.Clear();
                textBox7.Clear();
                textBox8.Clear();
                MessageBox.Show("Veriler silindi");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "")
            {
                textBox7.BackColor = Color.Yellow;
                textBox8.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {

                baglanti.Open();
                komut.Connection = baglanti;
                int sayi = Convert.ToInt32(textBox7.Text);
                int kim = Convert.ToInt32(textBox5.Text);

                komut.CommandText = "update Gelirler set gelir_miktar=" + sayi + ",aciklama='" + textBox8.Text + "'where kimlik=" + kim;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule2();
                
                textBox8.Clear();
                textBox7.Clear();
                textBox5.Clear();
                MessageBox.Show("Veriler güncellendi!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = dateTimePicker1.Value.ToString();
        }
    }
}
