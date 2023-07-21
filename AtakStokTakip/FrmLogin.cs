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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnLogin_Click(object sender, EventArgs e)
        {      
            if(txtkullanıcıAdı.Text=="" || txtŞifre.Text == "")
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurun");
            }
            else
            {

                SqlCommand komut = new SqlCommand("Select * from Admin where Kullanici=@p1 AND Sifre=@p2",bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtkullanıcıAdı.Text);
                komut.Parameters.AddWithValue("@p2",txtŞifre.Text);
                SqlDataReader dr=komut.ExecuteReader();
                if(dr.Read())
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
    }
}
