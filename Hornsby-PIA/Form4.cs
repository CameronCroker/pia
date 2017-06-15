using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Hornsby_PIA;


namespace Hornsby_PIA
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            List<string> Files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\", "*.txt")
                                     .Select(Path.GetFileName)
                                     .ToList<string>();
            foreach(string r in Files)
            checkedListBox1.Items.Add(r);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.StartPosition = FormStartPosition.CenterScreen;
            frm1.Show();

        }


        private void Checklist1_Doubleclick(object sender, EventArgs e)
        {
            
            
        }


        private void CheckList1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count >= 1 && e.CurrentValue != CheckState.Checked)
            {
                e.NewValue = e.CurrentValue;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Enter Report Name" && textBox1.Text != "")
            {
                Interface1.CurrentReport(textBox1.Text);
                Form5 frm5 = new Form5();
                frm5.StartPosition = FormStartPosition.CenterScreen;
                frm5.Show();
                this.Close();
            }
           
            else
                textBox1.Text = "Enter Report Name";
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var texts = this.checkedListBox1.CheckedItems.Cast<object>()
                .Select<object, string>(x => this.checkedListBox1.GetItemText(x));

            if (checkBox1.Text == "")
            {
                checkBox1.Checked = false;
                checkBox1.Visible = false;
            }
            checkBox1.Visible = true;
            checkBox1.Text = "Are you sure you want" + Environment.NewLine + "to delete the selected" + Environment.NewLine + "report?";
            button2.Text = "Confirm Delete";
            if (checkBox1.Text == "Are you sure you want" + Environment.NewLine + "to delete the selected" + Environment.NewLine + "report?" && checkBox1.Checked == true)
            {
                button2.Text = "Delete";
                foreach (string r in texts)
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\" + r);                
                checkBox1.Text = "";
                checkBox1.Checked = false;
                checkBox1.Visible = false;
                
                checkedListBox1.Items.Clear();
                List<string> Files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\", "*.txt")
                                         .Select(Path.GetFileName)
                                         .ToList<string>();
                foreach (string r in Files)
                    checkedListBox1.Items.Add(r);

            }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var texts = this.checkedListBox1.CheckedItems.Cast<object>()
                .Select<object, string>(x => this.checkedListBox1.GetItemText(x));

            foreach (string r in texts)
            {
                Interface1.CurrentReportView(r);                
            }
            Form7 frm7 = new Form7();
            frm7.StartPosition = FormStartPosition.CenterScreen;
            frm7.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var texts = this.checkedListBox1.CheckedItems.Cast<object>()
                .Select<object, string>(x => this.checkedListBox1.GetItemText(x));

            foreach (string r in texts)
            {
                Interface1.CurrentReportView(r);
            }

            string text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\" + Interface1.CurRepViewSend());
            string Name = AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\" + Interface1.CurRepViewSend();
            Interface1.ReptoCSV(text, Name);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
