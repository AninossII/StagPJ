using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StagPj
{
    public partial class NewEventPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Action A = new Action();

            A.Montant = float.Parse(TextBox1.Text);
            A.Des = TextBox2.Text;
            
            Response.Write(A.Ajouter_Action());
            
            Response.Redirect("HomePage.aspx");
        }
    }
}