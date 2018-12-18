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
                DataVehicule d = new DataVehicule();
                d.getVehicules(loginCli.Login);
                return View("Index",d);
            }
            else
                return View(loginCli);
       }
    }
}