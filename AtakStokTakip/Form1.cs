using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtakStokTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        FrmCiltZimbasi frm2;

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new FrmCiltZimbasi();
                frm2.MdiParent = this; 
                frm2.Show();
            }
        }
        FrmOfis frm6;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null || frm6.IsDisposed)
            {
                frm6 = new FrmOfis();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }
        Frmİndeflatör frm3;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new Frmİndeflatör();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        FrmZımbaSökücü frm5;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new FrmZımbaSökücü();
                frm5.MdiParent = this;
                frm5.Show();
            }
        }
    }
}
