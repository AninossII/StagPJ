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
        private static DateTime time;
        private static float _montant;
        private string designation;
        public Compte C;
        public Utilisateur utilisateur;
        private Connexion con = new Connexion();

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
            get { return Id; }
            set { Id = value; }
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public Action()
        {
            C = new Compte();
            utilisateur = new Utilisateur();
        }

        public Action(DateTime time, string designation)
        {
            
            this.designation = designation;
        }

        public string Ajouter_Action()
        {
            return con.Ajouter_Action(designation, _montant);
        }

        public string Modifiere_Action()
        {
            return con.Modifiere_Action(designation, _montant);
        }

        public string Suppretion_Action()
        {
            return con.Suppretion_Action();
        }
    }
}