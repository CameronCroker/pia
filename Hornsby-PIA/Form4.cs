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
            List<string> Files = Directory.GetFiles(@"C:\Users\cameron\OneDrive\Documents\PIA\Reports", "*.txt")
                                     .Select(Path.GetFileName)
                                     .ToList<string>();
            foreach(string r in Files)
            checkedListBox1.Items.Add(r);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            Interface1.CurrentReport(textBox1.Text);
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.SelectedItems.Clear();
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
            frm7.Show();
            this.Close();
        }
    }
}
