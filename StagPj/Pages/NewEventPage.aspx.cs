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

        protected void Page_Load(object sender, EventArgs e)
        {
            new Connexion();
            A = new Action();

            if (A.ModifID != "" && tbPrix.Text == "")
            {
                Connexion.Con.Open();

                System.Data.SqlClient.SqlCommand cmd = new SqlCommand("select * from dbo.action" +
                                                                      " where ID = '"+ A.ModifID +"'",
                    Connexion.Con);

                cmd.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                _dataTable = new DataTable();

                dataAdapter.Fill(_dataTable);

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

            if (A.ModifID == "")
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

                Response.Write(A.ModifID);

                A.Modifiere_Action();
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}