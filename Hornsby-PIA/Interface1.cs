using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;


namespace Hornsby_PIA
{
    class Interface1
    {



        public SqlConnection myConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Comp348_PIA;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        


        public void connect()
        {
            try
            {
                myConnection.Open();
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

          
           
        }

        public bool upload()
        {        
            
            SqlCommand Command = new SqlCommand(File.ReadAllText("C:\\Users\\cameron\\Download\\comp348_pia.sql"), myConnection);            



            Command.ExecuteNonQuery();

            return true;
        }

        public bool read()
        {
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from table",  myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader["Column1"].ToString());
                    Console.WriteLine(myReader["Column2"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return true;
        }

        public void endconnect()
        {
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public List<string> search(string SearchTerm)
        {
            var results = new List<string>();
            SearchTerm = "%" + SearchTerm + "%";
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select CommonName from plants join family on plants.familyid = family.familyID join Genus on plants.GenusID = genus.GenusID where family.Name like " + SearchTerm + "  or GenusName like " + SearchTerm + " or SpeciesName like " + SearchTerm, myConnection);
            myReader = myCommand.ExecuteReader();
            int i = 0;
            while (myReader.Read())
            {
                results[i] = myReader["CommonName"].ToString();
                Console.WriteLine(results[i].ToString());
            }

            return results;
        }
    }
}


