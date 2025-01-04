using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class dbConnection
    {
        //public SqlConnection con= new SqlConnection("Data Source=NOOR\\SQLEXPRESS;Initial Catalog=customerServiceDb;Integrated Security=True");
        //  public SqlConnection con = new SqlConnection("Data Source=MEMZ\\SQLSERVER;Initial Catalog=customerServiceDb;Integrated Security=True");
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnnection"].ConnectionString);

        public SqlConnection getcon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            return con;
        }
        public int ExeNonQuery(SqlCommand cmd)
        {
            cmd.Connection = getcon();
            int rowsaffected = -1;
            rowsaffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsaffected;
        }
        public object ExeScalar(SqlCommand cmd)
        {
            cmd.Connection = getcon();
            object obj = -1;
            obj = cmd.ExecuteScalar();
            con.Close();
            return obj;
        }
        public DataTable ExeReader(SqlCommand cmd)
        {
            cmd.Connection = getcon();
            SqlDataReader sdr;
            DataTable dt = new DataTable();

            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;
        }
    }
}
