using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StagPj
{
    public class In : Action
    {
        private Connexion con;
        private Source source;

        public void Add()
        {
            con = new Connexion();
            con.Add_Money(Montant);
        }
    }
}