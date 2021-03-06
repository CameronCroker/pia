﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hornsby_PIA
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            string output = string.Join(Environment.NewLine, Interface1.send().ToArray());
            if (Interface1.send().Count <= 0)
                checkedListBox1.Items.Add("There are no search Results");
            else
            {
                foreach (string R in Interface1.send())
                    checkedListBox1.Items.Add(R);
            }
            checkBox1.Checked = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GenRepButton_Click(object sender, EventArgs e)
        {
            var texts = this.checkedListBox1.CheckedItems.Cast<object>()
                .Select<object, string>(x => this.checkedListBox1.GetItemText(x));
            if (!texts.Contains("There are no search Results"))
                Interface1.Repget(texts);

            Form7 frm7 = new Form7();
            frm7.StartPosition = FormStartPosition.CenterScreen;
            frm7.Show();
            this.Close();


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearBut_Click(object sender, EventArgs e)
        {
            if (checkBox1.Text == "")
            {
                checkBox1.Checked = false;
                checkBox1.Visible = false;
            }
            checkBox1.Visible = true;
            checkBox1.Text = "Are you sure you want" + Environment.NewLine + "to delete all your Results?";
            ClearBut.Text = "Confirm Clear";
            if (checkBox1.Text == "Are you sure you want" + Environment.NewLine + "to delete all your Results?" && checkBox1.Checked == true)
            {
                checkedListBox1.Items.Clear();
                Interface1.clear();
                checkBox1.Text = "";
                checkBox1.Checked = false;
                checkBox1.Visible = false;
                ClearBut.Text = "Clear Results";
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            this.Close();
            frm7.StartPosition = FormStartPosition.CenterScreen;
            frm7.Show();

        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            this.Close();
            frm7.StartPosition = FormStartPosition.CenterScreen;
            frm7.Show();
        }

        private void ClearBut_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Text == "")
            {
                checkBox1.Checked = false;
                checkBox1.Visible = false;
            }
            checkBox1.Visible = true;
            checkBox1.Text = "Are you sure you want" + Environment.NewLine + "to delete all your Results?";
            ClearBut.Text = "Confirm Clear";
            if (checkBox1.Text == "Are you sure you want" + Environment.NewLine + "to delete all your Results?" && checkBox1.Checked == true)
            {
                checkedListBox1.Items.Clear();
                Interface1.clear();
                checkBox1.Text = "";
                checkBox1.Checked = false;
                checkBox1.Visible = false;
                ClearBut.Text = "Clear Results";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

