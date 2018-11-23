using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace WCFServiceWebRoleGarage
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService
    {
        private string connectionString = @"Server=mysql-serveur.mysql.database.azure.com; Database=db_garage; Uid=AdminGarage@mysql-serveur; Pwd=TOTO1234!;";
        public string AjouterOption(Option option)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                connection.Open();
                //verif si option existe
                MySqlCommand command = connection.CreateCommand();
                command.Connection = connection;

                MySqlDataReader dr;
                command.CommandText = @"select ID_OPTION from toption where NOM_OPTION='" + option.Nom + "'";
                dr = command.ExecuteReader();
                if (dr.Read())
                    return dr[0].ToString();
                else
                {
                    dr.Close();
                    command.CommandText = "call InsertOption('" + option.Nom + "','" + option.Caracteristique + "',"+option.Prix+")";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT LAST_INSERT_ID() FROM toption";
                    dr = command.ExecuteReader();
                    if (dr.Read())
                        return dr[0].ToString();
                }
            }
            return "";
        }

        public string CreateDevis(Vehicule vehicule,Client client)
        {
            //calcul du prix
            int prix = 0;
            foreach (var option in vehicule.Options)
            {
                prix += option.Prix;
            }
            string idDevis = "";
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                string idcli = "";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(@"select id_client from tclient where mail='"+client.Mail+"'",connection);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    idcli = dr[0].ToString();
                else
                    idcli = CreerClient(client);
                dr.Close();
                cmd.CommandText = @"call creationDevis(" + idcli + "," + prix + ",'" + DateTime.Now.ToString("u") + "')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT LAST_INSERT_ID() FROM tdevis";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    idDevis = dr[0].ToString();
            }
            return idDevis;
        }

        public string CreerClient(Client client)
        {
            string idcli = "";
            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(@"select id_client from tclient where mail='" + client.Mail + "'", conn);
                MySqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                    idcli = dr[0].ToString();
                else
                {
                    dr.Close();
                    command.CommandText = "call createClient('" + client.Nom + "','" + client.Tel + "','" + client.Mail + "')";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT LAST_INSERT_ID() FROM tclient";
                    dr = command.ExecuteReader();
                    if (dr.Read())
                        idcli = dr[0].ToString();
                }

            }
            return idcli;
        }

        public bool CreerModel(Vehicule vehicule,Client client)
        {
            string idMarque = "", idModel = "", idcategorie = "",idClient="",idDevis="";
            int version = -1;
            /*
            string[] idOption = new string[vehicule.Options.Length];

            int i = 0;
            foreach (var item in vehicule.Options)
            {
                idOption[i] = AjouterOption(item);
                i++;
            }*/

            idClient = CreerClient(client);
            idDevis = CreateDevis(vehicule,client);

            using (MySqlConnection conn = new MySqlConnection(this.connectionString))
            {
                conn.Open();

                MySqlCommand command = conn.CreateCommand();
                MySqlTransaction transaction;
                transaction = conn.BeginTransaction();
                command.Connection = conn;
                command.Transaction = transaction;

                MySqlDataReader dr;

                try
                {
                    command.CommandText = @"select ID_MARQUE from tmarque where NOM_MARQUE='" + vehicule.Marque + "';";
                    dr = command.ExecuteReader();
                    if (dr.Read())
                        idMarque = dr[0].ToString();
                    else
                    {
                        dr.Close();
                        command.CommandText = "call InsertMarque('" + vehicule.Marque + "')";
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT LAST_INSERT_ID() FROM tmarque";
                        dr = command.ExecuteReader();
                        if (dr.Read())
                            idMarque = dr[0].ToString();
                    }
                    dr.Close();

                    command.CommandText = @"select ID_CATEGORIE from tcategorie where NOM_CATEGORIE='" + vehicule.Categorie + "'";
                    dr = command.ExecuteReader();
                    if (dr.Read())
                        idcategorie = dr[0].ToString();
                    else
                    {
                        dr.Close();
                        command.CommandText = @"call InsertCategorie('" + vehicule.Categorie + "')";
                        command.ExecuteNonQuery();
                        command.CommandText = "select LAST_INSERT_ID() from tcategorie";
                        dr = command.ExecuteReader();
                        if (dr.Read())
                            idcategorie = dr[0].ToString();
                    }
                    dr.Close();

                    command.CommandText = @"select id_model from tmodel where nom_model='" + vehicule.Model + "';";
                    dr = command.ExecuteReader();
                    if (dr.Read())
                        idModel = dr[0].ToString();
                    else
                    {
                        dr.Close();
                        command.CommandText = "call insertModel(" + idMarque + ",'" + vehicule.Model + "'," + idcategorie + ")";
                        command.ExecuteNonQuery();
                        version = 0;
                        command.CommandText = "select LAST_INSERT_ID() from tmodel";
                        dr = command.ExecuteReader();
                        if (dr.Read())
                            idModel = dr[0].ToString();
                    }
                    dr.Close();

                    command.CommandText = @"select version from toption_has_tmodel where id_model=" + idModel + " order by version DESC";
                    dr = command.ExecuteReader();
                    if (dr.Read())
                        version = Convert.ToInt32(dr[0]) + 1;
                    dr.Close();
                    //ajoue des options
                    /*
                    for (int j = 0; j < idOption.Length; j++)
                    {
                        if (idOption[j] != "")
                            command.CommandText = "call choisirOption(" + idOption[j] + "," + idModel + "," + version + ")";
                        else
                        {
                            transaction.Rollback();
                            break;
                        }
                        command.ExecuteNonQuery();
                    }
                    */
                    //recuperation de l'usine
                    string idusine = "";
                    command.CommandText = "select id_client from tclient where nom_client='usine " + vehicule.Marque + "'";
                    dr = command.ExecuteReader();
                    if (dr.Read())
                        idusine = dr[0].ToString();
                    dr.Close();

                    //creation vehicule
                    command.CommandText = "call CreationVehicule(" + idDevis + "," + idusine + "," + idModel + ")";
                    command.ExecuteNonQuery();

                    //creation facture
                    command.CommandText = "call CreateFacture(" + idDevis + ",'" + DateTime.Now.ToString("u") + "')";
                    command.ExecuteNonQuery();


                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    return false;

                }
                finally
                {
                    conn.Close();
                }
            }

            return true;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
