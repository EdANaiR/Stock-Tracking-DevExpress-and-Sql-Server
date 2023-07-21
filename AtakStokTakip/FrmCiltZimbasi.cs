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
    public partial class FrmCiltZimbasi : Form
    {
        public FrmCiltZimbasi()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {

            //ciltzımbası
            DataTable dt1=new DataTable();
            SqlDataAdapter da1= new SqlDataAdapter("Select*from CiltZımbası",bgl.baglanti());
            da1.Fill(dt1);
            grdCiltZımbası.DataSource = dt1;
            
            //TemizOda1
            DataTable dt2=new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select*from TemizOda1", bgl.baglanti());
            da2.Fill(dt2);
            grdTemizOda.DataSource = dt2;
        }  
        private void FrmCiltZimbasi_Load(object sender, EventArgs e)
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
        }




        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

            


            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtTarih.Text= dr["Tarih"].ToString();
                txtBitmişÜrün.Text= dr["BitmişÜrün"].ToString();
                txtFire.Text = dr["Fire"].ToString();
                txtPaketlenmişÜrün.Text = dr["PaketlenmişÜrün"].ToString();



            }

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
                
                

            }


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string ciltZimbasiFire = txtFire.Text;
            string temizOdaFire = txtFire.Text;
            string bitmişÜrün = txtBitmişÜrün.Text;
            string paketlenmişÜrün = txtPaketlenmişÜrün.Text;
            string tarih = txtTarih.Text;

            SqlCommand komut = new SqlCommand("insert into CiltZımbası ( Tarih, ParçaAdı,Giriş,Fire) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtParçaAdı.Text);
            komut.Parameters.AddWithValue("@p3", txtGiriş.Text);
            komut.Parameters.AddWithValue("@p4", ciltZimbasiFire);
            
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();



            SqlCommand insertKomut = new SqlCommand("insert into TemizOda1 (Tarih, BitmişÜrün, Fire, PaketlenmişÜrün) values (@p1, @p2, @p3, @p4)", bgl.baglanti());
            insertKomut.Parameters.AddWithValue("@p1", tarih);
            insertKomut.Parameters.AddWithValue("@p2", bitmişÜrün); 
            insertKomut.Parameters.AddWithValue("@p3", temizOdaFire);
            insertKomut.Parameters.AddWithValue("@p4", paketlenmişÜrün); 

            insertKomut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
        }

        

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {

            string ciltZimbasiFire = txtFire.Text;
            string cTTarih = txtTarih.Text;
            string parcaAdi = txtParçaAdı.Text;
            string temizOdaFire = txtFire.Text;
            string bitmişÜrün = txtBitmişÜrün.Text;
            string paketlenmişÜrün = txtPaketlenmişÜrün.Text;
            string tarih = txtTarih.Text;
            string ciltZimbasiID = txtID.Text;
            string temizOdaID = txtID.Text;



            SqlCommand komut = new SqlCommand("Update CiltZımbası set Tarih=@p1, ParçaAdı=@p2, Giriş = Giriş - @p3, Fire=@p3 where ID=@p4", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cTTarih);
            komut.Parameters.AddWithValue("@p2", parcaAdi);
            komut.Parameters.AddWithValue("@p3", ciltZimbasiFire);            
            komut.Parameters.AddWithValue("@p4", ciltZimbasiID);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Güncellendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();



            SqlCommand updateKomut = new SqlCommand("Update TemizOda1 set Tarih=@p1, BitmişÜrün=@p2, Fire=@p3, PaketlenmişÜrün=@p4 where ID=@p5 ", bgl.baglanti());
            updateKomut.Parameters.AddWithValue("@p1", tarih);
            updateKomut.Parameters.AddWithValue("@p2", bitmişÜrün);
            updateKomut.Parameters.AddWithValue("@p3", temizOdaFire);
            updateKomut.Parameters.AddWithValue("@p4", paketlenmişÜrün);
            updateKomut.Parameters.AddWithValue("@p5", temizOdaID);

            updateKomut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            string ciltZimbasiID = txtID.Text;
            string temizOdaID = txtID.Text;



            SqlCommand komut = new SqlCommand("Delete from CiltZımbası where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", ciltZimbasiID);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();


            SqlCommand deleteKomut = new SqlCommand("Delete from TemizOda1 where ID=@p1", bgl.baglanti());
            deleteKomut.Parameters.AddWithValue("@p1", temizOdaID);
            deleteKomut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();



        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
