using EnergiTrack;
using EnergiTrack.Service;
using EnergiTrack.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class KonsumsiPage : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private EnergyConsumptionManager manager;
        private void LoadPerangkat()
        {
            comboPerangkat.Items.Clear();
            foreach (var p in PerangkatService.GetDaftar())
            {
                comboPerangkat.Items.Add($"{p.Id} | {p.Nama} | {p.Daya}W");
            }
        }
        public KonsumsiPage()
        {
            InitializeComponent();
            manager = new EnergyConsumptionManager();
            ApplyTheme();
            LoadPerangkat();
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
            if (comboPerangkat.SelectedItem == null)
            {
                MessageBox.Show("Pilih perangkat dulu.");
                return;
            }

            // Parsing "ID | Nama | DayaW"
            var parts = comboPerangkat.SelectedItem.ToString().Split('|', 3);
            string nama = parts[1].Trim();
            int daya = int.Parse(Regex.Match(parts[2], @"\d+").Value); // ambil angka watt

            var device = new Device
            {
                Name = nama,
                PowerInWatts = daya
            };

            // Ambil jadwal dari JadwalService
            var semuaJadwal = JadwalService.GetDaftar()
                .Cast<DeviceSchedule>()
                .ToList();
            var jadwal = semuaJadwal.FirstOrDefault(j => j.DeviceName == nama);

            if (jadwal == null)
            {
                MessageBox.Show("Jadwal untuk perangkat ini belum tersedia.");
                return;
            }

            try
            {
                manager.AddConsumption(device, jadwal);
                RefreshDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void comboPerangkat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPerangkat.SelectedItem == null)
                return;

            var selected = comboPerangkat.SelectedItem.ToString(); 
            var parts = selected.Split('|');

            if (parts.Length >= 3)
            {
                string daya = parts[2].Trim(); 
                labelDaya.Text = $"Daya: {daya}";
            }
        }
    }
}
