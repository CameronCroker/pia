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
    public partial class Form6 : Form
    {
        int save = 0;
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
            string date ="Date: " + localDate.ToShortDateString();
            string Time = "Time: " + localDate.ToShortTimeString();
            string Location = "Location: " + textBox2.Text;
            string staffname = "Staff Name: " + textBox3.Text;
            List<string> outputs = Interface1.display();
            string disp;
            textBox1.Text = date + Environment.NewLine + Time+ Environment.NewLine + Location + Environment.NewLine + staffname + Environment.NewLine + Environment.NewLine;
            disp = string.Join(Environment.NewLine, outputs.ToArray());
            textBox1.Text += disp + Environment.NewLine;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> Files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\", "*.txt")
                                     .Select(Path.GetFileName)
                                     .ToList<string>();
            string txtname;
            if (textBox1.Text != "")
            {
                txtname = Interface1.CurRepSend();
                if (Files.Contains(txtname + ".txt"))
                {
                    if (checkBox1.Text == "")
                    {
                        checkBox1.Checked = false;
                        checkBox1.Visible = false;
                    }
                    checkBox1.Visible = true;
                    checkBox1.Text = "Are you sure you want" + Environment.NewLine + "to overwrite the old Report:" + Environment.NewLine + txtname + ".txt";
                    button2.Text = "Confirm Save";
                    if (checkBox1.Text == "Are you sure you want" + Environment.NewLine + "to overwrite the old Report:" + Environment.NewLine + txtname + ".txt" && checkBox1.Checked == true)
                    {
                        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\" + txtname + ".txt", textBox1.Text);
                        Interface1.clear();
                        checkBox1.Text = "";
                        checkBox1.Checked = false;
                        checkBox1.Visible = false;
                        button2.Text = "Save";
                        textBox1.ReadOnly = true;
                        save++;


                    }
                }
                else
                {
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\PIA\Reports\" + txtname + ".txt", textBox1.Text);
                    textBox1.ReadOnly = true;
                    save++;
                }
            }
            else
                textBox1.Text = "Generate report first";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (save == 0)
            {
                Form5 frm5 = new Form5();
                this.Close();
                frm5.StartPosition = FormStartPosition.CenterScreen;
                frm5.Show();
            }
            else
            {
                Form4 frm4 = new Form4();
                this.Close();
                frm4.StartPosition = FormStartPosition.CenterScreen;
                frm4.Show();
            }
        }
            
        

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
        }
    }
}
