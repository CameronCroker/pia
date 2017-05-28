using System;
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
    public partial class Form6 : Form
    {
        public Form6()
        {
           
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime localDate = DateTime.Now;
            string date = localDate.ToString();
            string Location = textBox2.Text;
            string staffname = textBox3.Text;
            List<string> outputs = Interface1.display();
            string disp;
            textBox1.Text = date + Environment.NewLine + Location + Environment.NewLine + staffname + Environment.NewLine;
            disp = string.Join(Environment.NewLine, outputs.ToArray());
            textBox1.Text += disp + Environment.NewLine;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string txtname;
            if (textBox1.Text != "")
            {
                txtname = Interface1.CurRepSend();
                System.IO.File.WriteAllText(@"C:\Users\cameron\OneDrive\Documents\PIA\Reports\" + txtname + ".txt", textBox1.Text);
                this.Close();
            }
            else
                textBox1.Text = "Generate report first";
            
        }
    }
}
