namespace WinFormsApp1
{
    partial class KonsumsiPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnRemove = new Button();
            btnCalculate = new Button();
            labelTitle = new Label();
            button1 = new Button();
            comboPerangkat = new ComboBox();
            label1 = new Label();
            labelDaya = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(20, 126);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(398, 206);
            dataGridView1.TabIndex = 0;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(435, 126);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(120, 35);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Hapus";
            btnRemove.Click += btnRemove_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(435, 177);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(120, 35);
            btnCalculate.TabIndex = 4;
            btnCalculate.Text = "Hitung Total";
            btnCalculate.Click += btnCalculate_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(133, 21);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(323, 25);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Energy Consumption Manager";
            // 
            // button1
            // 
            button1.Location = new Point(20, 10);
            button1.Name = "button1";
            button1.Size = new Size(57, 23);
            button1.TabIndex = 6;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboPerangkat
            // 
            comboPerangkat.FormattingEnabled = true;
            comboPerangkat.Location = new Point(146, 78);
            comboPerangkat.Name = "comboPerangkat";
            comboPerangkat.Size = new Size(121, 23);
            comboPerangkat.TabIndex = 7;
            comboPerangkat.SelectedIndexChanged += comboPerangkat_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 81);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 8;
            label1.Text = "Nama Perangkat";
            // 
            // labelDaya
            // 
            labelDaya.AutoSize = true;
            labelDaya.Location = new Point(282, 81);
            labelDaya.Name = "labelDaya";
            labelDaya.Size = new Size(38, 15);
            labelDaya.TabIndex = 9;
            labelDaya.Text = "label2";
            // 
            // KonsumsiPage
            // 
            ClientSize = new Size(584, 361);
            Controls.Add(labelDaya);
            Controls.Add(label1);
            Controls.Add(comboPerangkat);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btnRemove);
            Controls.Add(btnCalculate);
            Controls.Add(labelTitle);
            Name = "KonsumsiPage";
            Text = "Energy Consumption Manager";
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
        private Label labelDaya;
    }
}