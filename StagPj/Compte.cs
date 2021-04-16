using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace StagPj
{
    public class Compte
    {
        private static string _id;
        private string nom;
        private DateTime datecreation;
        private float c_montant;
        private SqlCommand cmd;

        public Connexion con;
        private Utilisateur u;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public DateTime Datecreation
        {
            get { return datecreation; }
            set { datecreation = value; }
        }
        public float C_montant
        {
            get { return c_montant; }
            set { c_montant = value; }
        }

        public Compte()
        {
            con = new Connexion();
        }

        public Compte(string nom, float c_montant)
        {
            this.nom = nom;
            this.c_montant = c_montant;
        }

        ////////////// ----- Compte ID ----- //////////////

        public string ComptId(string id)
        {
            u = new Utilisateur();

            con.Con.Open();

            cmd = new SqlCommand("select dbo.Get_name_from_ID('" + id + "')", con.Con);

            var idExecuteScalar = cmd.ExecuteScalar();

            con.Con.Close();

            return idExecuteScalar.ToString();
        }

        /*public string ComptIdbyName(string cbName)
        {
            U = new Utilisateur();
            C = new Compte();
            _con.Open();

            _cmd = new SqlCommand("SELECT dbo.Get_ID_from_nom_U_ID('"++"','"+U.ID+"')", _con);

            var idExecuteScalar = _cmd.ExecuteScalar();

            _con.Close();

            return idExecuteScalar.ToString();
        }*/

        ////////////// ----- Ajouter ----- //////////////

        public string Ajouter(string Nom, float C_Montant)
        {
            con.Con.Open();

            SqlCommand cmd = new SqlCommand("dbo.I_Comptes", con.Con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nom", SqlDbType.Char, 20);
            cmd.Parameters.Add("@C_Montant", SqlDbType.Float);
            cmd.Parameters.Add("@U_id", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;


            cmd.Parameters["@Nom"].Value = Nom;
            cmd.Parameters["@C_Montant"].Value = Convert.ToDouble(C_Montant);
            cmd.Parameters["@U_id"].Value = Guid.Parse("7F1CB55C-0FDA-4AD7-BA40-9E7E2276B06C");


            cmd.ExecuteNonQuery();

            con.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }

        ////////////// ----- Modifiere ----- //////////////

        public string Modifier(string Nom, float C_Montant)
        {
            con.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.U_Comptes", con.Con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nom", SqlDbType.Char, 20);
            cmd.Parameters.Add("@C_Montant", SqlDbType.Float);
            cmd.Parameters.Add("@U_id", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;


            cmd.Parameters["@Nom"].Value = Nom;
            cmd.Parameters["@C_Montant"].Value = Convert.ToDouble(C_Montant);
            cmd.Parameters["@U_id"].Value = Guid.Parse("7F1CB55C-0FDA-4AD7-BA40-9E7E2276B06C");


            cmd.ExecuteNonQuery();

            con.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }

        ////////////// ----- Suppretion ----- //////////////

        public string Suppretion(string id )
        {
            con.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.D_Comptes", con.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@ID"].Value = Guid.Parse(id);


            cmd.ExecuteNonQuery();

            con.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }
    }
}