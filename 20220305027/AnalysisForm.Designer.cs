namespace _20220305027
{
    partial class AnalysisForm
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
            listBox1 = new ListBox();
            button1 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(998, 304);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 322);
            button1.Name = "button1";
            button1.Size = new Size(228, 34);
            button1.TabIndex = 1;
            button1.Text = "Start AI Analysis";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AnalysisForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 677);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "AnalysisForm";
            Text = "AnalysisForm";
            Load += AnalysisForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}