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
        private string id;
        private string email;
        private string password;
        private string nom;
        private string prenom;
        private DateTime datenes;
        private DateTime dateins;
        private char genre;
        public Connexion connexion;
        public Utilisateur()
        {
            connexion = new Connexion();
        }
        public Utilisateur(string email, string pswrd, string nom, string prnm, DateTime datenes, DateTime dateins, char genre)
        {
            this.email = email;
            this.password = pswrd;
            this.nom = nom;
            this.prenom = prnm;
            this.datenes = datenes;
            this.genre = genre;
        }
        public string Id
        {
            get { return id; }

        }
        public string Email
        {
            get { return email; }
            set { email = value; }
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
        public string SingUp(string Email, string Password, string Nom, string Prenom, DateTime Datenes,  char Genres)
        {
            new Connexion();
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.I_Utilisateur", Connexion.Con);
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

            cmd.Parameters["@Email"].Value = Email;
            cmd.Parameters["@Password"].Value = Password;
            cmd.Parameters["@Nom"].Value = Nom;
            cmd.Parameters["@Prenom"].Value = Prenom;
            cmd.Parameters["@Datenes"].Value = Datenes;
            cmd.Parameters["@Dateins"].Value = DateTime.Now;
            cmd.Parameters["@Genre"].Value = Genre;
            cmd.ExecuteNonQuery();

            Connexion.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }

        public string LogIn()
        {
            new Connexion();
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.User_Login", Connexion.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.Char, 150);
            cmd.Parameters.Add("@password", SqlDbType.Char, 20);
            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@password"].Value = password;

            cmd.ExecuteNonQuery();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }
    }
}