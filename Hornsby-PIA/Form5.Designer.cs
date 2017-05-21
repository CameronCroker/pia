namespace Hornsby_PIA
{
    partial class Form5
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
            this.GenRep = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.DispOpt = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenRep
            // 
            this.GenRep.Location = new System.Drawing.Point(326, 34);
            this.GenRep.Name = "GenRep";
            this.GenRep.Size = new System.Drawing.Size(118, 23);
            this.GenRep.TabIndex = 14;
            this.GenRep.Text = "Generate Report";
            this.GenRep.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 150);
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(475, 480);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // DispOpt
            // 
            this.DispOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DispOpt.FormattingEnabled = true;
            this.DispOpt.Items.AddRange(new object[] {
            "Common Name",
            "Scientific Name",
            "Species",
            "Genus"});
            this.DispOpt.Location = new System.Drawing.Point(12, 63);
            this.DispOpt.Name = "DispOpt";
            this.DispOpt.Size = new System.Drawing.Size(278, 21);
            this.DispOpt.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(326, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Clear Text";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 642);
            this.Controls.Add(this.GenRep);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.DispOpt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GenRep;
        private System.Windows.Forms.RichTextBox textBox2;
        private System.Windows.Forms.ComboBox DispOpt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}