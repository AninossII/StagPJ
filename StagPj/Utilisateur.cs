using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace StagPj
{
    public class Utilisateur
    {
        private static string _id;
        private static string _email;
        private string password;
        private string nom;
        private string prenom;
        private DateTime datenes;
        private DateTime dateins;
        private char genre;
        private SqlCommand cmd;

        private  Connexion con;
        
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime Datenes
        {
            get { return datenes; }
            set { datenes = value; }
        }

        public DateTime Dateins
        {
            get { return dateins; }
            set { dateins = DateTime.Today; }
        }

        public char Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public Utilisateur()
        {
            con = new Connexion();
        }

        public Utilisateur(string email, string pswrd, string nom, string prnm, DateTime datenes, DateTime dateins, char genre)
        {
            this.password = pswrd;
            this.nom = nom;
            this.prenom = prnm;
            this.datenes = datenes;
            this.genre = genre;
        }

        ////////////// ----- User ID ----- //////////////

        public string UserId()
        {
            con.Con.Open();
            
            cmd = new SqlCommand("select dbo.Get_ID_Utilisateur('" + _email + "')", con.Con);

            var executeScalar = cmd.ExecuteScalar();

            con.Con.Close();

            return executeScalar.ToString();
        }

        ////////////// ----- LogIn ----- //////////////

        public string LogIn()
        {
            con.Con.Open();

            cmd = new SqlCommand("dbo.User_Login", con.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.Char, 150);
            cmd.Parameters.Add("@password", SqlDbType.Char, 20);
            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@Email"].Value = _email;
            cmd.Parameters["@password"].Value = password;

            cmd.ExecuteNonQuery();

            con.Con.Close();

            string loginMessage = cmd.Parameters["@responseMessage"].Value.ToString().Trim();

            if (loginMessage == "50500##Connected")
            {
                _id = UserId();
            }

            return loginMessage;
        }

        ////////////// ----- SingUp ----- //////////////

        public string SingUp()
        {
            con.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.I_Utilisateur", con.Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.Char, 150);
            cmd.Parameters.Add("@Password", SqlDbType.Char, 20);
            cmd.Parameters.Add("@Nom", SqlDbType.Char, 20);
            cmd.Parameters.Add("@Prenom", SqlDbType.Char, 20);
            cmd.Parameters.Add("@Datenes", SqlDbType.Date);
            cmd.Parameters.Add("@Dateins", SqlDbType.DateTime);
            cmd.Parameters.Add("@Genre", SqlDbType.Char);

            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@Email"].Value = _email;
            cmd.Parameters["@Password"].Value = password;
            cmd.Parameters["@Nom"].Value = nom;
            cmd.Parameters["@Prenom"].Value = prenom;
            cmd.Parameters["@Datenes"].Value = datenes;
            cmd.Parameters["@Dateins"].Value = DateTime.Now;
            cmd.Parameters["@Genre"].Value = genre;
            cmd.ExecuteNonQuery();

            con.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }
    }
}