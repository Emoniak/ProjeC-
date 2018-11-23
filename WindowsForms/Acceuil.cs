using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
