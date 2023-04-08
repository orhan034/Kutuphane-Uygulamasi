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

using static System.Net.Mime.MediaTypeNames;

namespace Kutuphane
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection ("Data Source=ACERNITRO5;Initial Catalog=KutuphaneVeriTanbani;Integrated Security=True");
       
        void temizle()
        {
            txtid.Text = "";
            txtisim.Text = "";
            txtyazar.Text = "";
            txtyayinevi.Text = "";
            txttur.Text = "";
            txtbaski.Text = "";
            mskfiyat.Text = "";
            txtisim.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kutuphaneVeriTanbaniDataSet6.Tbl_kutuphane' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_kutuphaneTableAdapter6.Fill(this.kutuphaneVeriTanbaniDataSet6.Tbl_kutuphane);

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kutuphaneVeriTanbaniDataSet6.Tbl_kutuphane' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_kutuphaneTableAdapter6.Fill(this.kutuphaneVeriTanbaniDataSet6.Tbl_kutuphane);

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_kutuphane (kitapIsmi,kitapYazar, kitapYayinevi,kitapTur,kitapBaski,kitapFiyat) values (@k1,@k2,@k3,@k4,@k5,@k6)", baglanti);
            komut.Parameters.AddWithValue("@k1", txtisim.Text);
            komut.Parameters.AddWithValue("@k2", txtyazar.Text);
            komut.Parameters.AddWithValue("@k3", txtyayinevi.Text);
            komut.Parameters.AddWithValue("@k4", txttur.Text);
            komut.Parameters.AddWithValue("@k5", txtbaski.Text);
            komut.Parameters.AddWithValue("@k6", mskfiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Başarılı");
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {
           
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_kutuphane Where kitapid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtisim.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtyazar.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtyayinevi.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txttur.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtbaski.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            mskfiyat.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_kutuphane Set kitapIsmi=@k1,kitapYazar=@k2,kitapYayinevi=@k3,kitapTur=@k4,kitapBaski=@k5,kitapFiyat=@k6 where kitapid=@k7",baglanti);
            komutguncelle.Parameters.AddWithValue("@k1",txtisim.Text);
            komutguncelle.Parameters.AddWithValue("@k2", txtyazar.Text);
            komutguncelle.Parameters.AddWithValue("@k3", txtyayinevi.Text);
            komutguncelle.Parameters.AddWithValue("@k4", txttur.Text);
            komutguncelle.Parameters.AddWithValue("@k5", txtbaski.Text);
            komutguncelle.Parameters.AddWithValue("@k6", mskfiyat.Text);
            komutguncelle.Parameters.AddWithValue("@k7", txtid.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Bilgisi Güncellendi");
        }
        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void btnkitapara_Click(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            tablo.Clear();
            baglanti.Open();
            SqlDataAdapter komutara = new SqlDataAdapter("Select * From Tbl_kutuphane where kitapIsmi like '%" +txtisim.Text+ "%' ", baglanti);
            komutara.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }
    }
}
