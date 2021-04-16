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

        private static string _id;
        private DateTime time;
        private static float _montant;
        private string designation;
        private static string _eventType;
        protected SqlCommand cmd;

        public Compte c;
        public Utilisateur u;
        public  Connexion con;

        public float Montant
        {
            get { return _montant; }
            set { _montant = value; }
        }

        public string Des
        {
            get { return designation; }
            set { designation = value; }
        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public string EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        public Action()
        {
            c = new Compte();
            u = new Utilisateur();
            con = new Connexion();
        }

        public Action(DateTime time, string designation)
        {
            this.designation = designation;
        }



        public string Ajouter()
        {
            c = new Compte();

            con.Con.Open();

            cmd = new SqlCommand("dbo.I_Action", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Time", SqlDbType.DateTime);
            cmd.Parameters.Add("@Designation", SqlDbType.Char, 256);
            cmd.Parameters.Add("@Prix", SqlDbType.Float);
            cmd.Parameters.Add("@C_id", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@Time"].Value = DateTime.Now;
            cmd.Parameters["@Designation"].Value = designation;
            cmd.Parameters["@Prix"].Value = _montant;
            cmd.Parameters["@C_id"].Value = Guid.Parse(c.ID);

            cmd.ExecuteNonQuery();

            con.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }

        ////////////// ----- Modifiere ----- //////////////

        public string Modifier()
        {
            c = new Compte();

            con.Con.Open();
            cmd = new SqlCommand("dbo.U_Action", con.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
            cmd.Parameters.Add("@Time", SqlDbType.DateTime);
            cmd.Parameters.Add("@Designation", SqlDbType.Char, 256);
            cmd.Parameters.Add("@Prix", SqlDbType.Float);
            cmd.Parameters.Add("@C_id", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@ID"].Value = Guid.Parse(_id);
            cmd.Parameters["@Time"].Value = time;
            cmd.Parameters["@Designation"].Value = designation;
            cmd.Parameters["@Prix"].Value = _montant;
            cmd.Parameters["@C_id"].Value = Guid.Parse(c.ID);

            cmd.ExecuteNonQuery();

            con.Con.Close();

            _id = null;

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }

        ////////////// ----- Suppretion ----- //////////////

        public string Suppretion()
        {
            c = new Compte();

            con.Con.Open();
            cmd = new SqlCommand("dbo.D_Action", con.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@ID"].Value = Guid.Parse(_id);

            cmd.ExecuteNonQuery();

            con.Con.Close();

            _id = null;

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }
    }
}