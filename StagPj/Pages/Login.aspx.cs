using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;

namespace StagPj
{
    public partial class Login : System.Web.UI.Page
    {
        private Utilisateur U;
        private Connexion C;
        private static int index = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Cookies["logIn"] != null)
            {
                tbEmail.Text = Request.Cookies["logIn"]["Email"];
                tbPass.Text = Request.Cookies["logIn"]["Password"];
                cbReamember.Checked = true;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            U = new Utilisateur();
            C = new Connexion();
            
            U.Email = tbEmail.Text;
            U.Password = tbPass.Text;
            
            string _message = U.LogIn();
            
            _message = _message.Split(' ')[0];

            if (_message.Equals("50500##Connected"))
            {
                HttpCookie httpCookie = new HttpCookie("logIn");
                if (cbReamember.Checked)
                {
                    httpCookie["Email"] = tbEmail.Text;
                    httpCookie["Password"] = tbPass.Text;
                    httpCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(httpCookie);

                    Response.Write("Data Done");
                }
                else
                {
                    tbEmail.Text = "";
                    tbPass.Text = "";
                }

                U.ID = C.UserId();
                
                Response.Redirect("HomePage.aspx");
            }
        }


    }
}