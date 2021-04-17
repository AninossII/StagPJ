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
        private Utilisateur u;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            u = new Utilisateur();

            if (tpswrd.Text.Equals(tconpsswrd.Text) == false)
            {
                Response.Write("mode passe no valid");
                return;
            }

            u.Email = temal.Text;
            u.Password = tpswrd.Text;
            u.Nom = tnom.Text;
            u.Prenom = tprenom.Text;
            u.Datenes = Convert.ToDateTime(t_date_nes.Text);
            u.Genre = Convert.ToChar(Genre.SelectedValue.Substring(0, 1));
            
            u.SingUp();
        }
    }
}