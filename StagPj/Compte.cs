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
        private static string id;
        private string nom;
        private DateTime datecreation;
        private float c_montant;
        public Connexion C;
        public Utilisateur utilisateur;
        public Compte()
        {
            utilisateur = new Utilisateur();
            C = new Connexion();
        }
        public Compte(string nom, float c_montant)
        {
            this.nom = nom;
            this.c_montant = c_montant;

        }
        public string ID
        {
            get { return id; }
            set { id = value; }
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
        public string Ajouter_Compte(string Nom, float C_Montant)
        {
            new Connexion();
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.I_Comptes", Connexion.Con);

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

            Connexion.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }
        public string modifiere_Compte(string Nom, float C_Montant)
        {
            new Connexion();
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.U_Comptes", Connexion.Con);

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

            Connexion.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }
        public string suppretion_Compte(string id )
        {
            new Connexion();
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.D_Comptes", Connexion.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@ID"].Value = Guid.Parse(id);


            cmd.ExecuteNonQuery();

            Connexion.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }
    }
}