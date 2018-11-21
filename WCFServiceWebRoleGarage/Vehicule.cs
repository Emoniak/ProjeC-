using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFServiceWebRoleGarage
{
    [DataContract]
    public class Vehicule
    {
        private int nbRoue;
        private string marque;
        private string model;
        private int plaque;
        private string categorie;
        private Option[] options;

        [DataMember]
        public Option[] Options
        {
            get { return options; }
            set { options = value; }
        }

        [DataMember]
        public string Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        [DataMember]
        public int Plaque
        {
            get { return plaque; }
            set { plaque = value; }
        }

        [DataMember]
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        [DataMember]
        public string Marque
        {
            get { return marque; }
            set { marque = value; }
        }

        [DataMember]
        public int NbRoue
        {
            get { return nbRoue; }
            set { nbRoue = value; }
        }
    }
}