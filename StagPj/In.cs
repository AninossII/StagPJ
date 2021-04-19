using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace StagPj
{
    public class In : Action
    {
        private string cvalue;
        
        private Source source;

        public string cValue
        {
            get { return cvalue; }
            set { cvalue = value; }
        }

        public In()
        {
            con = new Connexion();
        }

        public void Add()
        {
            Add_Money(Montant);

            // -- Add Category

            con.showDataTable("insert into dbo.Categorie(Designation,A_id) values('" + cvalue + "','" + ID + "')");
        }

        ////////////// ----- InMoney ----- //////////////

        public string Add_Money(float prix)
        {
            u = new Utilisateur();
            c = new Compte();

            con.Con.Open();

            cmd = new SqlCommand("dbo.Add_Money", con.Con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id_C", SqlDbType.UniqueIdentifier);
            cmd.Parameters.Add("@id_U", SqlDbType.UniqueIdentifier);
            cmd.Parameters.Add("@Montant", SqlDbType.Float);
            cmd.Parameters.Add("@responseMessage", SqlDbType.Char, 256);

            cmd.Parameters["@responseMessage"].Direction = ParameterDirection.Output;

            cmd.Parameters["@id_C"].Value = Guid.Parse(c.ID);
            cmd.Parameters["@id_U"].Value = Guid.Parse(u.ID);
            cmd.Parameters["@Montant"].Value = prix;

            cmd.ExecuteNonQuery();

            con.Con.Close();

            return cmd.Parameters["@responseMessage"].Value.ToString();
        }
    }
}