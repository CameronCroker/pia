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

        public async Task<List<string>> simsearch(string SearchTerm)
        {
            var results = new List<string>();
            SearchTerm = "'%" + SearchTerm + "%'";
            SqlDataReader myReader;
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "select CommonName from plants join family on plants.familyid = family.familyID join Genus on plants.GenusID = genus.GenusID where family.Name like "+ SearchTerm + " or GenusName like " + SearchTerm + " or SpeciesName like " + SearchTerm;
            myCommand.CommandType = System.Data.CommandType.Text;
            myCommand.Connection = myConnection;
            myReader = await myCommand.ExecuteReaderAsync();
            while (myReader.Read())
            {                
                results.Add(myReader["CommonName"].ToString());                              
            }            
            myReader.Close();
            return results;
        }

        public async Task<List<string>> adsearch(string SearchTerm, string tipe)
        {
            var results = new List<string>();
            SearchTerm = "'%" + SearchTerm + "%'";
            SqlDataReader myReader;
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "select CommonName from plants join family on plants.familyid = family.familyID join Genus on plants.GenusID = genus.GenusID where family.Name like " + SearchTerm + " or GenusName like " + SearchTerm + " or SpeciesName like " + SearchTerm;
            myCommand.CommandType = System.Data.CommandType.Text;
            myCommand.Connection = myConnection;
            myReader = await myCommand.ExecuteReaderAsync();
            while (myReader.Read())
            {
                results.Add(myReader["CommonName"].ToString());
            }
            myReader.Close();
            return results;
        }







    }
}


