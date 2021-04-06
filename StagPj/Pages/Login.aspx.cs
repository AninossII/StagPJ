using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace StagPj
{
    public partial class Login : System.Web.UI.Page
    {
        private Utilisateur U;
        protected void Page_Load(object sender, EventArgs e)
        {
            new Connexion();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            U = new Utilisateur();
            U.Email = tbEmail.Text;
            U.Password = tbPass.Text;
            string _message = "50500##Connected";
            if (_message== "50500##Connected")
            {
                 Response.Redirect("HomePage.aspx");
            }
            else
            {
                 Response.Write("the Password or Gmail in uncorrected");
            }
            Connexion.Con.Close();
        }

        
    }
}