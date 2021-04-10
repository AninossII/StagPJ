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

            u.Email = Request.Cookies["logIn"]["Email"];
            u.Password = Request.Cookies["logIn"]["Password"];
            u.LogIn();
            Response.Write(u.Email);

            new Connexion();

            Connexion.Con.Open();
            
            cmd = new SqlCommand("select dbo.Get_ID_Utilisateur('" + u.Email +"')", Connexion.Con);

            var excmtReader = cmd.ExecuteScalar();

            Connexion.Con.Close();
            
            Response.Write(excmtReader.ToString());
        }
    }
}