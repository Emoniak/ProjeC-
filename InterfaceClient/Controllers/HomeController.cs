using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfaceClient
{
    public class HomeController : Controller
    {
        public static string cs = @"Server=mysql-serveur.mysql.database.azure.com; Port=3306; Database=db_garage; Uid=AdminGarage@mysql-serveur; Pwd=TOTO1234!; SslMode=Preferred;";
        // GET: Home
        public ActionResult Index()
        {
            DataVehicule data = new DataVehicule();
            data.getVehicules();
            return View(data);
        }
    }
}