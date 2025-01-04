using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace css.Data.AdoNet
{
    public static class SqlExecuter
    {
        
        public static DataTable GetBasicData(string connectionString, int custid )
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter adp = null;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetBasicdata";
                cmd.Parameters.Clear();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CustomerId", custid);                            
                cmd.Parameters.AddRange(param);            
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                string x = ex.Message.ToString();
                return dt;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
                if (cmd != null)
                    cmd.Dispose();
                if (adp != null)
                    adp.Dispose();
            }
        }
        
        public static DataTable GetMainData(string connectionString, int companyID)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter adp = null;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetMainGriddata";
                cmd.Parameters.Clear();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Company_id", companyID);
                cmd.Parameters.AddRange(param);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                string x = ex.Message.ToString();
                return dt;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
                if (cmd != null)
                    cmd.Dispose();
                if (adp != null)
                    adp.Dispose();
            }
        }

        public static DataTable GetArchiveData(string connectionString, int companyID)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter adp = null;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetArchiveGriddata";
                cmd.Parameters.Clear();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Company_id", companyID);
                cmd.Parameters.AddRange(param);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                string x = ex.Message.ToString();
                return dt;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
                if (cmd != null)
                    cmd.Dispose();
                if (adp != null)
                    adp.Dispose();
            }
        }

        public static DataTable GetServiceInfoData(string connectionString, int requestId)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter adp = null;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {         
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetServiceInfodata";
                cmd.Parameters.Clear();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RequestID", requestId);
                cmd.Parameters.AddRange(param);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                return dt;

            }

            catch (Exception ex)
            {
                string x = ex.Message.ToString();
                return dt;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
                if (cmd != null)
                    cmd.Dispose();
                if (adp != null)
                    adp.Dispose();
            }
        }

        public static DataTable GetServiceFormData(string connectionString, int requestId)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter adp = null;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetServiceForm";
                cmd.Parameters.Clear();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RequestId", requestId);
                cmd.Parameters.AddRange(param);
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                return dt;
            }

            catch (Exception ex)
            {
                string x = ex.Message.ToString();
                return dt;
            }
            finally
            {
                if (con != null)
                    con.Dispose();
                if (cmd != null)
                    cmd.Dispose();
                if (adp != null)
                    adp.Dispose();
            }
        }
    }
}
