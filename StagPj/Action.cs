using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace StagPj
{
    public class Action
    {

        private static string modifId;
        private DateTime time;
        private float montant;
        private string designation;
        public Compte compte;
        public Utilisateur utilisateur;

        public float Montant
        {
            get { return montant; }
            set { montant = value; }
        }

        public string Des
        {
            get { return designation; }
            set { designation = value; }
        }

        public string ModifID
        {
            get { return modifId; }
            set { modifId = value; }
        }

        public Action()
        {
            compte = new Compte();
            utilisateur = new Utilisateur();

        }

        public Action(DateTime time, float montant, string designation)
        {
            this.time = time;
            this.montant = montant;
            this.designation = designation;
        }

        public string Ajouter_Action()
        {
            new Connexion();
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.I_Action", Connexion.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Time", SqlDbType.DateTime);
            cmd.Parameters.Add("@Designation", SqlDbType.Char, 256);
            cmd.Parameters.Add("@Prix", SqlDbType.Float);
            cmd.Parameters.Add("@C_id", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@Time"].Value = DateTime.Now;
            cmd.Parameters["@Designation"].Value = designation;
            cmd.Parameters["@Prix"].Value = montant;
            cmd.Parameters["@C_id"].Value = Guid.Parse("F7C64F98-2495-4DAE-9387-3F2E9E9A7BB6");


            cmd.ExecuteNonQuery();

            Connexion.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();

        }

        public string Modifiere_Action()
        {
            new Connexion();
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.U_Action", Connexion.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            cmd.Parameters.Add("@Time", SqlDbType.DateTime);
            cmd.Parameters.Add("@Designation", SqlDbType.Char, 256);
            cmd.Parameters.Add("@Prix", SqlDbType.Float);
            cmd.Parameters.Add("@C_id", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@ID"].Value = Guid.Parse(modifId.ToUpper());
            cmd.Parameters["@Time"].Value = DateTime.Now;
            cmd.Parameters["@Designation"].Value = designation;
            cmd.Parameters["@Prix"].Value = montant;
            cmd.Parameters["@C_id"].Value = Guid.Parse("F7C64F98-2495-4DAE-9387-3F2E9E9A7BB6");
            
            cmd.ExecuteNonQuery();

            Connexion.Con.Close();

            modifId = "";

            return cmd.Parameters["@responseMessage"].Value.ToString();

        }
        public string Suppretion_Action(string id)
        {
            new Connexion();
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.D_Action", Connexion.Con);

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