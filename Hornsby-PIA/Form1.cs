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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports";
            this.StartPosition = FormStartPosition.CenterScreen;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void button1_Click(object sender, EventArgs e) { 
        
            Form2 frm2 = new Form2();
            this.Hide();
            frm2.StartPosition = FormStartPosition.CenterScreen;
            frm2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Hide();
            frm3.StartPosition = FormStartPosition.CenterScreen;
            frm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            this.Hide();
            frm4.StartPosition = FormStartPosition.CenterScreen;
            frm4.Show();
        }
    }
}
