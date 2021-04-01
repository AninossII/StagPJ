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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SQL5103.site4now.net;Initial Catalog=DB_A71E52_db01;User Id=DB_A71E52_db01_admin;Password=db01.1234");
            
            SqlCommand cmd = new SqlCommand("dbo.User_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.Char, 150);
            cmd.Parameters.Add("@Password", SqlDbType.Char, 20);
            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);
            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@Email"].Value = TextBox1.Text;
            cmd.Parameters["@Password"].Value = TextBox2.Text;
            con.Open();
            cmd.ExecuteNonQuery();

             Response.Write(cmd.Parameters["@responseMessage"].Value);
            

            con.Close();
        }

        
    }
}