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
        protected string id;
        protected DateTime timee;
        protected float montant;
        protected string designation;
        public Connexion connexion;
        public Compte compte;
        public Utilisateur utilisateur;
        public Action()
        {
            compte = new Compte();
            utilisateur = new Utilisateur();
            connexion = new Connexion();

        }
        public Action(DateTime timee, float montant, string designation)
        {
            this.timee = timee;
            this.montant = montant;
            this.designation = designation;
        }

        public string Ajouter_Action(string Prix, string Designation)
        {
            new Connexion();
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.I_Action", Connexion.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Time", SqlDbType.Char, 150);
            cmd.Parameters.Add("@Designation", SqlDbType.Char, 256);
            cmd.Parameters.Add("@Prix", SqlDbType.Float);
            cmd.Parameters.Add("@C_id", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@Time"].Value = DateTime.Now;
            cmd.Parameters["@Designation"].Value = Designation;
            cmd.Parameters["@Prix"].Value = float.Parse(Prix);
            cmd.Parameters["@C_id"].Value = Guid.Parse("F7C64F98-2495-4DAE-9387-3F2E9E9A7BB6");


            cmd.ExecuteNonQuery();

            Connexion.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();

        }

        public void modifiere_Action()
        {

        }
        public void suppretion_Action()
        {

        }
    }
}