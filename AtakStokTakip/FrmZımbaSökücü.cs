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
    public partial class FrmZımbaSökücü : Form
    {
        public FrmZımbaSökücü()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {

            //ciltzımbası
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Select*from ZımbaSökücü", bgl.baglanti());
            da3.Fill(dt3);
            grdZımbaSökücü.DataSource = dt3;

        }

        private void FrmZımbaSökücü_Load(object sender, EventArgs e)
        {
            listele();
        }

        void temizle()
        {

            txtID.Text = "";
            txtTarih.Text = "";
            txtAdet.Text = "";
            txtSatış.Text = "";

        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {

                txtID.Text = dr["ID"].ToString();
                txtTarih.Text = dr["Tarih"].ToString();
                txtAdet.Text = dr["Adet"].ToString();
                txtSatış.Text = dr["Satış"].ToString();
             
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("insert into ZımbaSökücü ( Tarih, Adet, Satış) values (@p1,@p2,@p3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtAdet.Text);
            komut.Parameters.AddWithValue("@p3", txtSatış.Text);         
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Update ZımbaSökücü set Tarih=@p1, Adet=@p2, Satış=@p3 where ID=@p4", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtAdet.Text);
            komut.Parameters.AddWithValue("@p3", txtSatış.Text);
            komut.Parameters.AddWithValue("@p4", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Zımba Sökücü where ID=@p1", bgl.baglanti());
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
