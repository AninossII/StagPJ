using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StagPj.Pages
{
    public partial class HomePage : System.Web.UI.Page
    {
        private DataTable comptesTable;
        private Connexion con;
        private Utilisateur u;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Connexion();
            u = new Utilisateur();

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
            
            comptesTable = con.showDataTable("select * from dbo.Comptes where U_id = '"+u.ID+"'");

            lbCompt.Controls.Add(new LiteralControl("<div class=" + "comptsBox" + ">"));

            int index = 0;
            foreach (DataRow rowCompte in comptesTable.Rows)
            {
                SponeContent(rowCompte["Nom"].ToString(), ":  ");
                SponeContent(rowCompte["C_Montant"].ToString(), "</br>");

                index++;
                if (index > 2)
                {
                    break;
                }
            }
            lbCompt.Controls.Add(new LiteralControl("</div>"));

            lbCompt.Controls.Add(new LiteralControl("<div>"));

            lbCompt.Controls.Add(new LiteralControl("</div>"));
        }

        void SponeContent(string name, string htmlString)
        {
            var lbName = new Label();
            lbName.Text = name;

            lbCompt.Visible = true;
            lbCompt.Controls.Add(lbName);
            lbCompt.Controls.Add(new LiteralControl(htmlString));

        }   
    }
}