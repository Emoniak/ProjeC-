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
    public partial class SelectClient : Form
    {
        WCFUtils.Vehicule vehicule = new WCFUtils.Vehicule();
        public SelectClient(Object vehicule)
        {
            InitializeComponent();
            this.vehicule = (WCFUtils.Vehicule) vehicule;
        }

        private void SelectClient_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter("select NOM_CLIENT as nom from tclient", cn))
                {
                    da.Fill(dt);
                }
                dataGridViewClients.DataSource = dt;
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            WCFUtils.ServiceClient client = new WCFUtils.ServiceClient();
            WCFUtils.Client cli = new WCFUtils.Client();
            if (txtNom.Text!="")
            {
                cli.Nom = txtNom.Text;
                if (txtMail.Text!="") cli.Mail = txtMail.Text;
                if (txtTel.Text!="") cli.Tel = txtTel.Text;
            }
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();
                for (int i = 0; i < dataGridViewClients.SelectedCells.Count; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("select NOM_CLIENT, TEL, MAIL from tclient where NOM_CLIENT = '" + dataGridViewClients.SelectedCells[i] + "'", cn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cli = new WCFUtils.Client { Mail = dr["MAIL"].ToString(), Nom = dr["NOM_CLIENT"].ToString(), Tel = dr["TEL"].ToString() };
                    }
                    dr.Close();
                }
            }
            bool resultat = client.CreerModel(vehicule, cli);
            if (!resultat)
            {
                MessageBox.Show("Une erreur s'est produite, veuillez réessayer", "Erreur",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Cursor = Cursors.Default;
                this.Dispose();
            }
        }

        private void btnCreateDevis_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            WCFUtils.ServiceClient client = new WCFUtils.ServiceClient();
            WCFUtils.Client cli = new WCFUtils.Client();
            if (txtNom.Text != "")
            {
                cli.Nom = txtNom.Text;
                if (txtMail.Text != "") cli.Mail = txtMail.Text;
                if (txtTel.Text != "") cli.Tel = txtTel.Text;
            }
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();
                for (int i = 0; i < dataGridViewClients.SelectedCells.Count; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("select NOM_CLIENT, TEL, MAIL from tclient where NOM_CLIENT = '" + dataGridViewClients.SelectedCells[i] + "'", cn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cli = new WCFUtils.Client { Mail = dr["MAIL"].ToString(), Nom = dr["NOM_CLIENT"].ToString(), Tel = dr["TEL"].ToString() };
                    }
                    dr.Close();
                }
            }
            string resultat = client.CreateDevis(vehicule, cli);
            Cursor = Cursors.Default;
            this.Dispose();
        }
    }
}
