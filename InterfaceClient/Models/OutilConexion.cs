using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InterfaceClient.Models
{
    public class OutilConexion
    {
        public static MySql.Data.MySqlClient.MySqlConnection initConexion()
        {
            return new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
        }
    }
}