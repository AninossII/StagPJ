using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Drawing;


namespace StagPj
{
    public class Connexion
    {
        private static string Sqlstring = "Data Source=SQL5103.site4now.net;Initial Catalog=DB_A71E52_db01;User Id=DB_A71E52_db01_admin;Password=db01.1234";
        private static string id;

        static SqlConnection con = new SqlConnection(Sqlstring);
        private SqlCommand _cmd;
        private SqlDataAdapter _dataAdapter;
        private DataTable _dataTable ;

        private Action A;
        private Compte C;
        private Utilisateur U;

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
            SqlCommand _cmd = new SqlCommand(Sqlcommand, con);

            _dataTable = new DataTable();
            _cmd.ExecuteNonQuery();

            _dataAdapter = new SqlDataAdapter(_cmd);
            _dataAdapter.Fill(_dataTable);

            con.Close();
            
            return _dataTable;
        }
        
        public DataTable showParamDataTable(string Sqlcommand)
        {
            con.Open();
            SqlCommand _cmd = new SqlCommand(Sqlcommand, con);
            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);

            _cmd.Parameters["@ID"].Value =Guid.Parse(UserId());

            _dataTable = new DataTable();
            _cmd.ExecuteNonQuery();

            _dataAdapter = new SqlDataAdapter(_cmd);
            _dataAdapter.Fill(_dataTable);

            con.Close();

            return _dataTable;
        }

        public DataTable ExecDataTable(string _cmd)
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

        ////////////// ----- User ID ----- //////////////

        public string UserId()
        {
            U = new Utilisateur();

            con.Open();

            _cmd = new SqlCommand("select dbo.Get_ID_Utilisateur('" + U.Email + "')", con);
            
            var idExecuteScalar = _cmd.ExecuteScalar();

            con.Close();

            return idExecuteScalar.ToString();
        }

        ////////////// ----- Compte ID ----- //////////////

        public string ComptId(string id)
        {
            U = new Utilisateur();

            con.Open();

            _cmd = new SqlCommand("select dbo.Get_name_from_ID('" + id + "')", con);

            var idExecuteScalar = _cmd.ExecuteScalar();

            con.Close();

            return idExecuteScalar.ToString();
        }

        /*public string ComptIdbyName(string cbName)
        {
            U = new Utilisateur();
            C = new Compte();
            con.Open();

            _cmd = new SqlCommand("SELECT dbo.Get_ID_from_nom_U_ID('"++"','"+U.ID+"')", con);

            var idExecuteScalar = _cmd.ExecuteScalar();

            con.Close();

            return idExecuteScalar.ToString();
        }*/

        ////////////// ----- Action ----- //////////////

        public string Ajouter_Action(string des, float prix)
        {
            C = new Compte();
            con.Open();

            _cmd = new SqlCommand("dbo.I_Action", con);
            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.Add("@Time", SqlDbType.DateTime);
            _cmd.Parameters.Add("@Designation", SqlDbType.Char, 256);
            _cmd.Parameters.Add("@Prix", SqlDbType.Float);
            _cmd.Parameters.Add("@C_id", SqlDbType.UniqueIdentifier);

            _cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            _cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            _cmd.Parameters["@Time"].Value = DateTime.Now;
            _cmd.Parameters["@Designation"].Value = des;
            _cmd.Parameters["@Prix"].Value = prix;
            _cmd.Parameters["@C_id"].Value = Guid.Parse(C.ID);
             
            _cmd.ExecuteNonQuery();

            con.Close();

            return _cmd.Parameters["@responseMessage"].Value.ToString();
        }

        public string Modifiere_Action(string des,float prix)
        {
            C = new Compte();
            A = new Action();

            con.Open();
            _cmd = new SqlCommand("dbo.U_Action", con);

            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            _cmd.Parameters.Add("@Time", SqlDbType.DateTime);
            _cmd.Parameters.Add("@Designation", SqlDbType.Char, 256);
            _cmd.Parameters.Add("@Prix", SqlDbType.Float);
            _cmd.Parameters.Add("@C_id", SqlDbType.UniqueIdentifier);

            _cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            _cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            _cmd.Parameters["@ID"].Value = Guid.Parse(A.ID);
            _cmd.Parameters["@Time"].Value = A.Time;
            _cmd.Parameters["@Designation"].Value = des;
            _cmd.Parameters["@Prix"].Value = prix;
            _cmd.Parameters["@C_id"].Value = Guid.Parse(C.ID);

            _cmd.ExecuteNonQuery();

            con.Close();

            A.ID = null;

            return _cmd.Parameters["@responseMessage"].Value.ToString();
        }

        public string Suppretion_Action()
        {
            C = new Compte();
            A = new Action();

            con.Open();
            _cmd = new SqlCommand("dbo.D_Action", con);

            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);

            _cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            _cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            _cmd.Parameters["@ID"].Value = Guid.Parse(A.ID);
            
            _cmd.ExecuteNonQuery();

            con.Close();

            A.ID = null;

            return _cmd.Parameters["@responseMessage"].Value.ToString();
        }

        ////////////// ----- User ----- //////////////

        public string LogIn(string email, string password)
        {
            U = new Utilisateur();

            con.Open();

            _cmd = new SqlCommand("dbo.User_Login", con);

            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.Add("@Email", SqlDbType.Char, 150);
            _cmd.Parameters.Add("@password", SqlDbType.Char, 20);
            _cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            _cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            _cmd.Parameters["@Email"].Value = email;
            _cmd.Parameters["@password"].Value = password;

            _cmd.ExecuteNonQuery();

            con.Close();

            return _cmd.Parameters["@responseMessage"].Value.ToString();
        }
    }
}