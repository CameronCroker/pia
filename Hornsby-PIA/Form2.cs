using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xaml;
using System.Windows;
using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;
using System.Threading.Tasks;
using System.Threading;
using Hornsby_PIA;
using System.Data.SqlClient;

namespace Hornsby_PIA
{
    public partial class Form2 : Form
    {
        public string disp = "CommonName";

        public Form2()
        {
            InitializeComponent();
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;

        }
        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox2.Text = "";
            else
            {                
                string searchold = textBox1.Text;
                string output;
                List<string> results = await Program.sqlConnect.simsearch(textBox1.Text, disp);
                output = string.Join(Environment.NewLine, results.ToArray());
                textBox2.Text = output;
            }
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Please Enter Plant's Scientific Name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void DispOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DispOpt.SelectedIndex.Equals(0))
            {
                disp = "CommonName";
            }
            if (DispOpt.SelectedIndex.Equals(1))
            {
                disp = "ScientificName";
            }
            if (DispOpt.SelectedIndex.Equals(2))
            {
                disp = "SpeciesName";
            }
            if (DispOpt.SelectedIndex.Equals(3))
            {
                disp = "GenusName";
            }
            textBox1_TextChanged(sender,e);
        }
    }




}


  
       