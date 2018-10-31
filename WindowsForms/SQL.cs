using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    public static class SQL
    {
        public static string DB;
        public static string MDP;

        public static string ConnexionString()
        {
            return "Server=mysql-serveur.mysql.database.azure.com; Port=3306; Database="+DB+"; Uid=AdminGarage@mysql-serveur; Pwd="+MDP+"; SslMode=Preferred;";
        }
    }
}
