<<<<<<< HEAD
﻿using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EnergiTrack.Service;
=======
using EnergiTrack;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
>>>>>>> origin/1201210008_fauzirido

namespace WinFormsApp1
{
    public partial class PerangkatPage : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private EnergyConsumptionManager manager;

        public PerangkatPage()
        {
            InitializeComponent();
<<<<<<< HEAD
            InisialisasiListView();

            // Event Handler
            button2.Click += buttonTambah_Click;  // Tambah
            button3.Click += buttonEdit_Click;    // Edit
            button4.Click += buttonHapus_Click;   // Hapus
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;

            RefreshListView();
        }

        private void InisialisasiListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 150);
            listView1.Columns.Add("Nama Perangkat", 250);
            listView1.Columns.Add("Daya (Watt)", 200);
        }

        private void RefreshListView()
        {
            listView1.Items.Clear();
            foreach (var perangkat in GetAllPerangkat())
            {
                var item = new ListViewItem(perangkat.Id.ToString());
                item.SubItems.Add(perangkat.Nama);
                item.SubItems.Add(perangkat.Daya.ToString());
                listView1.Items.Add(item);
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            string nama = textBox2.Text.Trim();
            string dayaText = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(dayaText))
            {
                MessageBox.Show("Nama dan daya harus diisi.");
                return;
            }

            if (!int.TryParse(dayaText, out int daya))
            {
                MessageBox.Show("Daya harus berupa angka.");
                return;
            }

            if (!Regex.IsMatch(nama, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama perangkat hanya boleh mengandung huruf dan spasi.");
                return;
            }

            try
            {
                var perangkat = PerangkatService.TambahPerangkat(nama, daya);
                RefreshListView();
                ClearForm();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan diedit.");
                return;
            }

            var idText = listView1.SelectedItems[0].SubItems[0].Text;
            if (!int.TryParse(idText, out int id))
                return;

            string namaBaru = textBox2.Text.Trim();
            string dayaText = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(namaBaru) || string.IsNullOrWhiteSpace(dayaText))
            {
                MessageBox.Show("Nama dan daya harus diisi.");
                return;
            }

            if (!int.TryParse(dayaText, out int dayaBaru))
            {
                MessageBox.Show("Daya harus berupa angka.");
                return;
            }

            if (!Regex.IsMatch(namaBaru, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nama perangkat hanya boleh mengandung huruf dan spasi.");
                return;
            }

            try
            {
                PerangkatService.EditPerangkat(id, namaBaru, dayaBaru);
                RefreshListView();
                ClearForm();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus.");
                return;
            }

            var idText = listView1.SelectedItems[0].SubItems[0].Text;
            if (int.TryParse(idText, out int id))
            {
                PerangkatService.HapusPerangkat(id);
                RefreshListView();
                ClearForm();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];
                textBox1.Text = item.SubItems[0].Text;
                textBox2.Text = item.SubItems[1].Text;
                textBox3.Text = item.SubItems[2].Text;
            }
        }

        private List<Perangkat> GetAllPerangkat()
        {
            // Ambil semua perangkat dari PerangkatService (tidak ada method langsung, jadi kita simpan daftar internal ke sini jika ingin akses langsung)
            List<Perangkat> result = new();
            for (int i = 1; i < 1000; i++)
            {
                var perangkat = PerangkatService.GetPerangkatById(i);
                if (perangkat != null)
                    result.Add(perangkat);
            }
            return result;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
=======
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
>>>>>>> origin/1201210008_fauzirido
        }
    }
}
