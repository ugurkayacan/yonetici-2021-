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
    public partial class Bina_sakinleri : Form
    {
        public Bina_sakinleri()
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
            komut.CommandText = ("Select * From Sakinler");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle1 = new ListViewItem();
                ekle1.Text = oku["kimlik"].ToString();
                ekle1.SubItems.Add(oku["ad"].ToString());
                ekle1.SubItems.Add(oku["soyad"].ToString());
                ekle1.SubItems.Add(oku["Bina_ad"].ToString());
                ekle1.SubItems.Add(oku["daire_no"].ToString());
                ekle1.SubItems.Add(oku["kiraci_evsahibi"].ToString());
                listView1.Items.Add(ekle1);


            }
          
            baglanti.Close();



        }
        private void Binalarigoruntule()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select * From Binalar");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["Bina_ad"]);

            }
            baglanti.Close();



        }
        private void Bina_sakinleri_Load(object sender, EventArgs e)
        {
            Binalarigoruntule();
            verilerigoruntule();
            
            comboBox2.Items.Add("kiracı");
            comboBox2.Items.Add("ev sahibi");
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
            textBox2.Text = listView1.Items[var2].SubItems[2].Text;
            comboBox1.Text = listView1.Items[var2].SubItems[3].Text;
            textBox4.Text = listView1.Items[var2].SubItems[4].Text;
            comboBox2.Text = listView1.Items[var2].SubItems[5].Text;
            textBox6.Text = listView1.Items[var2].SubItems[0].Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {

                textBox2.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                comboBox1.BackColor = Color.Yellow;
                comboBox2.BackColor = Color.Yellow;
                textBox6.BackColor = Color.Yellow;

                MessageBox.Show("Sarı renkli alanlar boş geçilmez!");

            }
            else
            {



                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("insert into Sakinler(ad,soyad,Bina_ad,daire_no,kiraci_evsahibi) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox2.SelectedItem.ToString() + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                verilerigoruntule();
                textBox1.Clear();
                textBox2.Clear();
                textBox6.Clear();
                textBox4.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
            }

           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {

                textBox6.BackColor = Color.Yellow;



                MessageBox.Show("Lütfen silmek istediğiniz veriyi seçin!");

            }
            else
            {


                baglanti.Open();
                komut.Connection = baglanti;

                int sayi;
                sayi = Convert.ToInt32(textBox6.Text);

                komut.CommandText = "Delete from Sakinler where kimlik= " + sayi;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                textBox1.Clear();
                textBox2.Clear();
                
                textBox4.Clear();
               
                textBox6.Clear();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {

                textBox2.BackColor = Color.Yellow;
                textBox4.BackColor = Color.Yellow;
                comboBox1.BackColor = Color.Yellow;
                comboBox2.BackColor = Color.Yellow;

                MessageBox.Show("Litfen güncellemek istediğiniz veriyi seçin");

            }
            else
            {
                baglanti.Open();
                komut.Connection = baglanti;

                int kim = Convert.ToInt32(textBox6.Text);

                komut.CommandText = "update Sakinler set ad='" + textBox1.Text + "',soyad='" + textBox2.Text + "',Bina_ad='" + comboBox1.SelectedItem.ToString() + "',daire_no='" + textBox4.Text + "',kiraci_evsahibi='" + comboBox2.SelectedItem.ToString() + "'where kimlik=" + kim;
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoruntule();
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
