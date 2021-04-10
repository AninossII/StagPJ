using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StagPj
{
    public partial class NewEventPage : System.Web.UI.Page
    {
        private Action A;
        private Connexion con;
        private Utilisateur U;
        private Compte C;

        private DataTable dataTable;
        private static bool bMod = true;
        private static string coptName;

        protected void Page_Load(object sender, EventArgs e)
        {
            U = new Utilisateur();
            A = new Action();
            C = new Compte();
            con = new Connexion();
            
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

            if (bMod)
            {
                dataTable = new DataTable();
                dataTable = con.showParamDataTable("dbo.Get_Comptes_from_ID_Utili");

                dlCompts.DataSource = dataTable;
                dlCompts.DataBind();
                dlCompts.DataTextField = "Nom";
                dlCompts.DataValueField = "ID";
                dlCompts.DataBind();
                bMod = false;
            }

            

            if (A.ID != null && tbPrix.Text == String.Empty)
            {
                dataTable = new DataTable();
                dataTable = con.showDataTable("select * from dbo.action" + " where ID = '" + A.ID + "'");
                
                tbPrix.Text = dataTable.Rows[0][3].ToString().Trim();
                tbDes.Text = dataTable.Rows[0][2].ToString().ToString().Trim();
                dlCompts.Items.FindByValue(C.ID).Selected = true;
                btnEvent.Text = "Modifier Event";
                bMod = false;
            }
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventPage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            A = new Action();
            C = new Compte();
            con = new Connexion();

            A.Montant = float.Parse(tbPrix.Text);
            A.Des = tbDes.Text;
            C.ID = dlCompts.Text;
            bMod = true;
            
            if (C.ID == dlCompts.Text || A.ID == null)
            {
                if (A.ID == null)
                {
                    A.Ajouter_Action();
                    if (cbAjout.Checked)
                    {
                        con.AddIn(float.Parse(tbPrix.Text));
                    }
                    else
                    {
                        con.WithdrawOut(float.Parse(tbPrix.Text));
                    }
                    Response.Redirect("EventPage.aspx");
                }
                else
                {
                    A.Time = DateTime.Parse(dataTable.Rows[0][1].ToString());
                    A.Modifiere_Action();

                    Response.Redirect("EventPage.aspx");
                }
            }
            else
            {
                A.Time = DateTime.Parse(dataTable.Rows[0][1].ToString());
                
                A.Suppretion_Action();
                A.Ajouter_Action();

                Response.Redirect("EventPage.aspx");
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}