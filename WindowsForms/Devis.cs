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
            #region creation datagridview
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "id_Devis";
            dataGridView1.Columns[1].Name = "id_client";
            dataGridView1.Columns[2].Name = "prix";
            dataGridView1.Columns[3].Name = "date";
            #endregion
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("select ID_DEVIS, ID_CLIENT, PRIX_DEVIS, Date_Devis from tdevis", cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                int cpt = 0;
                while(dr.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[cpt].Cells[0].Value = Convert.ToString(dr[0]);
                    dataGridView1.Rows[cpt].Cells[1].Value = Convert.ToString(dr[1]);
                    dataGridView1.Rows[cpt].Cells[2].Value = Convert.ToString(dr[2]);
                    //dataGridView1.Rows[cpt].Cells[3].Value = Convert.ToDateTime(dr[0].ToString());

                    cpt++;
                }
                
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
            string iddevis = "";
            string idclient = "";
            string idmodel = "";
            string idmarque = "";
            string idcategorie = "";
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from tclient where ID_client = "+idclient, cn);
                MySqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add();
                    dataGridView2.Rows[0].Cells[0].Value = Convert.ToString(dr[0]);
                    dataGridView2.Rows[0].Cells[1].Value = Convert.ToString(dr[1]);
                    dataGridView2.Rows[0].Cells[2].Value = Convert.ToString(dr[2]);
                    dataGridView2.Rows[0].Cells[3].Value = Convert.ToString(dr[3]);
                    dataGridView2.Rows[0].Cells[4].Value = Convert.ToString(dr[4]);
                }
                dataGridView2.Columns[0].Visible = false;

                MySqlCommand cmd3 = new MySqlCommand("select * from tvehicule where ID_DEVIS = " + iddevis, cn);
                MySqlDataReader dr2 = cmd3.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView3.Rows[0].Cells[0].Value = Convert.ToString(dr2[4]); // Numéro de plaque
                    idmodel = Convert.ToString(dr2[4]); //Id du model 
                }

                MySqlCommand cmd4 = new MySqlCommand("select * from tmodel where ID_MODEL = " + idmodel, cn);
                MySqlDataReader dataread = cmd4.ExecuteReader();
                while (dataread.Read())
                {
                    dataGridView3.Rows[0].Cells[1].Value = Convert.ToString(dataread[2]); // Nom du model
                    idcategorie = Convert.ToString(dataread[1]); // Id de la catégorie
                    idmarque = Convert.ToString(dataread[3]); //Id de la marque
                }

                MySqlCommand cmd5 = new MySqlCommand("select * from tcategorie where ID_CATEGORIE = " + idcategorie, cn);
                MySqlDataReader dataread2 = cmd5.ExecuteReader();
                while (dataread2.Read())
                {
                    dataGridView3.Rows[0].Cells[2].Value = Convert.ToString(dataread2[1]); // Nom de la catégorie
                }

                MySqlCommand cmd6 = new MySqlCommand("select * from tmarque where ID_MARQUE = " + idmarque, cn);
                MySqlDataReader dataread3 = cmd6.ExecuteReader();
                while (dataread3.Read())
                {
                    dataGridView3.Rows[0].Cells[3].Value = Convert.ToString(dataread3[1]); // Nom de la marque
                }



                dataGridView2.Columns[0].Visible = false;
            }
        }


        /*


*/
    }
}
