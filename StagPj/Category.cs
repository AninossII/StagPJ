using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StagPj
{
    public class Category
    {
        private string id;
        private string designation;
        public Connexion connexion;
        public Category()
        {
            connexion = new Connexion();

        }
        public Category(string designation)
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
        public void Ajouter_Category()
        {

        }
        public void modifiere_Category()
        {

        }
        public void suppretion_Category()
        {

        }
    }
}