namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label labelTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Size = new System.Drawing.Size(350, 32);
            this.labelTitle.Text = "Energy Consumption Manager";

            this.dataGridView1.Location = new System.Drawing.Point(20, 60);
            this.dataGridView1.Size = new System.Drawing.Size(650, 300);
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.btnAdd.Location = new System.Drawing.Point(690, 60);
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.Text = "Tambah";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Location = new System.Drawing.Point(690, 110);
            this.btnEdit.Size = new System.Drawing.Size(120, 35);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnRemove.Location = new System.Drawing.Point(690, 160);
            this.btnRemove.Size = new System.Drawing.Size(120, 35);
            this.btnRemove.Text = "Hapus";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            this.btnCalculate.Location = new System.Drawing.Point(690, 210);
            this.btnCalculate.Size = new System.Drawing.Size(120, 35);
            this.btnCalculate.Text = "Hitung Total";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            this.ClientSize = new System.Drawing.Size(830, 400);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.labelTitle);
            this.Text = "Energy Consumption Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
