using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StagPj
{
    public class Out : Action
    {
        private Connexion con;
        private Category cat;

        public Out()
        {
            con = new Connexion();
        }

        public void Withdraw()
        {
            Withdraw_Money(-Montant);
        }

        ////////////// ----- WidrawMoney ----- //////////////

        private string Withdraw_Money(float prix)
        {
            u = new Utilisateur();
            c = new Compte();

            con.Con.Open();

            cmd = new SqlCommand("Withdraw_Money_from_compte", con.Con);

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