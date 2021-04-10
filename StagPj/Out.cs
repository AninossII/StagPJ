using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StagPj
{
    public class Out : Action
    {
        private Connexion con;
        private Category cat;

        public void Withdraw()
        {
            con = new Connexion();
            con.Withdraw_Money(Montant);
        }

        /*public Out() : base()
        {
            cat = new Category();
        }
        public float losses()
        {
            
            return 0;
        }*/
    }
}