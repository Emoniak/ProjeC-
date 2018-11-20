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
    public partial class ListeOptions : Form
    {
        public ListeOptions()
        {
            InitializeComponent();
        }

        private void ListeOptions_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();

                using (MySqlDataAdapter da = new MySqlDataAdapter("select NOM_OPTION as nom from toption", cn))
                {
                    da.Fill(dt);
                }
                dataGridViewOptions.DataSource = dt;
            }
        }

        private void dataGridViewOptions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(Program._cn))
            {
                cn.Open();
                if (dataGridViewOptions.SelectedCells.Count == 1)
                {
                    MySqlCommand cmd = new MySqlCommand("select caracteristique from toption where NOM_OPTION = '" + dataGridViewOptions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "'", cn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        richTextBoxOption.Text = dr[0].ToString() + "\n";
                    }
                    dr.Close();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("select caracteristique from toption where NOM_OPTION = '" + dataGridViewOptions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "'", cn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (richTextBoxOption.Text.Length != 0)
                        {
                            richTextBoxOption.Text += dr[0].ToString() + "\n";
                        }
                        else richTextBoxOption.Text = dr[0].ToString() + "\n";
                    }
                    dr.Close();
                }
            }
        }
    }
}
