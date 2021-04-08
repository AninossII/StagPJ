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

        protected void Page_Load(object sender, EventArgs e)
        {
            A = new Action();

            if (A.ID != null)
            {
                con = new Connexion();
                A = new Action();
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

            if (A.ID == null)
            {
                A.Montant = float.Parse(tbPrix.Text);
                A.Des = tbDes.Text;

                A.Ajouter_Action();
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                A.Montant = float.Parse(tbPrix.Text);
                A.Des = tbDes.Text;

                Response.Write(A.ID);

                A.Modifiere_Action();
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}