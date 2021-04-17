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
        private string Sqlstring ;
        private SqlCommand _cmd;
        private SqlDataAdapter _dataAdapter;
        private DataTable _dataTable;

        private static SqlConnection _con;
        private Utilisateur u;

        public SqlConnection Con
        {
            get
            {                
                return _con;
            }
        }

        public Connexion()
        {
            Sqlstring = "Data Source=SQL5103.site4now.net;Initial Catalog=DB_A71E52_db01;User Id=DB_A71E52_db01_admin;Password=db01.1234";
            _con = new SqlConnection(Sqlstring);
        }

        ////////////// ----- Show table ----- //////////////

        public DataTable showDataTable(string Sqlcommand)
        {
            _con.Open();

            SqlCommand _cmd = new SqlCommand(Sqlcommand, _con);

            _dataTable = new DataTable();
            _cmd.ExecuteNonQuery();

            _dataAdapter = new SqlDataAdapter(_cmd);
            _dataAdapter.Fill(_dataTable);

            _con.Close();
            
            return _dataTable;
        }

        ////////////// ----- Show table Using Proc ID ----- //////////////

        public DataTable showParamDataTable(string Sqlcommand,string idName)
        {
            u = new Utilisateur();

            _con.Open();

            SqlCommand _cmd = new SqlCommand(Sqlcommand, _con);
            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.Add(idName, SqlDbType.UniqueIdentifier);

            _cmd.Parameters[idName].Value =Guid.Parse(u.ID);

            _dataTable = new DataTable();
            _cmd.ExecuteNonQuery();

            _dataAdapter = new SqlDataAdapter(_cmd);
            _dataAdapter.Fill(_dataTable);

            _con.Close();

            return _dataTable;
        }
        

            // -- Add Money --
            public string StaticAddMoney()
            {
                u = new Utilisateur();
                
                _con.Open();

                _cmd = new SqlCommand("exec dbo.statistiques_Added_Money '"+u.ID+"'", _con);
                
                string text = _cmd.ExecuteScalar().ToString();

                _con.Close();

                return text;
            }

            // -- Withdraw Money --
            public string StaticWithdrawMoney()
            {
                u = new Utilisateur();

                _con.Open();

                _cmd = new SqlCommand("exec dbo.statistiques_Withdraw_Money '" + u.ID + "'", _con);

                string text = _cmd.ExecuteScalar().ToString();

                _con.Close();

                return text;
            }

    }
}