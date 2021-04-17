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

            dataTable  = con.showParamDataTable("dbo.Get_Info_Profile");

            foreach (DataRow tRow in dataTable.Rows)
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
    }
}