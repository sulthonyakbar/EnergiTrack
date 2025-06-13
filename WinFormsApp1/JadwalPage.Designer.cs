namespace WinFormsApp1
{
    partial class JadwalPage
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
            label1 = new Label();
            label3 = new Label();
            comboAksi = new ComboBox();
            txtNama = new TextBox();
            label4 = new Label();
            label5 = new Label();
            timePickerMulai = new DateTimePicker();
            label6 = new Label();
            timePickerSelesai = new DateTimePicker();
            listBoxJadwal = new ListBox();
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapus = new Button();
            btnUbahStatus = new Button();
            label2 = new Label();
            txtId = new TextBox();
            btnReset = new Button();
            comboHari = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(137, 9);
            label1.Name = "label1";
            label1.Size = new Size(291, 23);
            label1.TabIndex = 0;
            label1.Text = "Jadwal Pemakaian Perangkat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F);
            label3.Location = new Point(23, 104);
            label3.Name = "label3";
            label3.Size = new Size(108, 17);
            label3.TabIndex = 3;
            label3.Text = "Nama Perangkat";
            label3.Click += label3_Click;
            // 
            // comboAksi
            // 
            comboAksi.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboAksi.FormattingEnabled = true;
            comboAksi.Location = new Point(23, 182);
            comboAksi.Name = "comboAksi";
            comboAksi.Size = new Size(80, 25);
            comboAksi.TabIndex = 4;
            // 
            // txtNama
            // 
            txtNama.Font = new Font("Century Gothic", 9F);
            txtNama.Location = new Point(137, 102);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(172, 22);
            txtNama.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F);
            label4.Location = new Point(23, 139);
            label4.Name = "label4";
            label4.Size = new Size(31, 17);
            label4.TabIndex = 6;
            label4.Text = "Hari";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F);
            label5.Location = new Point(362, 71);
            label5.Name = "label5";
            label5.Size = new Size(68, 17);
            label5.TabIndex = 8;
            label5.Text = "Jam Mulai";
            // 
            // timePickerMulai
            // 
            timePickerMulai.Font = new Font("Century Gothic", 9F);
            timePickerMulai.Format = DateTimePickerFormat.Time;
            timePickerMulai.Location = new Point(441, 68);
            timePickerMulai.Name = "timePickerMulai";
            timePickerMulai.ShowUpDown = true;
            timePickerMulai.Size = new Size(102, 22);
            timePickerMulai.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F);
            label6.Location = new Point(362, 109);
            label6.Name = "label6";
            label6.Size = new Size(78, 17);
            label6.TabIndex = 10;
            label6.Text = "Jam Selesai";
            // 
            // timePickerSelesai
            // 
            timePickerSelesai.Font = new Font("Century Gothic", 9F);
            timePickerSelesai.Format = DateTimePickerFormat.Time;
            timePickerSelesai.Location = new Point(441, 104);
            timePickerSelesai.Name = "timePickerSelesai";
            timePickerSelesai.ShowUpDown = true;
            timePickerSelesai.Size = new Size(102, 22);
            timePickerSelesai.TabIndex = 11;
            // 
            // listBoxJadwal
            // 
            listBoxJadwal.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxJadwal.FormattingEnabled = true;
            listBoxJadwal.ItemHeight = 17;
            listBoxJadwal.Location = new Point(23, 229);
            listBoxJadwal.Name = "listBoxJadwal";
            listBoxJadwal.Size = new Size(524, 106);
            listBoxJadwal.TabIndex = 12;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.Transparent;
            btnTambah.Font = new Font("Century Gothic", 9F);
            btnTambah.Location = new Point(225, 182);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(75, 23);
            btnTambah.TabIndex = 13;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Transparent;
            btnEdit.Font = new Font("Century Gothic", 9F);
            btnEdit.Location = new Point(306, 182);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 14;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.Transparent;
            btnHapus.Font = new Font("Century Gothic", 9F);
            btnHapus.Location = new Point(387, 182);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(75, 23);
            btnHapus.TabIndex = 15;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnUbahStatus
            // 
            btnUbahStatus.BackColor = Color.Transparent;
            btnUbahStatus.Font = new Font("Century Gothic", 9F);
            btnUbahStatus.Location = new Point(109, 182);
            btnUbahStatus.Name = "btnUbahStatus";
            btnUbahStatus.Size = new Size(91, 23);
            btnUbahStatus.TabIndex = 16;
            btnUbahStatus.Text = "Ubah Status";
            btnUbahStatus.UseVisualStyleBackColor = false;
            btnUbahStatus.Click += btnUbahStatus_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 9F);
            label2.Location = new Point(23, 71);
            label2.Name = "label2";
            label2.Size = new Size(19, 17);
            label2.TabIndex = 1;
            label2.Text = "Id";
            label2.Click += label2_Click;
            // 
            // txtId
            // 
            txtId.Font = new Font("Century Gothic", 9F);
            txtId.Location = new Point(137, 68);
            txtId.Name = "txtId";
            txtId.Size = new Size(46, 22);
            txtId.TabIndex = 2;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Transparent;
            btnReset.Font = new Font("Century Gothic", 9F);
            btnReset.Location = new Point(468, 182);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 17;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // comboHari
            // 
            comboHari.Font = new Font("Century Gothic", 9F);
            comboHari.FormattingEnabled = true;
            comboHari.Location = new Point(137, 137);
            comboHari.Name = "comboHari";
            comboHari.Size = new Size(121, 25);
            comboHari.TabIndex = 18;
            // 
            // JadwalPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 357);
            Controls.Add(comboHari);
            Controls.Add(btnReset);
            Controls.Add(btnUbahStatus);
            Controls.Add(btnHapus);
            Controls.Add(btnEdit);
            Controls.Add(btnTambah);
            Controls.Add(listBoxJadwal);
            Controls.Add(timePickerSelesai);
            Controls.Add(label6);
            Controls.Add(timePickerMulai);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtNama);
            Controls.Add(comboAksi);
            Controls.Add(label3);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "JadwalPage";
            Text = "JadwalPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private ComboBox comboAksi;
        private TextBox txtNama;
        private Label label4;
        private Label label5;
        private DateTimePicker timePickerMulai;
        private Label label6;
        private DateTimePicker timePickerSelesai;
        private ListBox listBoxJadwal;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnHapus;
        private Button btnUbahStatus;
        private Label label2;
        private TextBox txtId;
        private Button btnReset;
        private ComboBox comboHari;
    }
}