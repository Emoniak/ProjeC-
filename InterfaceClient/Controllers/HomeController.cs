using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfaceClient
{
    public class HomeController : Controller
    {
        public static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public static string id = "";
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(LoginCli loginCli)
        {
            if (loginCli.VerifID())
            {
                id = loginCli.Login;
                DataVehicule d = new DataVehicule();
                d.getVehicules(id);
                return View("Index",d);
            }
            else
                return View(loginCli);
        }

        public ActionResult Validation(string idvehicule,DataVehicule data)
        {
            string plaque = "";
            Random random = new Random();

            plaque+=random.Next(00, 99).ToString("00");
            plaque += Convert.ToChar(random.Next(65, 90));
            plaque += Convert.ToChar(random.Next(65, 90));
            plaque += random.Next(00, 99).ToString("00");

            ServiceReference.ServiceClient client = new ServiceReference.ServiceClient();
            client.SortieUsine(Convert.ToInt32(idvehicule), plaque);

            DataVehicule d = new DataVehicule();
            d.getVehicules(id);
            return View("Index", d);

        }
    }
}