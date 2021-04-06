using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StagPj
{
    public partial class Register : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (tpswrd.Text.Equals(tconpsswrd.Text) == false)
            {
                Response.Write("mode passe no valid");
                return;
            }
      
            Utilisateur U =new Utilisateur();
            char gertCh =Convert.ToChar( Genre.SelectedValue.Substring(0,1));
                Response.Write(U.SingUp(temal.Text, tpswrd.Text, tnom.Text, tprenom.Text, Convert.ToDateTime(t_date_nes.Text), gertCh));
            

        }
    }
}