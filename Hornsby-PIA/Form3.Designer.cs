namespace Hornsby_PIA
{
    partial class Form3
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SciName = new System.Windows.Forms.TextBox();
            this.ComName = new System.Windows.Forms.TextBox();
            this.FamName = new System.Windows.Forms.TextBox();
            this.Flowers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DispOpt = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.GenType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Hornsby_PIA.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(122, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 175);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // SciName
            // 
            this.SciName.Location = new System.Drawing.Point(30, 210);
            this.SciName.Name = "SciName";
            this.SciName.Size = new System.Drawing.Size(186, 20);
            this.SciName.TabIndex = 2;
            // 
            // ComName
            // 
            this.ComName.Location = new System.Drawing.Point(246, 210);
            this.ComName.Name = "ComName";
            this.ComName.Size = new System.Drawing.Size(186, 20);
            this.ComName.TabIndex = 3;
            // 
            // FamName
            // 
            this.FamName.Location = new System.Drawing.Point(30, 254);
            this.FamName.Name = "FamName";
            this.FamName.Size = new System.Drawing.Size(186, 20);
            this.FamName.TabIndex = 4;
            // 
            // Flowers
            // 
            this.Flowers.Location = new System.Drawing.Point(246, 254);
            this.Flowers.Name = "Flowers";
            this.Flowers.Size = new System.Drawing.Size(186, 20);
            this.Flowers.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Scentific Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Common Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Family Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Flower Options";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "General Types";
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(357, 484);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 13;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(30, 484);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 14;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
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
            this.DispOpt.Location = new System.Drawing.Point(246, 300);
            this.DispOpt.Name = "DispOpt";
            this.DispOpt.Size = new System.Drawing.Size(121, 21);
            this.DispOpt.TabIndex = 16;
            this.DispOpt.SelectedIndexChanged += new System.EventHandler(this.DispOpt_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Display Options";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(30, 339);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(389, 124);
            this.checkedListBox1.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Send to Reports";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenType
            // 
            this.GenType.FormattingEnabled = true;
            this.GenType.Items.AddRange(new object[] {
            "Herb",
            "Climber",
            "Fern",
            "Shrub",
            "Sedge",
            "Tree",
            "Rush",
            "Mistletoe",
            "Fern Ally",
            "Grass",
            "Orchid",
            "Vine",
            "Palm",
            "Cycad"});
            this.GenType.Location = new System.Drawing.Point(30, 300);
            this.GenType.Name = "GenType";
            this.GenType.Size = new System.Drawing.Size(121, 21);
            this.GenType.TabIndex = 20;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 519);
            this.Controls.Add(this.GenType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DispOpt);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Flowers);
            this.Controls.Add(this.FamName);
            this.Controls.Add(this.ComName);
            this.Controls.Add(this.SciName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form3";
            this.Text = "Advanced Search";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox SciName;
        private System.Windows.Forms.TextBox ComName;
        private System.Windows.Forms.TextBox FamName;
        private System.Windows.Forms.TextBox Flowers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ComboBox DispOpt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox GenType;
    }
}