using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace InterfaceClient
{
    public class DataVehicule
    {
        public struct vehicule
        {
            public string marque { get; set; }
            public string model { get; set; }
        };

        public List<vehicule> Vehicules = new List<vehicule>();

        public void getVehicules()
        {
            using (MySqlConnection conn = new MySqlConnection(HomeController.cs))
            {
                
                conn.Open();
                MySqlCommand command = new MySqlCommand(@"select nom_marque from tmarque", conn);
                MySqlDataReader dr = command.ExecuteReader();
                while(dr.Read())
                {
                    Vehicules.Add(new vehicule { marque = dr[0].ToString(),model="" });
                }
                conn.Close();
            }
        }
    }
}