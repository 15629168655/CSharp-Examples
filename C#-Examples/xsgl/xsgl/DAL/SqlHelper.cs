using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using xsgl.Model;

namespace xsgl.DAL
{
    public class SqlHelper
    {
        //public static string connectString = "server=localhost\\SQLEXPRESS;uid=sa;pwd=sa;database=xsgl";
        public static string connectString = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
        public static SqlConnection Connect() {
            SqlConnection con = new SqlConnection(connectString);
            return con;
        }
        public static int ExecuteNonQuery(string sql, params SqlParameter[] cmdParms) {
            SqlConnection con= Connect();
            SqlCommand cmd = new SqlCommand(sql, con);
            foreach (SqlParameter parm in cmdParms) {
                cmd.Parameters.Add(parm);
            }
            try
            {
                con.Open();
                int num = cmd.ExecuteNonQuery();
                return num;
            }
            catch
            {
                return 0;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public static SqlDataReader ExecuteReader(string sql) {
            SqlConnection con = Connect();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        //执行SELECT语句，返回数据表
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] cmdParms) {
            SqlConnection con = Connect();
            SqlCommand cmd = new SqlCommand(sql, con);
            foreach (SqlParameter parm in cmdParms) {
                cmd.Parameters.Add(parm);
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

       
    }
}
