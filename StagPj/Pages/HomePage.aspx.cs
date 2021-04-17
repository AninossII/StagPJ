using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace StagPj.Pages
{
    public partial class HomePage : System.Web.UI.Page
    {
        private DataTable comptesTable;

        private Connexion con;
        private Utilisateur u;
        private Action a;

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
            
            comptesTable = con.showParamDataTable("dbo.statistiques","@id_U");

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

            lbDep.Text = con.StaticWithdrawMoney();
            lbDep.ForeColor = Color.Red;

            lbRess.Text = con.StaticAddMoney();
            lbRess.ForeColor = Color.CadetBlue;
        }

        void SponeContent(string name, string htmlString)
        {
            var lbName = new Label();
            lbName.Text = name;

            lbCompt.Visible = true;
            lbCompt.Controls.Add(lbName);
            lbCompt.Controls.Add(new LiteralControl(htmlString));

        }

        protected void btnWid_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEventPage.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            a = new Action();
            a.EventType = "+";
            Response.Redirect("NewEventPage.aspx");
        }
    }
}