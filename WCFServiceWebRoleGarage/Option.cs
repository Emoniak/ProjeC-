using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFServiceWebRoleGarage
{
    [DataContract]
    public class Option
    {
        private string nom;
        private int prix;
        private string caracteristique;

        [DataMember]
        public string Caracteristique
        {
            get { return caracteristique; }
            set { caracteristique = value; }
        }

        [DataMember]
        public int Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
    }
}