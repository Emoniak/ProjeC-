using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceWebRole1
{
    public class Vehicule
    {
        private int nbRoue;
        private string marque;
        private string model;
        private int plaque;
        private string categorie;
        private Option[] options;

        public Option[] Options
        {
            get { return options; }
            set { options = value; }
        }


        public string Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }


        public int Plaque
        {
            get { return plaque; }
            set { plaque = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public string Marque
        {
            get { return marque; }
            set { marque = value; }
        }

        public int NbRoue
        {
            get { return nbRoue; }
            set { nbRoue = value; }
        }

    }
}