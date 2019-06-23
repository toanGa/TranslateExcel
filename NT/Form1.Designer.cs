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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(321, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Location = new System.Drawing.Point(487, 33);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDebug.Size = new System.Drawing.Size(813, 391);
            this.textBoxDebug.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(40, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // textBoxRow
            // 
            this.textBoxRow.Location = new System.Drawing.Point(40, 124);
            this.textBoxRow.Name = "textBoxRow";
            this.textBoxRow.Size = new System.Drawing.Size(66, 22);
            this.textBoxRow.TabIndex = 3;
            // 
            // textBoxCol
            // 
            this.textBoxCol.Location = new System.Drawing.Point(115, 124);
            this.textBoxCol.Name = "textBoxCol";
            this.textBoxCol.Size = new System.Drawing.Size(66, 22);
            this.textBoxCol.TabIndex = 4;
            // 
            // comboBoxLangSrc
            // 
            this.comboBoxLangSrc.FormattingEnabled = true;
            this.comboBoxLangSrc.Location = new System.Drawing.Point(40, 195);
            this.comboBoxLangSrc.Name = "comboBoxLangSrc";
            this.comboBoxLangSrc.Size = new System.Drawing.Size(141, 24);
            this.comboBoxLangSrc.TabIndex = 5;
            // 
            // comboBoxLangDst
            // 
            this.comboBoxLangDst.FormattingEnabled = true;
            this.comboBoxLangDst.Location = new System.Drawing.Point(220, 195);
            this.comboBoxLangDst.Name = "comboBoxLangDst";
            this.comboBoxLangDst.Size = new System.Drawing.Size(141, 24);
            this.comboBoxLangDst.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 436);
            this.Controls.Add(this.comboBoxLangDst);
            this.Controls.Add(this.comboBoxLangSrc);
            this.Controls.Add(this.textBoxCol);
            this.Controls.Add(this.textBoxRow);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.button1);
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
    }
}

