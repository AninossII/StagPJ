using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StagPj.Pages
{
    public partial class TestForm : System.Web.UI.Page
    {
        private Connexion con;
        private SqlCommand cmd;
        private Utilisateur u;
        protected void Page_Load(object sender, EventArgs e)
        {
            u = new Utilisateur();
            con = new Connexion();

            u.Email = Request.Cookies["logIn"]["Email"];
            u.Password = Request.Cookies["logIn"]["Password"];
            u.LogIn();
            Response.Write(u.Email);
            
        }
    }
}