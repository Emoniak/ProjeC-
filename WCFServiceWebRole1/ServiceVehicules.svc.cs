using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using librairyOutil;
using MySql.Data.MySqlClient;

namespace WCFServiceWebRole1
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IServiceVehicules
    {
        public bool AjouterOption(Option option)
        {
            throw new NotImplementedException();
        }

        public bool CreerModel(Vehicule vehicule)
        {
            string idMarque="",idModel="",idcategorie="";
            int version=-1;
            string[] idOption = new string[vehicule.Options.Length];
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["AzureDb"].ConnectionString))
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
                        command.CommandText = "call insertModel(" + idMarque + ",'" + vehicule.Model + "',"+idcategorie+")";
                        command.ExecuteNonQuery();
                        version = 0;
                    }
                    dr.Close();

                    //ajoue des options
                    int i = 0;
                    foreach (var item in vehicule.Options)
                    {
                        if(AjouterOption(item)==false)
                        {
                            transaction.Rollback();
                            return false;
                        }
                        command.CommandText = @"select LAST_INSERT_ID() from toption";
                        dr = command.ExecuteReader();
                        if (dr.Read())
                            idOption[i] = dr[0].ToString();
                        dr.Close();
                        i++;
                    }

                    for (int j = 0; j < i; j++)
                    {
                        command.CommandText = "call choisirOption(" + idOption[j] + "," + idModel + "," + version + ")";
                    }


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
