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
        private Boolean _modState = false;
        private DataTable _dataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            A = new Action();
            new Connexion();
            if (!(A.ModifID == ""))
            {
                Connexion.Con.Open();

                System.Data.SqlClient.SqlCommand cmd = new SqlCommand("select * from dbo.action" +
                                                                      " where ID = '"+ A.ModifID + "'",
                    Connexion.Con);

                cmd.ExecuteNonQuery();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                _dataTable = new DataTable();

                dataAdapter.Fill(_dataTable);

                tbPrix.Text = _dataTable.Rows[0][3].ToString();
                tbDes.Text = _dataTable.Rows[0][2].ToString();

                btnEvent.Text = "Modifier Event";

                _modState = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            A = new Action();

            if (_modState == false)
            {
                A.Montant = float.Parse(tbPrix.Text);
                A.Des = tbDes.Text;

                Response.Write(A.Ajouter_Action());
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                A.Montant = float.Parse(tbPrix.Text);
                A.Des = tbDes.Text;

                string _time;

                _time = _dataTable.Rows[0][1].ToString().Split(' ')[1];

                int i = 0;
                int k = 0;

                foreach (char c in _time)
                {
                    if (c == ':')
                        k += 1;

                    i++;

                    if (k == 2)
                        break;
                }

                Response.Write(A.modifiere_Action(_time.Substring(0, (i - 1)), _dataTable.Rows[0][4].ToString()));
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}