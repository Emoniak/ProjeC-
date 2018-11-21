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
                    command.CommandText = "call InsertOption('" + option.Nom + "','" + option.Caracteristique + "')";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT LAST_INSERT_ID() FROM toption";
                    dr = command.ExecuteReader();
                    if (dr.Read())
                        return dr[0].ToString();
                }
            }
            return "";
        }

        public bool CreerModel(Vehicule vehicule)
        {
            string idMarque = "", idModel = "", idcategorie = "";
            int version = -1;
            string[] idOption = new string[vehicule.Options.Length];

            int i = 0;
            foreach (var item in vehicule.Options)
            {
                idOption[i] = AjouterOption(item);
                i++;
            }

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
                    }
                    dr.Close();

                    //ajoue des options
                    for (int j = 0; j < idOption.Length; j++)
                    {
                        if (idOption[j] != "")
                            command.CommandText = "call choisirOption(" + idOption[j] + "," + idModel + "," + version + ")";
                        else
                        {
                            transaction.Rollback();
                            break;
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
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
