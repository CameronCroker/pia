using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Hornsby_PIA
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            textBox4.Text = File.ReadAllText(@"C:\Users\cameron\OneDrive\Documents\PIA\Reports\" + Interface1.CurRepViewSend());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Text == "")
            {
                checkBox1.Checked = false;
                checkBox1.Visible = false;
            }
            checkBox1.Visible = true;
            checkBox1.Text = "Are you sure you want" + Environment.NewLine + "to overwrite the old Report:" + Environment.NewLine + Interface1.CurRepViewSend();
            button2.Text = "Confirm Save";
            if (checkBox1.Text == "Are you sure you want" + Environment.NewLine + "to overwrite the old Report:" + Environment.NewLine + Interface1.CurRepViewSend() && checkBox1.Checked == true)
            {
                File.WriteAllText(@"C:\Users\cameron\OneDrive\Documents\PIA\Reports\" + Interface1.CurRepViewSend(), textBox4.Text);
                Interface1.clear();
                checkBox1.Text = "";
                checkBox1.Checked = false;
                checkBox1.Visible = false;
                button2.Text = "Save";
                textBox4.ReadOnly = true;       

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Close();
        }
    }
}
