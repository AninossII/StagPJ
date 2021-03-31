using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}