using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;


namespace WindowsForms
{
    public partial class Devis : Form
    {
        public Devis()
        {
            InitializeComponent();
        }

        private void Devis_Load(object sender, EventArgs e)
        {
            onLoad();
        }

        private void onLoad()
        {
            ArrayList arr = new ArrayList();
            string iddevisverif = "";
            #region creation datagridview
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "id_Devis";
            dataGridView1.Columns[1].Name = "id_client";
            dataGridView1.Columns[2].Name = "prix";
            dataGridView1.Columns[3].Name = "date";
            #endregion
            //using (MySqlConnection cn = new MySqlConnection(Program._cn))
            //{
            //    cn.Open();
            //    MySqlCommand cmd = new MySqlCommand("select ID_DEVIS, ID_CLIENT, PRIX_DEVIS, Date_Devis from tdevis", cn);
            //    MySqlDataReader dr = cmd.ExecuteReader();
            //    int cpt = 0;
            //    while(dr.Read())
            //    {
            //        dataGridView1.Rows.Add();
            //        dataGridView1.Rows[cpt].Cells[0].Value = Convert.ToString(dr[0]);
            //        dataGridView1.Rows[cpt].Cells[1].Value = Convert.ToString(dr[1]);
            //        dataGridView1.Rows[cpt].Cells[2].Value = Convert.ToString(dr[2]);
            //        dataGridView1.Rows[cpt].Cells[3].Value = Convert.ToDateTime(dr[3].ToString());

            //        cpt++;
            //    }
            //    cn.Close();
            //}

            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();
                MySqlCommand faccmd = new MySqlCommand("select ID_DEVIS from tfacture", cn);
                MySqlDataReader facdr = faccmd.ExecuteReader();
               
                while (facdr.Read())
                {

                    arr.Add(Convert.ToString(facdr[0]));
                    
                }
                facdr.Close();

                MySqlCommand cmd = new MySqlCommand("select ID_DEVIS, ID_CLIENT, PRIX_DEVIS, Date_Devis from tdevis where id_devis in (select id_devis from tvehicule where plaque=0)", cn);
                MySqlDataReader dr = cmd.ExecuteReader();

                int cpt = 0;
                while (dr.Read())
                {
                    iddevisverif = Convert.ToString(dr[0]);
                    if(!arr.Contains(iddevisverif))
                    { 
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[cpt].Cells[0].Value = Convert.ToString(dr[0]);
                        dataGridView1.Rows[cpt].Cells[1].Value = Convert.ToString(dr[1]);
                        dataGridView1.Rows[cpt].Cells[2].Value = Convert.ToString(dr[2]);
                        dataGridView1.Rows[cpt].Cells[3].Value = Convert.ToDateTime(dr[3].ToString());
                        cpt++;
                    }
                    
                }

                cn.Close();
            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
        }

        

        private void PasserFacture_Click(object sender, EventArgs e)
        {

        }

        private void details_Click(object sender, EventArgs e)
        {
            string[] data = new string[dataGridView1.ColumnCount];
            string iddevis = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string idclient = "";
            string idmodel = "";
            string idmarque = "";
            string idcategorie = "";
            string idoption = "";
            int cptoption = 4;
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();
                MySqlCommand cmdcli = new MySqlCommand("select ID_CLIENT from tdevis where ID_DEVIS ="+iddevis, cn); //44 = idclient;
                MySqlDataReader recupcli = cmdcli.ExecuteReader();
                while (recupcli.Read())
                {
                    idclient = Convert.ToString(recupcli[0]);
                }
                recupcli.Close();

                    MySqlCommand cmd2 = new MySqlCommand("select * from tclient where ID_CLIENT ="+idclient, cn); //44 = idclient;
                MySqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[0].Cells[0].Value = Convert.ToString(dr[0]);
                    dataGridView2.Rows[0].Cells[1].Value = Convert.ToString(dr[1]);
                    string booll = Convert.ToString(dr[2]);
                    if(booll == "False")
                    {
                        dataGridView2.Rows[0].Cells[2].Value = "Non";
                    }
                    else
                    {
                        dataGridView2.Rows[0].Cells[2].Value = "Oui";
                    }

                   
                    dataGridView2.Rows[0].Cells[3].Value = Convert.ToString(dr[3]);
                    dataGridView2.Rows[0].Cells[4].Value = Convert.ToString(dr[4]);
                }
                dataGridView2.Columns[0].Visible = false;
                dr.Close();

                MySqlCommand cmd3 = new MySqlCommand("select ID_VEHICULE, ID_DEVIS, ID_CLIENT, ID_MODEL, PLAQUE from tvehicule where ID_CLIENT ="+idclient, cn);
                MySqlDataReader vehicule = cmd3.ExecuteReader();
                int cpt = 0;
                while (vehicule.Read())
                {
                    dataGridView3.Rows.Add();
                    dataGridView3.Rows[cpt].Cells[0].Value = Convert.ToString(vehicule[4]); // Numéro de plaque
                    idmodel = Convert.ToString(vehicule[3]); //Id du model 
                    cpt++;
                }
                vehicule.Close();

                MySqlCommand cmd4 = new MySqlCommand("select * from tmodel where ID_MODEL = " + idmodel, cn);
                MySqlDataReader dataread = cmd4.ExecuteReader();
                while (dataread.Read())
                {
                    dataGridView3.Rows[0].Cells[1].Value = Convert.ToString(dataread[2]); // Nom du model
                    idcategorie = Convert.ToString(dataread[3]); // Id de la catégorie
                    idmarque = Convert.ToString(dataread[1]); //Id de la marque
                }
                dataread.Close();

                MySqlCommand cmd5 = new MySqlCommand("select * from tcategorie where ID_CATEGORIE = " + idcategorie, cn);
                MySqlDataReader dataread2 = cmd5.ExecuteReader();
                while (dataread2.Read())
                {
                    dataGridView3.Rows[0].Cells[2].Value = Convert.ToString(dataread2[1]); // Nom de la catégorie
                }
                dataread2.Close();

                MySqlCommand cmd6 = new MySqlCommand("select * from tmarque where ID_MARQUE = " + idmarque, cn);
                MySqlDataReader dataread3 = cmd6.ExecuteReader();
                while (dataread3.Read())
                {
                    dataGridView3.Rows[0].Cells[3].Value = Convert.ToString(dataread3[1]); // Nom de la marque
                }
                dataread3.Close();

                //MySqlCommand cmd7 = new MySqlCommand("select * from toption_has_tmodel where ID_MODEL = " + idmodel, cn);
                //MySqlDataReader dataread4 = cmd7.ExecuteReader();
                //while (dataread4.Read())
                //{
                //    idoption = Convert.ToString(dataread4[0]);
                //    MySqlCommand cmd8 = new MySqlCommand("select * from toption where ID_OPTION = " + idoption, cn);
                //    MySqlDataReader dataread5 = cmd8.ExecuteReader();
                //    dataGridView3.Rows[0].Cells[cptoption].Value = Convert.ToString(dataread5[1]); // Nom de la marque
                //    cptoption++;
                //}
                //dataread4.Close();


                dataGridView2.Columns[0].Visible = false;
            }
        }


        /*


*/
    }
}
