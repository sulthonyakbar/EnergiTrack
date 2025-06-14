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
            string nama = txtNama.Text;
            string hari = comboHari.SelectedItem?.ToString() ?? "";
            TimeSpan mulai = timePickerMulai.Value.TimeOfDay;
            TimeSpan selesai = timePickerSelesai.Value.TimeOfDay;

            try
            {
                JadwalService.TambahJadwal(nama, hari, mulai, selesai);
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
            if (int.TryParse(txtId.Text, out int id))
            {
                string nama = txtNama.Text;
                string hari = comboHari.SelectedItem?.ToString() ?? "";
                TimeSpan mulai = timePickerMulai.Value.TimeOfDay;
                TimeSpan selesai = timePickerSelesai.Value.TimeOfDay;

                JadwalService.EditJadwal(id, nama, hari, mulai, selesai);
                LoadJadwal();
                btnReset_Click(null, null);
            }
            else
            {
                MessageBox.Show("ID tidak valid.");
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
            txtNama.Text = "";
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
    }
}
