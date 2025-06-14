using EnergiTrack.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class PerangkatPage : Form
    {
        public PerangkatPage()
        {
            InitializeComponent();
            InisialisasiListView();

            // Event Handler
            button2.Click += buttonTambah_Click;  // Tambah
            button3.Click += buttonEdit_Click;    // Edit
            button4.Click += buttonHapus_Click;   // Hapus
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;

            LoadKategori(); // Load kategori saat form dibuka
            RefreshListView();
        }

        private void InisialisasiListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Nama Perangkat", 150);
            listView1.Columns.Add("Daya (Watt)", 100);
            listView1.Columns.Add("Kategori", 100);
        }

        private void RefreshListView()
        {
            listView1.Items.Clear();
            foreach (var perangkat in GetAllPerangkat())
            {
                var item = new ListViewItem(perangkat.Id.ToString());
                item.SubItems.Add(perangkat.Nama);
                item.SubItems.Add(perangkat.Daya.ToString());
                item.SubItems.Add(perangkat.KategoriNama);
                listView1.Items.Add(item);
            }
        }
        private void LoadKategori()
        {
            comboKategori.Items.Clear();
            foreach (var cat in KategoriStore.CategoryStore.GetAll())
            {
                comboKategori.Items.Add($"{cat.Id} | {cat.Name}");
            }
        }

        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboKategori.SelectedIndex = -1;
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            string nama = textBox2.Text.Trim();
            string dayaText = textBox3.Text.Trim();

            if (comboKategori.SelectedItem == null)
            {
                MessageBox.Show("Pilih kategori terlebih dahulu.");
                return;
            }

            if (!int.TryParse(dayaText, out int daya) || daya <= 0)
            {
                MessageBox.Show("Daya harus berupa angka > 0.");
                return;
            }

            // parsing "ID | Nama"
            var parts = comboKategori.SelectedItem.ToString().Split('|', 2);
            int katId = int.Parse(parts[0].Trim());
            string katNm = parts[1].Trim();

            try
            {
                PerangkatService.TambahPerangkat(nama, daya, katId, katNm);   // ← gunakan ctor baru
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
            if (listView1.SelectedItems.Count == 0) { MessageBox.Show("Pilih data."); return; }
            if (!int.TryParse(listView1.SelectedItems[0].SubItems[0].Text, out int id)) return;

            string namaBaru = textBox2.Text.Trim();
            if (!int.TryParse(textBox3.Text.Trim(), out int dayaBaru) || dayaBaru <= 0)
            {
                MessageBox.Show("Daya harus angka > 0."); return;
            }

            if (comboKategori.SelectedItem == null) { MessageBox.Show("Pilih kategori."); return; }
            var parts = comboKategori.SelectedItem.ToString().Split('|', 2);
            int katId = int.Parse(parts[0].Trim());
            string katNm = parts[1].Trim();

            try
            {
                PerangkatService.EditPerangkat(id, namaBaru, dayaBaru, katId, katNm);
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

                string kategori = item.SubItems[3].Text;

                // Cari dan pilih kategori di combo box
                for (int i = 0; i < comboKategori.Items.Count; i++)
                {
                    if (comboKategori.Items[i].ToString().EndsWith(kategori))
                    {
                        comboKategori.SelectedIndex = i;
                        break;
                    }
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
