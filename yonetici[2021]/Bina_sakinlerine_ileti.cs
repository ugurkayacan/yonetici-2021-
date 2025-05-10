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
    public partial class Bina_sakinlerine_ileti : Form
    {
        public Bina_sakinlerine_ileti()
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
            komut.CommandText = ("Select * From Yonetici_ileti");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["yileti"].ToString());
                ekle1.SubItems.Add(oku["tarih"].ToString());
                listView1.Items.Add(ekle1);
            }

            baglanti.Close();
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

                OleDbCommand komut = new OleDbCommand("insert into Yonetici_ileti(yileti,tarih) values('" + richTextBox1.Text.ToString() + "','" + dateTimePicker1.Value.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                MessageBox.Show("İletiniz başarıyla kaydedildi!!!");
                richTextBox1.Clear();

            }
          
            
        }

        private void Bina_sakinlerine_ileti_Load(object sender, EventArgs e)
        {
            verilerigoruntule();
            
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

            richTextBox2.Text= listView1.Items[var2].SubItems[1].Text;
            textBox1.Text = listView1.Items[var2].SubItems[0].Text;
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                textBox1.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox1.Text);

                komut.CommandText = "Delete from Yonetici_ileti where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                textBox1.Clear();
                richTextBox2.Clear();
                MessageBox.Show("İleti bilgileri başarıyla silindi!!!");
            }
            

        }
    }
}
