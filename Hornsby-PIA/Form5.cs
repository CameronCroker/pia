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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            List<string> output = Interface1.send();
            string results;
            results = string.Join(Environment.NewLine, output.ToArray());
            textBox2.Text = results;




        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
