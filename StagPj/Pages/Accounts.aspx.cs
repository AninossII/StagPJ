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

        private Compte C;
        private string _name;

        void SponeNewEvent(string name_compte, string cont, string htmlString, string monSfx)
        {
            this._name = name_compte;

            var Tname_compte = new Label();
            Tname_compte.Text = cont + monSfx;

            timeText.Visible = true;
            timeText.Controls.Add(Tname_compte);
            timeText.Controls.Add(new LiteralControl(htmlString));

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            C = new Compte();

            //Label3.Text = "Today";
            //Label4.Text = "1" + "Event";

            timeText.Visible = false;

            new Connexion();
            Connexion.Con.Open();

            System.Data.SqlClient.SqlCommand cmd = new SqlCommand("select * from dbo.Comptes" +
                                                                  " where U_id = '7F1CB55C-0FDA-4AD7-BA40-9E7E2276B06C'",
                Connexion.Con);
            System.Data.SqlClient.SqlDataReader rd;
            rd = cmd.ExecuteReader();


            while (rd.Read())
            {
                timeText.Controls.Add(new LiteralControl("<div class=" + "Event" + ">"));

                SponeNewEvent("C_MontantLabel", rd["C_Montant"].ToString(), " ", " DH");



                //int i = 0;
                //int k = 0;

                //foreach (char c in _time)
                //{
                //    if (c == ':')
                //        k += 1;

                //    i++;

                //    if (k == 2)
                //        break;
                //}

                SponeNewEvent("NomLabel", rd["Nom"].ToString(), "</br></br>", "");

                
                string _id = rd[0].ToString();
                
                timeText.Visible = true;
                
                timeText.Controls.Add(new LiteralControl(" "));

                var supButton = new Button();
                supButton.Text = "X";
                supButton.BackColor = Color.Red;
                supButton.Click += (s, ef) =>
                {
                    C = new Compte();
                    C.suppretion_Compte(_id);
                    Response.Redirect("Accounts.aspx");
                };
                timeText.Visible = true;
                timeText.Controls.Add(supButton);

                timeText.Controls.Add(new LiteralControl(" "));
                timeText.Controls.Add(new LiteralControl("</div>"));

            }
        }
    }
}