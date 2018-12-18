using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterfaceClient.Models;
using MySql.Data.MySqlClient;


namespace InterfaceClient
{
    public class LoginCli
    {
        private string login;
        private string mdp;

        [Display(Name = "mdp")]
        [Required]
        public string MDP
        {
            get { return mdp; }
            set { mdp = value; }
        }

        [Display(Name = "identifiant")]
        [Required]
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public bool VerifID()
        {
            using (MySqlConnection conn = new MySqlConnection(HomeController.cs))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(@"select id_client from tclient where nom_client='" + login + "'", conn);
                MySqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    if (mdp == dr[0].ToString())
                        return true;
                }
                conn.Close();
            }

            return false;
        }
    
    }
}