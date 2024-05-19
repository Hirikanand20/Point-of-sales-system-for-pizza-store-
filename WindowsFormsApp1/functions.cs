using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;
        public functions() {

            ConStr= @"Data Source=HIRIK\SQL11;Initial Catalog=pizzaorderdb;Integrated Security=True";
            con =new SqlConnection(ConStr);
            cmd =new SqlCommand();
            cmd.Connection = con;
        }

        public DataTable GetData(string Query) {
        
            dt = new DataTable();
            sda = new SqlDataAdapter(Query,ConStr);
            sda.Fill(dt);
            return dt;

        }
        public int setData(string Query) {
            int Cnt = 0;
            if (con.State == ConnectionState.Closed) {

                con.Open();
            }
            cmd.CommandText = Query;
            Cnt = cmd.ExecuteNonQuery();
            con.Close();
            return Cnt;
        }


    }
}
