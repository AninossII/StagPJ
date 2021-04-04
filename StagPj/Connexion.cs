using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace StagPj
{
    public class Connexion
    {
        static SqlConnection con; 
        public DataTable dataTable = new DataTable();
        private string Sqlstring;

        public static SqlConnection Con
        {
            get
            {                
                return con;
            }
        }

        public Connexion()
        {
            Sqlstring = "Data Source=SQL5103.site4now.net;Initial Catalog=DB_A71E52_db01;User Id=DB_A71E52_db01_admin;Password=db01.1234";
            con = new SqlConnection(Sqlstring);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;            
        }

        public DataTable retrievdata(string command)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(command, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                da.Dispose();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('something wrong with the connection '" + ex.Message + ")</script>");
            }
            finally
            {
                con.Close();
            }
            return dataTable;
        }
        public DataTable ExecDataTable(string cmd)
        {
            try
            {
                con.Open();
                SqlCommand sqlcmd = new SqlCommand();
                int row = sqlcmd.ExecuteNonQuery();
                if (row > 0)
                    HttpContext.Current.Response.Write("<script>alert('your cammand done '/script>");
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('something '/script>");
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return dataTable;
        }
    }
}