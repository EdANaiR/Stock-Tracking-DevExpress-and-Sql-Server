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


namespace AtakStokTakip
{
    public partial class FrmOfis : Form
    {
        public FrmOfis()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {

            //ciltzımbası
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select*from Ofis", bgl.baglanti());
            da4.Fill(dt4);
            grdOfis.DataSource = dt4;

        }

        private void FrmOfis_Load(object sender, EventArgs e)
        {
            listele();
        }

        void temizle()
        {
            txtID.Text = "";
            txtTarih.Text = "";
            txtSatış.Text = "";
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {

                txtID.Text = dr["ID"].ToString();
                txtTarih.Text = dr["Tarih"].ToString();
                txtSatış.Text = dr["Satış"].ToString();              
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("insert into Ofis ( Tarih, Satış) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtSatış.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Update Ofis set Tarih=@p1, Satış=@p2 where ID=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtSatış.Text);
            komut.Parameters.AddWithValue("@p3", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Delete from Ofis where ID=@p1", bgl.baglanti());
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
