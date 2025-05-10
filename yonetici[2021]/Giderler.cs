using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;


namespace yonetici_2021_
{
    public partial class Giderler : Form
    {
        public Giderler()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + Application.StartupPath + "\\yonetici.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void verilerigoruntule()
        {
            listView2.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Faturalar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["fatura_ad"].ToString());
                ekle1.SubItems.Add(oku["fatura_miktar"].ToString());
                ekle1.SubItems.Add(oku["son_odeme"].ToString());
                
                listView2.Items.Add(ekle1);


            }

            baglanti.Close();



        }
        private void verilerigoruntule2()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Giderler");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["gider_miktar"].ToString());
                ekle1.SubItems.Add(oku["aciklama"].ToString());
               

                listView1.Items.Add(ekle1);


            }

            baglanti.Close();



        }
        private void Giderler_Load(object sender, EventArgs e)
        {
            verilerigoruntule2();
            verilerigoruntule();
            textBox5.Text = dateTimePicker1.Value.ToString();
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

            textBox1.Text = listView1.Items[var2].SubItems[1].Text;
            textBox3.Text = listView1.Items[var2].SubItems[2].Text;
            textBox6.Text = listView1.Items[var2].SubItems[0].Text;
            
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

            textBox2.Text = listView2.Items[var2].SubItems[1].Text;
            textBox4.Text = listView2.Items[var2].SubItems[2].Text;
            textBox6.Text = listView2.Items[var2].SubItems[0].Text;
            textBox5.Text = listView2.Items[var2].SubItems[3].Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox4.Text == "" || dateTimePicker1.Text == "")
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

                OleDbCommand komut = new OleDbCommand("insert into Faturalar(fatura_ad,fatura_miktar,son_odeme) values('" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + dateTimePicker1.Value.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                verilerigoruntule();
                MessageBox.Show("Veriler eklendi!");
                textBox2.Clear();
                textBox4.Clear();
                textBox6.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {

                textBox2.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                textBox6.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox6.Text);

                komut.CommandText = "Delete from Faturalar where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();

                textBox2.Clear();

                textBox4.Clear();

                textBox6.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox4.Text == "" || dateTimePicker1.Text == "")
            {

                textBox2.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int kim = Convert.ToInt32(textBox6.Text);

                komut.CommandText = "update Faturalar set fatura_ad='" + textBox2.Text + "',fatura_miktar='" + textBox4.Text + "',son_odeme='" + textBox5.Text + "'where kimlik=" + kim;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                textBox2.Clear();
                textBox4.Clear();
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = dateTimePicker1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                textBox1.BackColor = Color.Yellow;
             
                textBox3.BackColor = Color.Yellow;
                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("insert into Giderler(gider_miktar,aciklama) values('" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                verilerigoruntule2();
                MessageBox.Show("Veriler eklendi!");
                textBox1.Clear();
                textBox3.Clear();
                textBox6.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                textBox1.BackColor = Color.Yellow;

                textBox3.BackColor = Color.Yellow;
                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {



                baglanti.Open();
                komut.Connection = baglanti;

                int kim = Convert.ToInt32(textBox6.Text);

                komut.CommandText = "update Giderler set gider_miktar='" + textBox1.Text + "',aciklama='" + textBox3.Text + "'where kimlik=" + kim;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule2();
                textBox1.Clear();
                textBox3.Clear();
                textBox6.Clear();
                MessageBox.Show("Veriler güncellendi!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
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

                int sayi;
                sayi = Convert.ToInt32(textBox6.Text);

                komut.CommandText = "Delete from Giderler where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule2();
                textBox1.Clear();
                textBox3.Clear();
                textBox6.Clear();
                MessageBox.Show("Veriler silindi!");
            }
        }
    }
}
