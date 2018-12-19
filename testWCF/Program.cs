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
            ServiceInterne.ServiceClient service = new ServiceInterne.ServiceClient();
            ServiceInterne.Option option = new ServiceInterne.Option();

            option.Nom = "test2";
            option.Caracteristique="ta mere";
            option.Prix = 200;

            string retour = service.AjouterOption(option);

            System.Console.WriteLine(retour);
            Console.ReadLine();
            
            //Console.WriteLine(DateTime.Now.ToString("u"));
            //Console.ReadLine();
        }
    }
}
