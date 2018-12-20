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
            public string id { get; set; }
            public string marque { get; set; }
            public string model { get; set; }
            public string[] options { get; set; }
            public string textOption { get; set; }
        };


        public List<vehicule> Vehicules = new List<vehicule>();

        public void getVehicules(string marque)
        {
            using (MySqlConnection conn = new MySqlConnection(HomeController.cs))
            {
                
                conn.Open();
                MySqlCommand command = new MySqlCommand(@"select ID_VEHICULE,ID_MODEL from tvehicule where id_client=(select id_client from tclient where nom_client='" + marque+"')", conn);
                MySqlDataReader dr = command.ExecuteReader();
                while(dr.Read())
                {
                    Vehicules.Add(getInfo(dr[0].ToString(), dr[1].ToString()));
                }
                conn.Close();
            }

        }

        private vehicule getInfo(string id_v,string idModel)
        {
            string marque="", model="";
            List<string> options=new List<string>();
            int id_marque = 0;
            string formatOption = "";

            using (MySqlConnection conn = new MySqlConnection(HomeController.cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select NOM_MODEL,Id_Marque from tmodel where id_model=" + idModel, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    model = dr[0].ToString();
                    id_marque = Convert.ToInt32(dr[1]);
                }
                dr.Close();
                cmd.CommandText = "select NOM_MARQUE from tmarque where id_marque ="+id_marque;
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    marque = dr[0].ToString();

                }
                dr.Close();
                cmd.CommandText = "select NOM_OPTION from toption where id_option in (select id_option from toption_has_tmodel where id_model =" + idModel + " and version =1)";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    options.Add(dr[0].ToString());
                    formatOption += dr[0].ToString() + "\n";
                }

            }

            return new vehicule { id=id_v, marque = marque, model = model, options = options.ToArray(), textOption=formatOption };
        }
    }
}