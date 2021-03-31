using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StagPj
{
    public class Compte
    {
        private string id;
        private string nom;
        private DateTime datecreation;
        private float c_montant;
        public Connexion connexion;
        public Utilisateur utilisateur;
        public Compte()
        {
            utilisateur = new Utilisateur();
            connexion = new Connexion();
        }
        public Compte(string nom, float c_montant)
        {
            this.nom = nom;
            this.c_montant = c_montant;

        }
        public string Id
        {
            get { return id; }

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
        public void Ajouter_Compte()
        {

        }
        public void modifiere_Compte()
        {

        }
        public void suppretion_Compte()
        {

        }
    }
}