namespace _20220305027
{
    partial class MainForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox5 = new TextBox();
            groupBox2 = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            button5 = new Button();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(94, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(94, 132);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(94, 225);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(94, 268);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 31);
            textBox4.TabIndex = 3;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(0, 341);
            button1.Name = "button1";
            button1.Size = new Size(262, 34);
            button1.TabIndex = 4;
            button1.Text = "Add to System and Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(384, 62);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(736, 285);
            dataGridView1.TabIndex = 5;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(0, 55);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 6;
            button2.Text = "Sell";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(450, 563);
            button3.Name = "button3";
            button3.Size = new Size(287, 34);
            button3.TabIndex = 7;
            button3.Text = "Go to System Analysis";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(767, 563);
            button4.Name = "button4";
            button4.Size = new Size(200, 34);
            button4.TabIndex = 11;
            button4.Text = "Transaction History";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Electronics", "", "Clothing", "", "Stationery", "", "Food", "", "Other" });
            comboBox1.Location = new Point(94, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 33);
            comboBox1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(327, 409);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "New Product Entry";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 271);
            label6.Name = "label6";
            label6.Size = new Size(89, 25);
            label6.TabIndex = 15;
            label6.Text = "Min stock";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 228);
            label5.Name = "label5";
            label5.Size = new Size(49, 25);
            label5.TabIndex = 14;
            label5.Text = "Price";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 182);
            label4.Name = "label4";
            label4.Size = new Size(73, 25);
            label4.TabIndex = 13;
            label4.Text = "Cost ($)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 135);
            label3.Name = "label3";
            label3.Size = new Size(44, 25);
            label3.TabIndex = 12;
            label3.Text = "Unit";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 83);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 11;
            label2.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 33);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 10;
            label1.Text = "Category";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(94, 176);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 31);
            textBox5.TabIndex = 9;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericUpDown1);
            groupBox2.Controls.Add(button2);
            groupBox2.Location = new Point(3, 415);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(336, 210);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "SELL";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(120, 55);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(180, 31);
            numericUpDown1.TabIndex = 11;
            // 
            // button5
            // 
            button5.Location = new Point(384, 353);
            button5.Name = "button5";
            button5.Size = new Size(156, 34);
            button5.TabIndex = 12;
            button5.Text = "Delete Selected Item";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(970, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 13;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 622);
            Controls.Add(txtSearch);
            Controls.Add(button5);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private NumericUpDown numericUpDown1;
        private TextBox textBox5;
        private Label label1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button5;
        private TextBox txtSearch;
    }
}