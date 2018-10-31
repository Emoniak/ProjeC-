using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            SQL.DB = TbDb.Text;
            SQL.MDP = TbMdp.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(SQL.ConnexionString()))
                {
                    conn.Open();
                    conn.Close();
                }
                Form1 f = new Form1();
                this.Visible = false;
                f.ShowDialog();
                this.Visible = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
