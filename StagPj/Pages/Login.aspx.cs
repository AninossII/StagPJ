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
        private Connexion C;

        protected void Page_Load(object sender, EventArgs e)
        {
            
                tbEmail.Text = Response.Cookies["Email"].Value;
                tbPass.Text = Response.Cookies["Password"].Value:


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            U = new Utilisateur();
            C = new Connexion();
            
            U.Email = tbEmail.Text;
            U.Password = tbPass.Text;
            //Response.Write("Email + Pass " + tbEmail.Text + tbPass.Text);
            string _message = U.LogIn();
            
            _message = _message.Split(' ')[0];
            Response.Write(_message);
            if (_message.Equals("50500##Connected"))
            {
                if (cbReamember.Checked != false)
                {
                    Response.Cookies["Email"].Value = tbEmail.Text;
                    Response.Cookies["Password"].Value = tbPass.Text;
                    Response.Write("Data Stored");
                }
                U.ID = C.UserId();


                //Response.Redirect("HomePage.aspx");
            }
        }


    }
}