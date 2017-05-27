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
            string output = string.Join(Environment.NewLine, Interface1.send().ToArray());              
            foreach (string R in Interface1.send())
                checkedListBox1.Items.Add(R);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GenRepButton_Click(object sender, EventArgs e)
        {
            var texts = this.checkedListBox1.CheckedItems.Cast<object>()
                .Select<object,string>(x => this.checkedListBox1.GetItemText(x));            
            Interface1.Repget(texts);
            Form6 frm6 = new Form6();
            frm6.Show();

            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearBut_Click(object sender, EventArgs e)
        {
            Interface1.clear();
        }
    }
}
