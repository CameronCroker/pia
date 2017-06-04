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
            Dictionary<string,string> Search = new Dictionary<string, string>();
            int[] tipe = new int[6] { 0, 0, 0, 0, 0 , 0};
            
            if (SciName.Text != "") {
                tipe[0] = 1;
                Search.Add("ScientificName",SciName.Text);
                tipe[5] = 1;
            }
            if (ComName.Text != "")
            {
                tipe[1] = 1;
                Search.Add("CommonName",ComName.Text);
                tipe[5] = 1;
            }
            if (FamName.Text != "")
            {
                tipe[2] = 1;
                Search.Add("family.Name", FamName.Text);
                tipe[5] = 1;
            }
            if (Flowers.Text != "")
            {
                tipe[3] = 1;
                Search.Add("FlowerColour", Flowers.Text);
                tipe[5] = 1;
            }
            if (GenType.SelectedIndex > -1)
            {
                tipe[4] = 1;
                Search.Add("GeneralType", GenType.SelectedItem.ToString());
                tipe[5] = 1;
            }
                        
            if (tipe[5] != 0)
            {

                checkedListBox1.Items.Clear();
                List<string> results = Program.sqlConnect.AdvancedSearch(Search,tipe,disp);
                foreach (string o in results)
                checkedListBox1.Items.Add(o); 
                
            }


        }



        private void BackButton_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.StartPosition = FormStartPosition.CenterScreen;
            frm1.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                var texts = this.checkedListBox1.CheckedItems.Cast<object>()
                 .Select<object, string>(x => this.checkedListBox1.GetItemText(x));
                foreach (string r in texts)
                {
                    Interface1.get(r);
                }
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        
    }
}
