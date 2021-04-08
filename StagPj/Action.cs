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

        private static string Id;
        private DateTime time;
        private float montant;
        private string designation;
        public Compte compte;
        public Utilisateur utilisateur;
        private Connexion con = new Connexion();

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

        public string ID
        {
            get { return Id; }
            set { Id = value; }
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
            return con.Ajouter_Action(designation, montant);
        }

        public string Modifiere_Action()
        {
            return con.Modifiere_Action(designation, montant);
        }

        public string Suppretion_Action()
        {
            return con.Suppretion_Action();
        }
    }
}