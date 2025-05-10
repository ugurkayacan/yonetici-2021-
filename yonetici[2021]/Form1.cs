using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yonetici_2021_
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            YGiris y = new YGiris();
            y.Show();


        }

        private void label3_Click(object sender, EventArgs e)
        {
            SGiriş s = new SGiriş();
            s.Show();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
