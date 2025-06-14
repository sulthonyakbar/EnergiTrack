using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void buttonPerangkat_Click(object sender, EventArgs e)
        {
            Form1 perangkatPage = new Form1();
            perangkatPage.Show();
            this.Hide();
        }

        private void buttonJadwal_Click(object sender, EventArgs e)
        {
            JadwalPage jadwalPage = new JadwalPage();
            jadwalPage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
