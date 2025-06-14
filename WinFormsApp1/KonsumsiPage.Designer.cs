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
            btnAdd = new Button();
            btnEdit = new Button();
            btnRemove = new Button();
            btnCalculate = new Button();
            labelTitle = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(20, 60);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(398, 272);
            dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(435, 83);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 35);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Tambah";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(435, 139);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 35);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(435, 197);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(120, 35);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Hapus";
            btnRemove.Click += btnRemove_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(435, 258);
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
            // KonsumsiPage
            // 
            ClientSize = new Size(584, 361);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
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
        private Button btnAdd;
        private Button btnEdit;
        private Button btnRemove;
        private Button btnCalculate;
        private Label labelTitle;
        private Button button1;
    }
}