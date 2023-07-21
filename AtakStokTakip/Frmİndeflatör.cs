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

namespace AtakStokTakip
{
    public partial class Frmİndeflatör : Form
    {
        public Frmİndeflatör()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {

            //ciltzımbası
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select*from İndeflatör", bgl.baglanti());
            da2.Fill(dt2);
            grdİndeflatör.DataSource = dt2;



        }

        private void Frmİndeflatör_Load(object sender, EventArgs e)
        {
            listele();
        }


        void temizle()
        {

            txtID.Text = "";
            txtTarih.Text = "";
            txtParçaAdı.Text = "";
            txtGiriş.Text = "";
            txtFire.Text = "";
            txtBitmişÜrün.Text = "";
            txtPaketlenmişÜrün.Text = "";
            cmbKat.Text = "";

        }



        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {

                txtID.Text = dr["ID"].ToString();
                txtTarih.Text = dr["Tarih"].ToString();
                txtParçaAdı.Text = dr["ParçaAdı"].ToString();
                txtGiriş.Text = dr["Giriş"].ToString();
                txtFire.Text = dr["Fire"].ToString();
                txtBitmişÜrün.Text = dr["BitmişÜrün"].ToString();
                txtPaketlenmişÜrün.Text = dr["PaketlenmişÜrün"].ToString();


            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("insert into İndeflatör ( Tarih, ParçaAdı,Giriş,Kategori,Fire,BitmişÜrün,PaketlenmişÜrün) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtParçaAdı.Text);
            komut.Parameters.AddWithValue("@p3", txtGiriş.Text);
            komut.Parameters.AddWithValue("@p4", cmbKat.Text);
            komut.Parameters.AddWithValue("@p5", txtFire.Text);
            komut.Parameters.AddWithValue("@p6", txtBitmişÜrün.Text);
            komut.Parameters.AddWithValue("@p7", txtPaketlenmişÜrün.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Update İndeflatör set Tarih=@p1, ParçaAdı=@p2,Giriş=@p3, Fire=@p4, BitmişÜrün=@p5,PaketlenmişÜrün=@p6, Kategori=@p7 where ID=@p8", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtParçaAdı.Text);
            komut.Parameters.AddWithValue("@p3", txtGiriş.Text);
            komut.Parameters.AddWithValue("@p4", txtFire.Text);
            komut.Parameters.AddWithValue("@p5", txtBitmişÜrün.Text);
            komut.Parameters.AddWithValue("@p6", txtPaketlenmişÜrün.Text);
            komut.Parameters.AddWithValue("@p7", cmbKat.Text);
            komut.Parameters.AddWithValue("@p8", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from İndeflatör where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
