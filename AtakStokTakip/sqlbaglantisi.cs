using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AtakStokTakip
{
    internal class sqlbaglantisi
    {

        public SqlConnection baglanti()
        {
            SqlConnection baglan=new SqlConnection(@"Data Source=LAPTOP-B20RK80B\SQLEXPRESS;Initial Catalog=stokTakip;Integrated Security=True");
            baglan.Open();
            return baglan;
        }



    }
}
