using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace BonusOkul
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-GLOA13K;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DERSAD,SINAV1,SINAV2,PROJE,ORTALAMA,DURUM from tbl_Notlar INNER JOIN tbl_Dersler on tbl_Notlar.DERSID=tbl_Dersler.DERSID where OGRID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select ograd,ogrsoyad from tbl_ogrenciler where OGRID=@a1", baglanti);
            komut2.Parameters.AddWithValue("@a1", numara);
            SqlDataReader dr=komut2.ExecuteReader();
            while(dr.Read())
            {
                this.Text = dr[0]+" " + dr[1];
            }
            baglanti.Close();
        }
    }
}
