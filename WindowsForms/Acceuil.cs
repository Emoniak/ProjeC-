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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createVoiture_Click(object sender, EventArgs e)
        {
            CreateVoiture cv = new CreateVoiture();
            cv.Show();
        }

        private void devis_Click(object sender, EventArgs e)
        {
            Devis devis = new Devis();
            devis.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();

                //using (MySqlDataAdapter da = new MySqlDataAdapter("select tvehicule.PLAQUE as plaque, tdevis.PRIX_DEVIS as prix, tmodel.NOM_MODEL as modele, tcategorie.NOM_CATEGORIE as categorie, tmarque.NOM_MARQUE as marque,tclient.NOM_CLIENT as nomClient, tclient.ISPHYSIQUE as clientPhysique, tclient.TEL as telClient, tclient.MAIL as mailClient, tfacture.ID_FACTURE as idFacture, tfacture.DATE_FACTURE as dateFacture from tcategorie, tclient, tdevis, tmarque, tmodel, tvehicule, tfacture where tvehicule.PLAQUE != '' and tcategorie.ID_CATEGORIE = tmodel.ID_Categorie and tclient.ID_CLIENT = tvehicule.ID_CLIENT and tdevis.ID_DEVIS = tvehicule.ID_DEVIS and tmarque.ID_MARQUE = tmodel.ID_MARQUE and tmodel.ID_MODEL = tvehicule.ID_MODEL and tfacture.ID_DEVIS = tvehicule.ID_DEVIS", cn))
                using (MySqlDataAdapter da = new MySqlDataAdapter("select tvehicule.PLAQUE as Plaque, tdevis.PRIX_DEVIS as 'Prix (€)', tmarque.NOM_MARQUE as Marque, tmodel.NOM_MODEL as Modele, tclient.NOM_CLIENT as 'Nom client', tclient.TEL as Telephone, tclient.MAIL as Mail, tfacture.DATE_FACTURE as 'Date facture' from tcategorie, tclient, tdevis, tmarque, tmodel, tvehicule, tfacture where tvehicule.PLAQUE != '' and tcategorie.ID_CATEGORIE = tmodel.ID_Categorie and tclient.ID_CLIENT = tvehicule.ID_CLIENT and tdevis.ID_DEVIS = tvehicule.ID_DEVIS and tmarque.ID_MARQUE = tmodel.ID_MARQUE and tmodel.ID_MODEL = tvehicule.ID_MODEL and tfacture.ID_DEVIS = tvehicule.ID_DEVIS", cn))
                {
                    da.Fill(dt);
                }
                dataGridViewVoiture.DataSource = dt;
            }
        }

        private void dataGridViewVoiture_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewOptions.DataSource = null;
            WCFUtils.ServiceClient cli = new WCFUtils.ServiceClient();
            string plaque = dataGridViewVoiture.Rows[e.RowIndex].Cells[0].Value.ToString();
            int idFacture = -1;
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("select tfacture.ID_FACTURE as idFacture from tfacture, tvehicule where tvehicule.PLAQUE = '" + plaque + "' and tfacture.ID_DEVIS = tvehicule.ID_DEVIS ", cn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    idFacture = Convert.ToInt32(dr["idFacture"]);
                }
            }
            WCFUtils.Option[] listeOptions = cli.listeOptions(idFacture.ToString());
            dataGridViewOptions.DataSource = listeOptions;
        }
    }
}
