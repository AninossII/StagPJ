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
        private Action a;
        private In inMoney;
        private Out outMoney;

        private Connexion con;
        private Utilisateur u;
        private Compte c;

        private DataTable dataTable;
        private static bool _bMod = true;
        private static string coptName;

        protected void Page_Load(object sender, EventArgs e)
        {
            u = new Utilisateur();
            a = new Action();
            c = new Compte();
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

            if (_bMod)
            {
                dataTable = new DataTable();
                dataTable = con.showParamDataTable("dbo.Get_Comptes_from_ID_Utili");

                dlCompts.DataSource = dataTable;
                dlCompts.DataBind();
                dlCompts.DataTextField = "Nom";
                dlCompts.DataValueField = "ID";
                dlCompts.DataBind();
                _bMod = false;
            }

            if (a.ID != null && tbPrix.Text == String.Empty)
            { 
                dataTable = new DataTable();
                dataTable = con.showDataTable("select * from dbo.action" + " where ID = '" + a.ID + "'");
                
                tbPrix.Text = dataTable.Rows[0][3].ToString().Trim();
                tbDes.Text = dataTable.Rows[0][2].ToString().ToString().Trim();
                dlCompts.Items.FindByValue(c.ID).Selected = true;
                btnEvent.Text = "Modifier Event";
                _bMod = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventPage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            a = new Action();
            inMoney = new In();
            outMoney = new Out();

            c = new Compte();
            con = new Connexion();

            a.Montant = float.Parse(tbPrix.Text);
            a.Des = tbDes.Text;
            c.ID = dlCompts.Text;
            _bMod = true;
            
            if (c.ID == dlCompts.Text || a.ID == null)
            {
                if (a.ID == null)
                {
                   
                    if (cbAjout.Checked)
                    {
                        a.Ajouter_Action();
                        inMoney.Add();
                    }
                    else
                    {
                        a.Ajouter_Action();
                        outMoney.Withdraw();
                    }
                    Response.Redirect("EventPage.aspx");
                }
                else
                {
                    a.Time = DateTime.Parse(dataTable.Rows[0][1].ToString());
                    a.Modifiere_Action();

                    Response.Redirect("EventPage.aspx");
                }
            }
            else
            {
                a.Time = DateTime.Parse(dataTable.Rows[0][1].ToString());
                
                a.Suppretion_Action();
                a.Ajouter_Action();

                Response.Redirect("EventPage.aspx");
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}