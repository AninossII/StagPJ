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
        public void Ajouter_Action()
        {

        }
        public void modifiere_Action()
        {

        }
        public void suppretion_Action()
        {

        }
    }
}