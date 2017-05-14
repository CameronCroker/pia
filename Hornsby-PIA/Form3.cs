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


namespace Hornsby_PIA
{
    public partial class Form3 : Form
    {
        public string disp = "CommonName";

        public Form3()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            List<string> Search = new List<string>();
            int[] tipe = new int[6] { 0, 0, 0, 0, 0 , 0};
            
            if (SciName.Text != "") {
                tipe[0] = 1;
                Search.Add(SciName.Text);
                tipe[5] = 1;
            }
            if (ComName.Text != "")
            {
                tipe[1] = 1;
                Search.Add(ComName.Text);
                tipe[5] = 1;
            }
            if (FamName.Text != "")
            {
                tipe[2] = 1;
                Search.Add(FamName.Text);
                tipe[5] = 1;
            }
            if (Flowers.Text != "")
            {
                tipe[3] = 1;
                Search.Add(Flowers.Text);
                tipe[5] = 1;
            }
            if (Type.Text != "")
            {
                tipe[4] = 1;
                Search.Add(Type.Text);
                tipe[5] = 1;
            }
                        
            if (tipe[5] != 0)
            {                
                    
                    string output;
                    List<string> results = Program.sqlConnect.adsearch(Search,tipe,disp);
                    output = string.Join(Environment.NewLine, results.ToArray());
                    Results.Text = output;
                
            }


        }



        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        }
    }
}
