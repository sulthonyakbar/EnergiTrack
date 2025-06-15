using EnergiTrack.Domain;
using EnergiTrack.Service;
using EnergiTrack.Services;
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
    public partial class KategoriPage : Form
    {
        private CrudService<Category> categoryService = KategoriStore.CategoryStore;
        public KategoriPage()
        {
            InitializeComponent();
            InitializeListView();
            LoadData();
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }

        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("ID", 100);
            listView1.Columns.Add("Nama Kategori", 300);
        }
        private void LoadData()
        {
            listView1.Clear();
            listView1.Columns.Add("ID", 100);
            listView1.Columns.Add("Nama Kategori", 300);

            var categories = categoryService.GetAll();
            foreach (var cat in categories)
            {
                var row = new ListViewItem(cat.Id.ToString());
                row.SubItems.Add(cat.Name);
                listView1.Items.Add(row);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nama = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama kategori tidak boleh kosong.");
                return;
            }

            categoryService.Add(new Category { Name = nama });
            LoadData();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int id))
            {
                MessageBox.Show("ID tidak valid.");
                return;
            }

            string nama = textBox2.Text.Trim();
            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Nama kategori tidak boleh kosong.");
                return;
            }

            categoryService.Edit(id, new Category { Id = id, Name = nama });
            LoadData();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int id))
            {
                MessageBox.Show("ID tidak valid.");
                return;
            }

            categoryService.Delete(id);
            LoadData();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selected = listView1.SelectedItems[0];
                textBox1.Text = selected.SubItems[0].Text;
                textBox2.Text = selected.SubItems[1].Text;
            }
        }
    }
}
