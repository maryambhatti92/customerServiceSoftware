using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customerServiceSoftware
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_Close_Home_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnCases_Click(object sender, EventArgs e)
        {
            this.Hide();
            main main = new main();
            main.Show();
        }

        private void btnArchives_Click(object sender, EventArgs e)
        {
            this.Hide();
            Archive archives = new Archive();
            archives.Show();
        }
    }
}
