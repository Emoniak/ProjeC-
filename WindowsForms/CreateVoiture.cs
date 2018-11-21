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
    public partial class CreateVoiture : Form
    {
        public static List<String> listeOptions = new List<string>();
        public static DataGridView staticDGVOptions= null;



        public CreateVoiture()
        {
            InitializeComponent();
        }

        private void AddOption_Click(object sender, EventArgs e)
        {
            ListeOptions lo = new ListeOptions();
            lo.Show();
        }

        private void CreateVoiture_Load(object sender, EventArgs e)
        {
            onLoad();
        }

        private void comboBoxMarques_TextChanged(object sender, EventArgs e)
        {
            onChange();
        }

        private void onChange()
        {
            comboBoxModeles.Items.Clear();
            comboBoxModeles.Text = "";
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();
                int idMarque = -1;
                MySqlCommand cmd = new MySqlCommand("select ID_MARQUE from tmarque where NOM_MARQUE = '" + comboBoxMarques.Text + "'", cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idMarque = Convert.ToInt32(dr[0]);
                }
                dr.Close();

                int idCategorie = -1;
                cmd.CommandText = "select ID_CATEGORIE from tcategorie where NOM_CATEGORIE = '"+ comboBoxTypes.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idCategorie = Convert.ToInt32(dr[0]);
                }
                dr.Close();

                cmd.CommandText = "select NOM_MODEL from tmodel where ID_MARQUE = " + idMarque +" and ID_CATEGORIE = "+idCategorie;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxModeles.Items.Add(dr["NOM_MODEL"].ToString());
                }
                dr.Close();
            }
        }

        private void comboBoxTypes_TextChanged(object sender, EventArgs e)
        {
            onChange();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            onLoad();
        }

        private void onLoad()
        {
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("select NOM_CATEGORIE from tcategorie", cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxTypes.Items.Add(dr["NOM_CATEGORIE"].ToString());
                }
                dr.Close();

                cmd.CommandText = "select NOM_MARQUE from tmarque";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxMarques.Items.Add(dr["NOM_MARQUE"].ToString());
                }
                dr.Close();
            }
            if (listeOptions.Count != 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("nomOption");
                foreach (String nom in listeOptions)
                {
                    dt.Rows.Add(nom);
                }
                dataGridViewOptions.DataSource = dt;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (!comboBoxTypes.Text.Equals("") && !comboBoxMarques.Text.Equals("") && !comboBoxModeles.Text.Equals(""))
            {
                WCFUtils.ServiceClient client = new WCFUtils.ServiceClient();
                WCFUtils.Option[] options = new WCFUtils.Option[listeOptions.Count];
                WCFUtils.Vehicule vehicule = new WCFUtils.Vehicule();

                if (listeOptions.Count > 0)
                {
                    using (MySqlConnection cn = new MySqlConnection(Program._cn))
                    {
                        cn.Open();
                        for (int i = 0; i < listeOptions.Count; i++)
                        {
                            MySqlCommand cmd = new MySqlCommand("select caracteristique, NOM_OPTION from toption where NOM_OPTION = '" + listeOptions[i] + "'", cn);
                            MySqlDataReader dr = cmd.ExecuteReader();

                            options[i] = new WCFUtils.Option { Caracteristique = dr["NOM_OPTION"].ToString(), Nom = dr["caracteristique"].ToString() };
                        }
                    }
                }
                vehicule.Options = options;
                vehicule.Marque = comboBoxMarques.Text;
                vehicule.Categorie = comboBoxTypes.Text;
                vehicule.Model = comboBoxModeles.Text;

                bool resultat = client.CreerModel(vehicule);
                if (!resultat)
                {
                    MessageBox.Show("Une erreur s'est produite, veuillez réessayer", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else this.Dispose();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
