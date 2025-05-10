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
    public partial class Personel : Form
    {
        public Personel()
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
            komut.CommandText = ("Select * From Personel");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["per_ad"].ToString());
                ekle1.SubItems.Add(oku["per_soyad"].ToString());
                ekle1.SubItems.Add(oku["maas"].ToString());
                ekle1.SubItems.Add(oku["gorev"].ToString());
                ekle1.SubItems.Add(oku["telefon"].ToString());
                listView1.Items.Add(ekle1);


            }
            baglanti.Close();



        }
        private void Personel_Load(object sender, EventArgs e)
        {
            verilerigoruntule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == ""||textBox3.Text=="")
            {
                textBox1.BackColor = Color.Yellow;
                textBox2.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                textBox5.BackColor = Color.Yellow;
                textBox3.BackColor = Color.Yellow;
                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();
                int sayi = Convert.ToInt32(textBox3.Text);
                OleDbCommand komut = new OleDbCommand("insert into Personel(per_ad,per_soyad,maas,gorev,telefon) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + sayi + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                verilerigoruntule();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
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

            textBox6.Text = listView1.Items[var2].SubItems[0].Text;
            textBox1.Text = listView1.Items[var2].SubItems[1].Text;
            textBox2.Text = listView1.Items[var2].SubItems[2].Text;
            textBox3.Text = listView1.Items[var2].SubItems[3].Text;
            textBox4.Text = listView1.Items[var2].SubItems[4].Text;
            textBox5.Text = listView1.Items[var2].SubItems[5].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox6.Text);

                komut.CommandText = "Delete from Personel where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                MessageBox.Show("Veriler silindi!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == ""|| textBox3.Text=="")
            {
                textBox1.BackColor = Color.Yellow;
                textBox2.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                textBox5.BackColor = Color.Yellow;
                textBox3.BackColor = Color.Yellow;
                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;
                int sayi = Convert.ToInt32(textBox3.Text);
                int kim = Convert.ToInt32(textBox6.Text);

                komut.CommandText = "update Personel set per_ad='" + textBox1.Text + "',per_soyad='" + textBox2.Text + "',maas='" + sayi + "',gorev='" + textBox4.Text + "',telefon='" + textBox5.Text + "'where kimlik=" + kim;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                MessageBox.Show("Veriler güncellendi!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
        }
    }
}
