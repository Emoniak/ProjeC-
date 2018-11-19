using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librairyOutil
{
    public class Vehicule
    {
        private int nbRoue;
        private object[] options;
        private string marque;
        private string  model;
        private int plaque;

        public int Plaque
        {
            get { return plaque; }
            set { plaque = value; }
        }


        public string  Model
        {
            get { return model; }
            set { model = value; }
        }


        public string Marque
        {
            get { return marque; }
            set { marque = value; }
        }


        public object[] Options
        {
            get { return options; }
            set { options = value; }
        }


        public int NbRoue
        {
            get { return nbRoue; }
            set { nbRoue = value; }
        }

    }
}
