namespace WinFormsApp1
{
    partial class KonsumsiPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnRemove = new Button();
            btnCalculate = new Button();
            labelTitle = new Label();
            button1 = new Button();
            comboPerangkat = new ComboBox();
            label1 = new Label();
            labelConfig = new Label();
            txtPricePerKWh = new TextBox();
            btnSaveConfig = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(20, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(505, 327);
            dataGridView1.TabIndex = 0;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(535, 167);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(120, 35);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Hapus";
            btnRemove.Click += btnRemove_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(535, 208);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(120, 35);
            btnCalculate.TabIndex = 4;
            btnCalculate.Text = "Hitung Total";
            btnCalculate.Click += btnCalculate_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold);
            labelTitle.Location = new Point(96, 26);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(455, 32);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "Konsumsi Energi Kelola Perangkat";
            // 
            // button1
            // 
            button1.Location = new Point(20, 10);
            button1.Name = "button1";
            button1.Size = new Size(57, 31);
            button1.TabIndex = 5;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboPerangkat
            // 
            comboPerangkat.FormattingEnabled = true;
            comboPerangkat.Location = new Point(171, 78);
            comboPerangkat.Name = "comboPerangkat";
            comboPerangkat.Size = new Size(137, 28);
            comboPerangkat.TabIndex = 4;
            comboPerangkat.SelectedIndexChanged += comboPerangkat_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 81);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 3;
            label1.Text = "Nama Perangkat";
            // 
            // labelConfig
            // 
            labelConfig.AutoSize = true;
            labelConfig.Location = new Point(324, 81);
            labelConfig.Name = "labelConfig";
            labelConfig.Size = new Size(109, 20);
            labelConfig.TabIndex = 0;
            labelConfig.Text = "Harga per kWh";
            // 
            // txtPricePerKWh
            // 
            txtPricePerKWh.Location = new Point(446, 78);
            txtPricePerKWh.Name = "txtPricePerKWh";
            txtPricePerKWh.Size = new Size(79, 27);
            txtPricePerKWh.TabIndex = 1;
            // 
            // btnSaveConfig
            // 
            btnSaveConfig.Location = new Point(535, 126);
            btnSaveConfig.Name = "btnSaveConfig";
            btnSaveConfig.Size = new Size(120, 35);
            btnSaveConfig.TabIndex = 2;
            btnSaveConfig.Text = "Simpan";
            btnSaveConfig.Click += btnSaveConfig_Click;
            // 
            // button2
            // 
            button2.Location = new Point(535, 208);
            button2.Name = "button2";
            button2.Size = new Size(120, 35);
            button2.TabIndex = 4;
            button2.Text = "Hitung Total";
            button2.Click += btnCalculate_Click;
            // 
            // button3
            // 
            button3.Location = new Point(535, 167);
            button3.Name = "button3";
            button3.Size = new Size(120, 35);
            button3.TabIndex = 3;
            button3.Text = "Hapus";
            button3.Click += btnRemove_Click;
            // 
            // button4
            // 
            button4.Location = new Point(535, 126);
            button4.Name = "button4";
            button4.Size = new Size(120, 35);
            button4.TabIndex = 2;
            button4.Text = "Simpan";
            button4.Click += btnSaveConfig_Click;
            // 
            // KonsumsiPage
            // 
            ClientSize = new Size(667, 481);
            Controls.Add(labelConfig);
            Controls.Add(txtPricePerKWh);
            Controls.Add(button4);
            Controls.Add(btnSaveConfig);
            Controls.Add(label1);
            Controls.Add(comboPerangkat);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(btnRemove);
            Controls.Add(btnCalculate);
            Controls.Add(labelTitle);
            Name = "KonsumsiPage";
            Text = "Kelola Konsumsi Energi Perangkat";
            Load += KonsumsiPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnRemove;
        private Button btnCalculate;
        private Label labelTitle;
        private Button button1;
        private ComboBox comboPerangkat;
        private Label label1;
        private Label labelConfig;
        private TextBox txtPricePerKWh;
        private Button btnSaveConfig;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
