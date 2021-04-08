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
        Action A;
        private DataTable _dataTable;
        private Connexion con;
        private Utilisateur U;
        private Compte C;
        protected void Page_Load(object sender, EventArgs e)
        {
            U = new Utilisateur();
            A = new Action();
            con = new Connexion();
            
            if (Request.Cookies["logIn"] != null)
            {
                Response.Write("Login with Cookies");
                U.Email = Request.Cookies["logIn"]["Email"];
                U.Password = Request.Cookies["logIn"]["Password"];
                U.LogIn();
            }
            else if (U.ID == null)
            {
                Response.Redirect("Login.aspx");
            }

            _dataTable = new DataTable();
            _dataTable = con.showParamDataTable("dbo.Get_Comptes_from_ID_Utili");

            dlCompts.DataSource = _dataTable;
            dlCompts.DataBind();
            dlCompts.DataTextField = "Nom";
            dlCompts.DataValueField = "ID";
            dlCompts.DataBind();

            if (A.ID != null)
            {
                _dataTable = new DataTable();
                _dataTable = con.showDataTable("select * from dbo.action" + " where ID = '" + A.ID + "'");
                
                tbPrix.Text = _dataTable.Rows[0][3].ToString();
                tbDes.Text = _dataTable.Rows[0][2].ToString();

                btnEvent.Text = "Modifier Event";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            A = new Action();
            C = new Compte();

            if (A.ID == null)
            {
                A.Montant = float.Parse(tbPrix.Text);
                A.Des = tbDes.Text;
                Compte.ID = dlCompts.SelectedValue;

                A.Ajouter_Action();

                Response.Redirect("HomePage.aspx");
            }
            else
            {
                A.Montant = float.Parse(tbPrix.Text);
                A.Des = tbDes.Text;
                A.Modifiere_Action();

                Response.Redirect("HomePage.aspx");
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}