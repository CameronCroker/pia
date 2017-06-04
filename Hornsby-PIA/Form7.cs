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
            try
            { 
                textBox4.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\" + Interface1.CurRepViewSend());
            }

            catch 
            {
                
            }
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
            button4.Visible = true;
            button5.Visible = true;
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
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\" + Interface1.CurRepViewSend(), textBox4.Text);
                Interface1.clear();
                checkBox1.Text = "";
                checkBox1.Checked = false;
                checkBox1.Visible = false;
                button2.Text = "Save";
                textBox4.ReadOnly = true;
                button4.Visible = false;
                button5.Visible = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            this.Close();
            frm4.StartPosition = FormStartPosition.CenterScreen;
            frm4.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.StartPosition = FormStartPosition.CenterScreen;
            frm8.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                List<string> outputs = Interface1.display();
                string disp = string.Join(Environment.NewLine, outputs.ToArray());
                textBox4.Text += Environment.NewLine + disp + Environment.NewLine;
            
        }
    }
}
