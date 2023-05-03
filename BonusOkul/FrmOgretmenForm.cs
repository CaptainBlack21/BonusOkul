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
    public partial class FrmOgretmenForm : Form
    {
        public FrmOgretmenForm()
        {
            InitializeComponent();
        }


        private void btnDersler_Click(object sender, EventArgs e)
        {

            FrmDersler gecis = new FrmDersler();
            gecis.Show();
            
        }

        private void btnKulup_Click(object sender, EventArgs e)
        {
            FrmKulup gecis = new FrmKulup();
            gecis.Show();
        }

        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenci gecis=new FrmOgrenci();
            gecis.Show();
        }

        private void btnNotlar_Click(object sender, EventArgs e)
        {
            FrmNotlar gecis=new FrmNotlar();
            gecis.Show();
        }
    }
}
