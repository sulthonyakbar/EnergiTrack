namespace WinFormsApp1
{
    partial class HomePage
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
            labelTitle = new Label();
            buttonPerangkat = new Button();
            buttonJadwal = new Button();
            buttonKonsumsi = new Button();
            buttonLaporan = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(224, 29);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(153, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Energi Track";
            labelTitle.Click += labelTitle_Click;
            // 
            // buttonPerangkat
            // 
            buttonPerangkat.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonPerangkat.Location = new Point(183, 81);
            buttonPerangkat.Name = "buttonPerangkat";
            buttonPerangkat.Size = new Size(103, 99);
            buttonPerangkat.TabIndex = 1;
            buttonPerangkat.Text = "Kelola Perangkat";
            buttonPerangkat.UseVisualStyleBackColor = true;
            buttonPerangkat.Click += buttonPerangkat_Click;
            // 
            // buttonJadwal
            // 
            buttonJadwal.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonJadwal.Location = new Point(315, 81);
            buttonJadwal.Name = "buttonJadwal";
            buttonJadwal.Size = new Size(103, 99);
            buttonJadwal.TabIndex = 2;
            buttonJadwal.Text = "Kelola Jadwal Pemakaian";
            buttonJadwal.UseVisualStyleBackColor = true;
            buttonJadwal.Click += buttonJadwal_Click;
            // 
            // buttonKonsumsi
            // 
            buttonKonsumsi.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKonsumsi.Location = new Point(183, 199);
            buttonKonsumsi.Name = "buttonKonsumsi";
            buttonKonsumsi.Size = new Size(103, 99);
            buttonKonsumsi.TabIndex = 3;
            buttonKonsumsi.Text = "Hitung Biaya Konsumsi";
            buttonKonsumsi.UseVisualStyleBackColor = true;
            // 
            // buttonLaporan
            // 
            buttonLaporan.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLaporan.Location = new Point(315, 199);
            buttonLaporan.Name = "buttonLaporan";
            buttonLaporan.Size = new Size(103, 99);
            buttonLaporan.TabIndex = 4;
            buttonLaporan.Text = "Laporan";
            buttonLaporan.UseVisualStyleBackColor = true;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(buttonLaporan);
            Controls.Add(buttonKonsumsi);
            Controls.Add(buttonJadwal);
            Controls.Add(buttonPerangkat);
            Controls.Add(labelTitle);
            Name = "HomePage";
            Text = "HomePage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Button buttonPerangkat;
        private Button buttonJadwal;
        private Button buttonKonsumsi;
        private Button buttonLaporan;
    }
}