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

            dataTable = new DataTable();

            con = new Connexion();

            DataTable cTable = con.showParamDataTable("dbo.Get_Comptes_from_ID_Utili", "@ID");

            DataTable actionTable = new DataTable();

            int i = 0;

            Label1.Controls.Add(new LiteralControl("<div>"));
            Label1.Controls.Add(new LiteralControl("<datalist id=" + "catyList" + ">"));

            foreach (DataRow cRaw in cTable.Rows)
            {
                actionTable = con.showDataTable("select * from dbo.action" + " where C_id = '" + cRaw["ID"] + "'");

                foreach (DataRow aRow in actionTable.Rows)
                {
                    actionTable = con.showDataTable("select * from dbo.categorie where A_id = '" + aRow["ID"] + "'");

                    if(actionTable.Rows.Count != 0)
                    {
                        Label1.Controls.Add(new LiteralControl("<option>"));

                        var Tname = new Label();
                        Tname.Text = actionTable.Rows[0][1].ToString();
                        Label1.Controls.Add(Tname);

                        Label1.Controls.Add(new LiteralControl("</option>"));
                    }
                }
               
            }

            Label1.Controls.Add(new LiteralControl("</datalist>"));
            Label1.Controls.Add(new LiteralControl("</div>"));
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(tags.Value);
        }
    }
}