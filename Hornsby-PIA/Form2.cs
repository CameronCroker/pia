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

        
     

        public Form2()
        {
            InitializeComponent();
            textBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            textBox1.Text = "Please Enter Plant's Scientific Name";           
            new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            
            panel1.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {

                textBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            }
        }

        private  void textBox1_Enter(object sender, EventArgs e)
        {

            if (textBox1.Text == "Please Enter Plant's Scientific Name")
                       {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
                            }

           

        }

        private  void panel1_Paint(object sender, PaintEventArgs e)
        {


            //  string searchold = textBox1.Text;
            //  string output;
            //  button1.Click += new EventHandler(this.button1_Click);
            //    while (this.IsAccessible)
            //   {
            //   output = string.Join(Environment.NewLine, Program.sqlConnect.search(textBox1.Text).ToArray());               


            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            string drawString = "Sample Text";
            System.Drawing.Font drawFont = new System.Drawing.Font(
                "Arial", 16);
            System.Drawing.SolidBrush drawBrush = new
                System.Drawing.SolidBrush(System.Drawing.Color.Black);
            float x = 150.0f;
            float y = 50.0f;
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();




            //}

        }                                                                                                 

        public void Add_Text()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                string entry = "someentry";

                //Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", entry);
                try
                {
                    insertCommand.ExecuteReader();
                }
                catch (SqliteException error)
                {
                    
                }
                db.Close();               
            }


        }


    public List<String> Grab_Entries(string search)
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT Text_Entry from MyTable where name like "+ search, db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();
                }
                catch (SqliteException error)
                {
                    //Handle error
                    return entries;
                }
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }

            return entries;

        }


    }




}


  
       