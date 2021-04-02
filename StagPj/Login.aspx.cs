using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace StagPj
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            new Connexion();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {            
            Connexion.Con.Open();
            SqlCommand cmd = new SqlCommand("dbo.User_Login", Connexion.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Email", SqlDbType.Char, 150);
            cmd.Parameters.Add("@password", SqlDbType.Char, 20);
            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@Email"].Value = TextBox1.Text;
            cmd.Parameters["@password"].Value = TextBox2.Text;

            cmd.ExecuteNonQuery();

             Response.Write(cmd.Parameters["@responseMessage"].Value);


            Connexion.Con.Close();
        }

        
    }
}