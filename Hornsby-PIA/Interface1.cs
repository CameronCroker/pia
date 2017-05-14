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



        public SqlConnection myConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Comp348_PIA;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True") ;
        


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

        public async Task<List<string>> simsearch(string SearchTerm , string Disp)
        {
            var results = new List<string>();            
            SearchTerm = "'%" + SearchTerm + "%'";
            SqlDataReader myReader;
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "select * from plants join family on plants.familyid = family.familyID join Genus on plants.GenusID = genus.GenusID where family.Name like "+ SearchTerm + " or GenusName like " + SearchTerm + " or SpeciesName like " + SearchTerm + " or ScientificName like " + SearchTerm + " or CommonName like " + SearchTerm;
            myCommand.CommandType = System.Data.CommandType.Text;
            myCommand.Connection = myConnection;
            myReader = await myCommand.ExecuteReaderAsync();
            while (myReader.Read())
            {                
                       
                if (Disp == "CommonName")
                {
                    if(myReader[Disp].ToString() == "")
                    {
                        results.Add(myReader["ScientificName"].ToString() + " \"No Common Name Found\"");
                    }
                    else
                        results.Add(myReader[Disp].ToString());
                }
                else
                    results.Add(myReader[Disp].ToString());
            }            
            myReader.Close();
            return results;
        }

        public List<string> adsearch(List<string> SearchTerm, int[] tipe, string Disp)
        {
            var results = new List<string>();
            string commandText = "select * from plants join family on plants.familyid = family.familyID join Genus on plants.GenusID = genus.GenusID join GeneralType on plants.GeneralTypeID = generaltype.GeneralTypeID where";
            string container;
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                if (count == 0 && i == 0 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " ScientificName like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 0 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " and ScientificName like '%" + container + "%'";
                    SearchTerm.RemoveAt(0);
                }
                if (count == 0 && i == 1 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " CommonName like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 1 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " and CommonName like '%" + container + "%'";
                    SearchTerm.RemoveAt(0);
                }
                if (count == 0 && i == 2 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " family.Name like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 2 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " and family.Name like '%" + container + "%'";
                    SearchTerm.RemoveAt(0);
                }
                if (count == 0 && i == 3 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " FlowerColour like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 3 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " and FlowerColour like '%" + container + "%'";
                    SearchTerm.RemoveAt(0);
                }

                if (count == 0 && i == 4 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " GeneralType like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 4 && tipe[i] == 1)
                {
                    container = SearchTerm.ElementAt(0);
                    commandText += " and GeneralType like '%" + container + "%'";
                    SearchTerm.RemoveAt(0);
                }
            }

                       
            SqlDataReader myReader;
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = commandText;
            myCommand.CommandType = System.Data.CommandType.Text;
            myCommand.Connection = myConnection;
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                if (Disp == "CommonName")
                {
                    if (myReader[Disp].ToString() == "")
                    {
                        results.Add(myReader["ScientificName"].ToString() + " \"No Common Name Found\"");
                    }
                    else
                        results.Add(myReader[Disp].ToString());
                }
                else
                    results.Add(myReader[Disp].ToString());
            }
            myReader.Close();
            return results;
        }
        

    }
}


