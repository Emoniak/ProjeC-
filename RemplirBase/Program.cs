using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Configuration;

namespace RemplirBase
{
    class Program
    {
        static void Main(string[] args)
        {
            string connctionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\antoi\Source\Repos\Emoniak\ProjeC-\RemplirBase\Ressource\DB Vehicle PTE.xls.csv");
            string[] uneLigne = new string[17];
            string descriptionOption = "";
            int version = 0;
            int idcat = 0;

            using (MySqlConnection conn = new MySqlConnection(connctionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"    insert into tclient (Nom_client,isphysique)
    values('aucun client',0)", conn);
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"insert into tcategorie (NOM_CATEGORIE) values ('Voiture')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }

                foreach (string line in lines)
                {
                    uneLigne = line.Split(';');
                    using (MySqlConnection conn = new MySqlConnection(connctionString))
                    {
                        version++;
                        conn.Open();

                        MySqlCommand command = conn.CreateCommand();
                        MySqlTransaction transaction;
                        transaction = conn.BeginTransaction();
                        command.Connection = conn;
                        command.Transaction = transaction;

                        MySqlDataReader dr;

                        try
                        {
                            command.CommandText = "select id_marque from tmarque where NOM_MARQUE='" + uneLigne[0] + "'";
                            dr = command.ExecuteReader();
                            if (dr.Read())
                                uneLigne[0] = dr["id_marque"].ToString();
                            else
                            {
                                dr.Close();
                                command.CommandText = "call InsertMarque('" + uneLigne[0] + "')";
                                command.ExecuteNonQuery();
                                command.CommandText = "call InsertEntreprise('" + uneLigne[0] + "')";
                                command.ExecuteNonQuery();
                            }
                            dr.Close();



                            command.CommandText = "select id_marque from tmarque where NOM_MARQUE='" + uneLigne[0] + "'";
                            dr = command.ExecuteReader();
                            if (dr.Read())
                                uneLigne[0] = dr["id_marque"].ToString();
                            dr.Close();

                        command.CommandText = "select ID_CATEGORIE from tcategorie where NOM_CATEGORIE='Voiture'";
                        dr = command.ExecuteReader();
                        if (dr.Read())
                            idcat = Convert.ToInt32(dr["ID_CATEGORIE"]);
                        dr.Close();

                        command.CommandText = "select id_model from tmodel where NOM_Model='" + uneLigne[1] + "'";
                            dr = command.ExecuteReader();
                            if (dr.Read())
                                uneLigne[1] = dr["id_model"].ToString();
                            else
                            {
                                dr.Close();
                                command.CommandText = "call insertModel(" + uneLigne[0] + ",'" + uneLigne[1] + "',"+idcat+")";
                                command.ExecuteNonQuery();
                                version = 1;
                            }
                            dr.Close();

                            command.CommandText = "select Id_option from toption where nom_Option='Moteur " + uneLigne[2] + "'";
                            dr = command.ExecuteReader();
                            if (dr.Read())
                                uneLigne[2] = dr["Id_option"].ToString();
                            else
                            {
                                dr.Close();
                                descriptionOption = "Torque (Nm/rpm) : " + uneLigne[4];
                                descriptionOption += "\n (l/100) : " + uneLigne[6];
                                descriptionOption += "\n CO2(g/km) : " + uneLigne[7];
                                Random rand = new Random();
                                command.CommandText = "call InsertOption('Moteur " + uneLigne[2] + "','" + descriptionOption + "',"+rand.Next(3000,10000)+")";
                                command.ExecuteNonQuery();
                            }
                            dr.Close();

                            //gros slct a faire pour affecter les id a la place ds nom
                            command.CommandText = "select id_model from tmodel where NOM_Model='" + uneLigne[1] + "'";
                            dr = command.ExecuteReader();
                            if (dr.Read())
                                uneLigne[1] = dr["id_model"].ToString();
                            dr.Close();
                            command.CommandText = "select Id_option from toption where nom_Option='Moteur " + uneLigne[2] + "'";
                            dr = command.ExecuteReader();
                            if (dr.Read())
                                uneLigne[2] = dr["Id_option"].ToString();
                            dr.Close();

                            command.CommandText = "call choisirOption(" + uneLigne[2] + "," + uneLigne[1] + "," + version + ")";
                            command.ExecuteNonQuery();

                            transaction.Commit();
                            Console.WriteLine("donnée crée");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            transaction.Rollback();
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            Console.WriteLine("fini");
            Console.ReadLine();
        }
    }
}
