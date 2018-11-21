using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WebApplication1
{
    public class Modele
    {
        public struct vehicule
        {
            public int ID { get; set; }
            public string Modele { get; set; }
            public string Marque { get; set; }
            public decimal Prix { get; set; }
        }
        public List<vehicule> Vehicules { get; }

        public void GetVehicules()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(@"requete", con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    //Vehicules.Add(new vehicule { ID = 0, Modele = "", Marque = "", Prix = 0 });
                    //dr[""].toString()
                }
            }

            
        }
    }
    
}