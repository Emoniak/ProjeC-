using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ServiceInterne.ServiceVehiculesClient client = new ServiceInterne.ServiceVehiculesClient();
            ServiceInterne.Option option = new ServiceInterne.Option();

            option.Nom = "Siege Chauffant";
            option.Caracteristique = "ameliore le confor en chauffant les fesses";

            string retour = client.AjouterOption(option);
            System.Console.WriteLine(retour);
            Console.ReadLine();
            */
            Console.WriteLine(DateTime.Now.ToString("u"));
            Console.ReadLine();
        }
    }
}
