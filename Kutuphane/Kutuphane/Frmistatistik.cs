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
namespace Kutuphane
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ACERNITRO5;Initial Catalog=KutuphaneVeriTanbani;Integrated Security=True");
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            // toplam kitap sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_kutuphane", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblKitapsayisi.Text = dr1[0].ToString();
            }
            baglanti.Close();
            // farklı yayınevi sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(distinct(kitapYayinevi)) From Tbl_kutuphane",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblbaskisayisi.Text = dr2[0].ToString();
            }
            baglanti.Close();

            // Toplam Kitap Fiyatı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Sum(kitapFiyat) From Tbl_kutuphane", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lbltoplamfiyat.Text = dr3[0].ToString();
            }
            baglanti.Close();

            // Ortalama Fiyat
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select Avg(kitapFiyat) From Tbl_kutuphane", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblortalamafiyat.Text = dr4[0].ToString();
            }
            baglanti.Close();
        }
    }
}
