namespace WinFormsApp1
{
    partial class Form1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            listView1 = new ListView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();

            // label1 - Nama Perangkat
            label1.AutoSize = true;
            label1.Location = new Point(39, 94);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 0;
            label1.Text = "Nama Perangkat";

            // label2 - ID
            label2.AutoSize = true;
            label2.Location = new Point(133, 63);
            label2.Name = "label2";
            label2.Size = new Size(24, 20);
            label2.TabIndex = 1;
            label2.Text = "ID";

            // label3 - Daya Perangkat
            label3.AutoSize = true;
            label3.Location = new Point(45, 127);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 2;
            label3.Text = "Daya Perangkat";

            // textBox1 - ID
            textBox1.Location = new Point(191, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 3;

            // textBox2 - Nama Perangkat
            textBox2.Location = new Point(191, 94);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 4;

            // textBox3 - Daya Perangkat
            textBox3.Location = new Point(191, 127);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 5;

            // listView1
            listView1.Location = new Point(58, 185);
            listView1.Name = "listView1";
            listView1.Size = new Size(714, 147);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;

            // Kolom ListView
            listView1.Columns.Add("ID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Nama Perangkat", 250, HorizontalAlignment.Left);
            listView1.Columns.Add("Daya Perangkat", 150, HorizontalAlignment.Left);

            // button2 - Tambah
            button2.Location = new Point(80, 348);
            button2.Name = "button2";
            button2.Size = new Size(150, 29);
            button2.TabIndex = 11;
            button2.Text = "Tambah";
            button2.UseVisualStyleBackColor = true;

            // button3 - Edit
            button3.Location = new Point(298, 348);
            button3.Name = "button3";
            button3.Size = new Size(150, 29);
            button3.TabIndex = 12;
            button3.Text = "Edit";
            button3.UseVisualStyleBackColor = true;

            // button4 - Hapus
            button4.Location = new Point(532, 348);
            button4.Name = "button4";
            button4.Size = new Size(150, 29);
            button4.TabIndex = 13;
            button4.Text = "Hapus";
            button4.UseVisualStyleBackColor = true;

            // Form1
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listView1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form Perangkat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ListView listView1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
