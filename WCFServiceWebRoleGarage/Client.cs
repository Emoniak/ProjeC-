using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFServiceWebRoleGarage
{
    [DataContract]
    public class Client
    {
        private string nom;
        private string tel;
        private string mail;

        [DataMember]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }


        [DataMember]
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }



        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

    }
}