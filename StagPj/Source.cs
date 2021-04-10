using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StagPj
{
    public class Source
    {
        private string id;
        private string designation;
        public Connexion connexion;
        public Source()
        {
            connexion = new Connexion();

        }
        public Source(string designation)
        {
            this.designation = designation;
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        public void Ajouter_Sour()
        {

        }
        public void modifiere_Sour()
        {

        }
        public void suppretion_Sour()
        {

        }
    }
}