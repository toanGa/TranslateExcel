namespace NT
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxRow = new System.Windows.Forms.TextBox();
            this.textBoxCol = new System.Windows.Forms.TextBox();
            this.comboBoxLangSrc = new System.Windows.Forms.ComboBox();
            this.comboBoxLangDst = new System.Windows.Forms.ComboBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 199);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(362, 53);
            this.textBoxDebug.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDebug.Size = new System.Drawing.Size(611, 318);
            this.textBoxDebug.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 91);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // textBoxRow
            // 
            this.textBoxRow.Location = new System.Drawing.Point(30, 125);
            this.textBoxRow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRow.Name = "textBoxRow";
            this.textBoxRow.Size = new System.Drawing.Size(50, 20);
            this.textBoxRow.TabIndex = 3;
            // 
            // textBoxCol
            // 
            this.textBoxCol.Location = new System.Drawing.Point(86, 125);
            this.textBoxCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCol.Name = "textBoxCol";
            this.textBoxCol.Size = new System.Drawing.Size(50, 20);
            this.textBoxCol.TabIndex = 4;
            // 
            // comboBoxLangSrc
            // 
            this.comboBoxLangSrc.FormattingEnabled = true;
            this.comboBoxLangSrc.Location = new System.Drawing.Point(30, 158);
            this.comboBoxLangSrc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxLangSrc.Name = "comboBoxLangSrc";
            this.comboBoxLangSrc.Size = new System.Drawing.Size(107, 21);
            this.comboBoxLangSrc.TabIndex = 5;
            // 
            // comboBoxLangDst
            // 
            this.comboBoxLangDst.FormattingEnabled = true;
            this.comboBoxLangDst.Location = new System.Drawing.Point(165, 158);
            this.comboBoxLangDst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxLangDst.Name = "comboBoxLangDst";
            this.comboBoxLangDst.Size = new System.Drawing.Size(107, 21);
            this.comboBoxLangDst.TabIndex = 6;
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(29, 13);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(429, 20);
            this.textBoxFileName.TabIndex = 7;
            this.textBoxFileName.Text = "Z:\\Tester team\\20190610_Testcase EVT - Copy 2.xlsx";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(30, 40);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(95, 32);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 413);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.comboBoxLangDst);
            this.Controls.Add(this.comboBoxLangSrc);
            this.Controls.Add(this.textBoxCol);
            this.Controls.Add(this.textBoxRow);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxRow;
        private System.Windows.Forms.TextBox textBoxCol;
        private System.Windows.Forms.ComboBox comboBoxLangSrc;
        private System.Windows.Forms.ComboBox comboBoxLangDst;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonStart;
    }
}

