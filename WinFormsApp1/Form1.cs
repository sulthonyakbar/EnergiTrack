using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EnergiTrack.Service;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        }
    }
}
