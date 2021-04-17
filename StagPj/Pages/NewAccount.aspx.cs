using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StagPj.Pages
{
    public partial class NewAccount : System.Web.UI.Page
    {
        private Compte c;
        private Connexion con;
        private Utilisateur u;

        private DataTable dataTable;
        private static Boolean _bMod = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            c = new Compte();
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

            if (c.ID != null && _bMod)
            {
                dataTable = new DataTable();
                dataTable = con.showDataTable("select * from Comptes where ID = '" + c.ID + "' and U_id = '" + u.ID + "'");
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    tbMontant.Text = dataRow["C_Montant"].ToString().Trim();
                    tbNom.Text = dataRow["Nom"].ToString().Trim();
                }

                btnAccount.Text = "Modifier Account";
                _bMod = false;
            }

        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            c = new Compte();
            if(c.ID == null)
            {
                c = new Compte(tbNom.Text, float.Parse(tbMontant.Text));
                c.Ajouter();
                Response.Redirect("Accounts.aspx");
            }
            else
            {
                c = new Compte(tbNom.Text, float.Parse(tbMontant.Text));
                c.Modifier();
                Response.Redirect("Accounts.aspx");
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accounts.aspx");
        }
    }
}