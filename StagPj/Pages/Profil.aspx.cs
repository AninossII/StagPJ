using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StagPj.Pages
{
    public partial class Profil : System.Web.UI.Page
    {
        private Utilisateur u;
        private Connexion con;
        private DataTable dataTable;
        private DataTable transTable;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (u.ID != null)
            {
                GetInfo();
                GetComptsInfo();
            }
            else
            {
                Response.Write("Error no User ID");
            }
            
        }

        void GetInfo()
        {
            con = new Connexion();

            dataTable = new DataTable();

            transTable = con.showParamDataTable("dbo.Get_Info_Profile","@ID");

            foreach (DataRow tRow in transTable.Rows)
            {
                lbuserName.Text = tRow[0].ToString();
                lbdateInsc.Text = DateTime.Parse(tRow[1].ToString()).ToString("MM/dd/yyyy");
                lbcomptNum.Text = tRow[2].ToString();

                string time = tRow[3].ToString();

                if (DateTime.Parse(time).ToString("d") == DateTime.Now.ToString("d"))
                {
                    lblastTrans.Text = DateTime.Parse(time).ToString("h:mm:ss tt");

                }
                else
                {
                    lblastTrans.Text = DateTime.Parse(time).ToString("g");
                }

                lbtotal.Text = tRow[4].ToString();
            }
        }

        void GetComptsInfo()
        {
            dataTable = con.showParamDataTable("dbo.statistiques","@id_U");

            lbCompt.Controls.Add(new LiteralControl("<div class=" + "comptsBox" + ">"));
            int index = 0;
            foreach (DataRow rowCompte in dataTable.Rows)
            {
                SponeContent(rowCompte["Nom"].ToString(), ":  ");
                SponeContent(rowCompte["C_Montant"].ToString(), "</br>");


                transTable = con.showDataTable("select * from Action where C_id = '" + rowCompte["ID"].ToString() +
                                               "' order by Time DESC");

                lbCompt.Controls.Add(new LiteralControl("<div class=" + "transbox" + ">"));
                int index2 = 0;
                foreach (DataRow rowTrans in transTable.Rows)
                {
                    SponeContent(rowTrans["Prix"].ToString(), ":  ");
                    SponeContent(rowTrans["Designation"].ToString(), "</br>");
                    
                    index2++;
                    if (index2 > 2)
                    {
                        break;
                    }
                }
                lbCompt.Controls.Add(new LiteralControl("</div>"));

                index++;
                if (index > 2)
                {
                    break;
                }
            }
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewAccount.aspx");
        }

        protected void btnhomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btneventPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventPage.aspx");
        }

        protected void btnaccountPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accounts.aspx");
        }

        protected void btnprofilgPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profil.aspx");
        }
    }
}