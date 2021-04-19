using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        private Action a;

        private DataTable dataTable;
        private List<string> catList = new List<string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            a = new Action();
            u = new Utilisateur();
            con = new Connexion();

            if (u.ID != null)
            {

            }
            else if (Request.Cookies["logIn"] != null)
            {
                u.Email = Request.Cookies["logIn"]["Email"];
                u.Password = Request.Cookies["logIn"]["Password"];
                u.LogIn();
            }
            else if (u.ID == null)
            {
                Response.Redirect("Login.aspx");
            }
            
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
        }
    }
}