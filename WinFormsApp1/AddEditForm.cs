using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class AddEditForm : Form
    {
        public string DeviceName => txtDeviceName.Text.Trim();
        public double Consumption
        {
            get
            {
                double.TryParse(txtConsumption.Text, out double consumption);
                return consumption;
            }
        }

        public AddEditForm()
        {
            InitializeComponent();
        }

        public AddEditForm(string deviceName, double consumption, bool isEditMode = false) : this()
        {
            txtDeviceName.Text = deviceName;
            txtConsumption.Text = consumption.ToString();

            if (isEditMode)
            {
                this.Text = "Edit Konsumsi Energi";
                btnSave.Text = "Update";
                txtDeviceName.ReadOnly = true; // Membuat txtDeviceName tidak bisa diubah
                txtDeviceName.BackColor = System.Drawing.Color.LightGray; // Styling agar terlihat disable
                txtDeviceName.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.Text = "Tambah Konsumsi Energi";
                btnSave.Text = "Simpan";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                MessageBox.Show("Nama device tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtConsumption.Text, out _))
            {
                MessageBox.Show("Konsumsi energi harus berupa angka.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
