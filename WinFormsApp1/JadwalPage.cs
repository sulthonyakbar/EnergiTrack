using System;
using System.Windows.Forms;
using EnergiTrack.Service;
using EnergiTrack.Model;
using System.Linq;

namespace WinFormsApp1
{
    public partial class JadwalPage : Form
    {
        public JadwalPage()
        {
            InitializeComponent();
            comboAksi.DataSource = Enum.GetValues(typeof(Aksi));
            comboHari.Items.AddRange(new string[]
            {
              "Senin",
              "Selasa",
              "Rabu",
              "Kamis",
              "Jumat",
              "Sabtu",
              "Minggu"
            });
            LoadJadwal();
            LoadPerangkat();
        }
        private void LoadJadwal()
        {
            listBoxJadwal.Items.Clear();
            var daftar = JadwalService.GetDaftar();
            foreach (var j in daftar)
            {
                listBoxJadwal.Items.Add($"ID: {j.Id} | {j.NamaPerangkat} | {j.Hari} | {j.JamMulai}-{j.JamSelesai} | {j.Status}");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string nama = comboPerangkat.SelectedItem?.ToString();
            string hari = comboHari.SelectedItem?.ToString() ?? "";
            TimeSpan mulai = timePickerMulai.Value.TimeOfDay;
            TimeSpan selesai = timePickerSelesai.Value.TimeOfDay;

            var perangkat = PerangkatService.GetDaftar().FirstOrDefault(p => p.Nama == nama);

            if (perangkat == null)
            {
                MessageBox.Show("Pilih perangkat yang valid.");
                return;
            }

            try
            {
                JadwalService.TambahJadwal(perangkat.Nama, hari, mulai, selesai);
                LoadJadwal();
                btnReset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID tidak valid.");
                return;
            }

            if (comboPerangkat.SelectedItem == null)
            {
                MessageBox.Show("Pilih perangkat terlebih dahulu.");
                return;
            }

            if (comboHari.SelectedItem == null)
            {
                MessageBox.Show("Pilih hari terlebih dahulu.");
                return;
            }

            string nama = comboPerangkat.SelectedItem.ToString();
            string hari = comboHari.SelectedItem.ToString();
            TimeSpan mulai = timePickerMulai.Value.TimeOfDay;
            TimeSpan selesai = timePickerSelesai.Value.TimeOfDay;

            try
            {
                JadwalService.EditJadwal(id, nama, hari, mulai, selesai);
                LoadJadwal();
                btnReset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengedit jadwal: {ex.Message}");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                JadwalService.HapusJadwal(id);
                LoadJadwal();
            }
            else
            {
                MessageBox.Show("ID tidak valid.");
            }
        }

        private void btnUbahStatus_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                if (Enum.TryParse<Aksi>(comboAksi.SelectedItem.ToString(), out Aksi aksi))
                {
                    JadwalService.UbahStatus(id, aksi);
                    LoadJadwal();
                }
                else
                {
                    MessageBox.Show("Aksi tidak valid.");
                }
            }
            else
            {
                MessageBox.Show("ID tidak valid.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            comboPerangkat.SelectedIndex = -1;
            comboHari.SelectedIndex = -1;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }
        private void LoadPerangkat()
        {
            comboPerangkat.Items.Clear();
            var perangkatList = EnergiTrack.Service.PerangkatService.GetDaftar(); // Tambahkan GetDaftar() ke PerangkatService
            foreach (var p in perangkatList)
            {
                comboPerangkat.Items.Add(p.Nama);
            }
        }

        private void comboPerangkat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
