using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusOkul
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciNotlar gecis = new FrmOgrenciNotlar();
            gecis.numara = textBox1.Text;
            gecis.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmenForm gecis=new FrmOgretmenForm();
            gecis.Show();
            this.Hide();
        }
    }
}
