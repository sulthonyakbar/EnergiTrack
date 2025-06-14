using EnergiTrack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class KonsumsiPage : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private EnergyConsumptionManager manager;

        public KonsumsiPage()
        {
            InitializeComponent();
            manager = new EnergyConsumptionManager();
            ApplyTheme();
            RefreshDataGrid();
        }
        private void ApplyTheme()
        {
            this.BackColor = Color.White;

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.GridColor = Color.FromArgb(0, 112, 243);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 112, 243);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10);

            foreach (Control ctl in this.Controls)
            {
                if (ctl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(0, 112, 243);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI Semibold", 10);
                    btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 12, 12));
                }
            }

            labelTitle.ForeColor = Color.FromArgb(0, 112, 243);
            labelTitle.Font = new Font("Segoe UI Black", 18, FontStyle.Bold);
        }

        private void RefreshDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = manager.GetAllConsumptions();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    manager.AddConsumption(addForm.DeviceName, addForm.Consumption);
                    RefreshDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Tambah Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    manager.AddConsumption(addForm.DeviceName, addForm.Consumption);
                    RefreshDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Tambah Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih data yang ingin diedit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = (EnergyConsumption)dataGridView1.CurrentRow.DataBoundItem;
            var editForm = new AddEditForm(selected.DeviceName, selected.Consumption, true);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    manager.EditConsumption(selected.DeviceName, editForm.Consumption);
                    RefreshDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Edit Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih data yang ingin dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = (EnergyConsumption)dataGridView1.CurrentRow.DataBoundItem;
            var confirm = MessageBox.Show($"Hapus data perangkat '{selected.DeviceName}'?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                manager.RemoveConsumption(selected.DeviceName);
                RefreshDataGrid();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double totalCost = manager.CalculateTotalCost();
            MessageBox.Show($"Total biaya energi: Rp {totalCost:N2}", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }
    }
}
