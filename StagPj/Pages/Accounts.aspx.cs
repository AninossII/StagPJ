using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StagPj
{
    public partial class Accounts : System.Web.UI.Page
    {
        private Connexion con;
        private Compte c;
        private Utilisateur u;

        private DataTable dataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            c = new Compte();
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
            
            Label4.Text = "1" + "Event";

            timeText.Visible = false;
            ShowAccounts();

            /*SqlDataReader rd;
            rd = cmd.ExecuteReader();


            while (rd.Read())
            {
                timeText.Controls.Add(new LiteralControl("<div class=" + "Event" + ">"));

                SponeNewEvent("C_MontantLabel", rd["C_Montant"].ToString(), " ");
                
                
                SponeNewEvent("NomLabel", rd["Nom"].ToString(), "</br></br>");

                
                string _id = rd[0].ToString();
                
                timeText.Visible = true;
                
                timeText.Controls.Add(new LiteralControl(" "));

                var supButton = new Button();
                supButton.Text = "X";
                supButton.BackColor = Color.Red;
                supButton.Click += (s, ef) =>
                {
                    c = new Compte();
                    c.suppretion_Compte(_id);
                    Response.Redirect("Accounts.aspx");
                };
                timeText.Visible = true;
                timeText.Controls.Add(supButton);

                timeText.Controls.Add(new LiteralControl(" "));
                timeText.Controls.Add(new LiteralControl("</div>"));

            }*/


        }
        
        void SponeNewAccount(string name_compte, string cont, string htmlString)
        {
            var Tname_compte = new Label();
            Tname_compte.Text = cont;

            timeText.Visible = true;
            timeText.Controls.Add(Tname_compte);
            timeText.Controls.Add(new LiteralControl(htmlString));
        }

        void SponeNewButton(string btnName, string c_id, string u_id)
        {
            var modButton = new Button();
            modButton.Text = btnName;
            if (btnName == "X")
            {
                modButton.BackColor = Color.Red;
            }
            modButton.Click += (s, ef) =>
            {
                u = new Utilisateur();
                c = new Compte();
                c.ID = c_id;
                u.ID = u_id;
                Response.Redirect("NewEventPage.aspx");
            };
            timeText.Visible = true;
            timeText.Controls.Add(modButton);
            timeText.Controls.Add(new LiteralControl(" "));
        }

        DataTable AccountsTable()
        {
            u = new Utilisateur();
            con = new Connexion();

            dataTable = new DataTable();
            dataTable = con.showDataTable("select * from dbo.Comptes"+" where U_id = '" + u.ID + "'");

            return dataTable;
        }

        void ShowAccounts()
        {
            int index = 0;
            DataTable accountsTable = AccountsTable();

            con = new Connexion();

            foreach (DataRow dataRow in accountsTable.Rows)
            {
                timeText.Controls.Add(new LiteralControl("<div class=" + "Event" + ">"));

                SponeNewAccount("prixLabel", dataRow["Nom"].ToString(), " ");
                SponeNewAccount("acountLabel", dataRow["C_Montant"].ToString(), "</br>");

                string c_id = dataRow[0].ToString();
                string u_id = dataRow[3].ToString();

                SponeNewButton("Modifier", c_id, u_id);
                SponeNewButton("X", c_id, u_id);

                timeText.Controls.Add(new LiteralControl("</div>"));
                index++;
            }

        }
    }
}