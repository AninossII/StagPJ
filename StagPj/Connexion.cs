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
        static string Sqlstring = "Data Source=SQL5103.site4now.net;Initial Catalog=DB_A71E52_db01;User Id=DB_A71E52_db01_admin;Password=db01.1234";
        static SqlConnection con = new SqlConnection(Sqlstring);
        private DataTable _dataTable ;
        private SqlDataAdapter _dataAdapter;
        private Action A;

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

        public DataTable showDataTable(string Sqlcommand)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(Sqlcommand, con);

            _dataTable = new DataTable();
            cmd.ExecuteNonQuery();

            _dataAdapter = new SqlDataAdapter(cmd);
            _dataAdapter.Fill(_dataTable);

            con.Close();
            
            return _dataTable;

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

            return _dataTable;
        }

        ////////////// ----- Action ----- //////////////

        public string Ajouter_Action(string des, float prix)
        {
            
            con.Open();

            SqlCommand cmd = new SqlCommand("dbo.I_Action", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Time", SqlDbType.DateTime);
            cmd.Parameters.Add("@Designation", SqlDbType.Char, 256);
            cmd.Parameters.Add("@Prix", SqlDbType.Float);
            cmd.Parameters.Add("@C_id", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@Time"].Value = DateTime.Now;
            cmd.Parameters["@Designation"].Value = des;
            cmd.Parameters["@Prix"].Value = prix;
            cmd.Parameters["@C_id"].Value = Guid.Parse("F7C64F98-2495-4DAE-9387-3F2E9E9A7BB6");
             
            cmd.ExecuteNonQuery();

            con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }

        public string Modifiere_Action(string des,float prix)
        {
            A = new Action();

            con.Open();
            SqlCommand cmd = new SqlCommand("dbo.U_Action", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            cmd.Parameters.Add("@Time", SqlDbType.DateTime);
            cmd.Parameters.Add("@Designation", SqlDbType.Char, 256);
            cmd.Parameters.Add("@Prix", SqlDbType.Float);
            cmd.Parameters.Add("@C_id", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@ID"].Value = Guid.Parse(A.ID);
            cmd.Parameters["@Time"].Value = DateTime.Now;
            cmd.Parameters["@Designation"].Value = des;
            cmd.Parameters["@Prix"].Value = prix;
            cmd.Parameters["@C_id"].Value = Guid.Parse("F7C64F98-2495-4DAE-9387-3F2E9E9A7BB6");

            cmd.ExecuteNonQuery();

            con.Close();

            A.ID = null;

            return cmd.Parameters["@responseMessage"].Value.ToString();

        }

        public string Suppretion_Action()
        {
            A = new Action();

            con.Open();
            SqlCommand cmd = new SqlCommand("dbo.D_Action", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@ID"].Value = Guid.Parse(A.ID);


            cmd.ExecuteNonQuery();

            con.Close();

            A.ID = null;

            return cmd.Parameters["@responseMessage"].Value.ToString();

        }

        ////////////// ----- User ----- //////////////
    }
}