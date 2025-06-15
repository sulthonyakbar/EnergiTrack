using EnergiTrack;
using EnergiTrack.Model;
using EnergiTrack.Service;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
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
            LoadPerangkat();
            RefreshDataGrid();
            txtPricePerKWh.Text = manager.GetPricePerKWh().ToString("0.00");
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

        private void LoadPerangkat()
        {
            comboPerangkat.Items.Clear();
            foreach (var p in PerangkatService.GetDaftar())
            {
                comboPerangkat.Items.Add($"{p.Id} | {p.Nama} | {p.Daya}W");
            }
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

            var parts = comboPerangkat.SelectedItem.ToString().Split('|', 3);
            string nama = parts[1].Trim();
            int daya = int.Parse(Regex.Match(parts[2], @"\d+").Value);

            var device = new Device
            {
                Name = nama,
                PowerInWatts = daya
            };

            var jadwal = JadwalService.GetDaftar()
                .FirstOrDefault(j => j.NamaPerangkat.Trim()
                    .Equals(nama, StringComparison.OrdinalIgnoreCase));

            if (jadwal == null)
            {
                MessageBox.Show("Jadwal untuk perangkat ini belum tersedia.");
                return;
            }

            var schedule = new DeviceSchedule
            {
                DeviceName = jadwal.NamaPerangkat,
                StartTime = DateTime.Today.Add(jadwal.JamMulai),
                EndTime = DateTime.Today.Add(jadwal.JamSelesai)
            };

            if (schedule.EndTime <= schedule.StartTime)
                schedule.EndTime = schedule.EndTime.AddDays(1);

            try
            {
                manager.AddConsumption(device, schedule);
                RefreshDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Terjadi kesalahan saat menambahkan konsumsi.");
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtPricePerKWh.Text, out double newPrice))
            {
                manager.UpdatePricePerKWh(newPrice);
                MessageBox.Show("Harga per kWh berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Masukkan harga per kWh yang valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void KonsumsiPage_Load(object sender, EventArgs e)
        {
        }

        private void comboPerangkat_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
