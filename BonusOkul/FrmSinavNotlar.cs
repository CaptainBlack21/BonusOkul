using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusOkul
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-GLOA13K;Initial Catalog=BonusOkul;Integrated Security=True");
        DataSet1TableAdapters.tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.tbl_NotlarTableAdapter();

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            CmbDersAd.Text = "";
            txtSinav1.Text = "";
            txtSinav2.Text = "";
            txtProje.Text = "";
            txtOrtalama.Text = "";
            txtDurum.Text = "";
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDersAd.DisplayMember = "DERSAD";
            CmbDersAd.ValueMember = "DERSID";
            CmbDersAd.DataSource = dt;
            baglanti.Close();
        }

        private void BtnOgrenciAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.NotListesi(int.Parse(txtid.Text));
        }
        string notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            CmbDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();


        }
        int sinav1, sinav2, proje;
        double ortalama;
        string durum;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            

            sinav1=Convert.ToInt16(txtSinav1.Text);
            sinav2=Convert.ToInt16(txtSinav2.Text);
            proje=Convert.ToInt16(txtProje.Text);
            ortalama = (sinav1 + sinav2 + proje) / 3.00;
            txtOrtalama.Text = ortalama.ToString("N");

            if (ortalama >= 50)
            {
                durum = "True";
                txtDurum.Text=durum;
            }
            else
            {
                durum = "False";
                txtDurum.Text=durum;
            }
                
          
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(CmbDersAd.SelectedValue.ToString()),int.Parse(txtid.Text),byte.Parse(txtSinav1.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text),bool.Parse(txtDurum.Text),byte.Parse(notid));
        }
    }
}