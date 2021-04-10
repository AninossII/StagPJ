using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StagPj.Pages
{
    public partial class Profil : System.Web.UI.Page
    {
        private Utilisateur U;

        protected void Page_Load(object sender, EventArgs e)
        {
            U = new Utilisateur();

            if (Request.Cookies["logIn"] != null)
            {
                U.Email = Request.Cookies["logIn"]["Email"];
                U.Password = Request.Cookies["logIn"]["Password"];
                U.LogIn();
            }
            else if (U.ID == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}