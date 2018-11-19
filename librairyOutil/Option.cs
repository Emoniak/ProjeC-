using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librairyOutil
{
    public class Option
    {
        private string nom;
        private int prix;
        private string caracteristique;

        public string Caracteristique
        {
            get { return caracteristique; }
            set { caracteristique = value; }
        }


        public int Prix
        {
            get { return prix; }
            set { prix = value; }
        }


        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

    }
}
