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
        static Interface1()
        {
            Results = new List<string>();           
        }

        static List<string> Results { get; set; }
        static IEnumerable<string> Reports { get; set; }
        static string Name;


        static public SqlConnection myConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Comp348_PIA;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");



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

        public async Task<List<string>> simsearch(string SearchTerm, string Disp)
        {
            string SearchString = string.Empty;
            foreach (char c in SearchTerm)
            {
                if (c == '\'')
                    SearchString += "''";
                else
                    SearchString += c;
            }
            Console.WriteLine(SearchString);
            var results = new List<string>();
            SearchTerm = "'%" + SearchString + "%'";
            SqlDataReader myReader;
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "select * from plants join family on plants.familyid = family.familyID join Genus on plants.GenusID = genus.GenusID where family.Name like " + SearchTerm + " or GenusName like " + SearchTerm + " or SpeciesName like " + SearchTerm + " or ScientificName like " + SearchTerm + " or CommonName like " + SearchTerm;
            myCommand.CommandType = System.Data.CommandType.Text;
            myCommand.Connection = myConnection;
            myReader = await myCommand.ExecuteReaderAsync();
            while (myReader.Read())
            {

                if (Disp == "CommonName")
                {
                    if (myReader[Disp].ToString() == "")
                    {
                        results.Add(myReader["ScientificName"].ToString());
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
            string container = string.Empty;
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                if (count == 0 && i == 0 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
                    commandText += " ScientificName like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 0 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
                    commandText += " and ScientificName like '%" + container + "%'";
                    SearchTerm.RemoveAt(0);
                }
                if (count == 0 && i == 1 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
                    commandText += " CommonName like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 1 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
                    commandText += " and CommonName like '%" + container + "%'";
                    SearchTerm.RemoveAt(0);
                }
                if (count == 0 && i == 2 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
                    commandText += " family.Name like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 2 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
                    commandText += " and family.Name like '%" + container + "%'";
                    SearchTerm.RemoveAt(0);
                }
                if (count == 0 && i == 3 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
                    commandText += " FlowerColour like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 3 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
                    commandText += " and FlowerColour like '%" + container + "%'";
                    SearchTerm.RemoveAt(0);
                }

                if (count == 0 && i == 4 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
                    commandText += " GeneralType like '%" + container + "%'";
                    count++;
                    SearchTerm.RemoveAt(0);
                }
                else if (count > 0 && i == 4 && tipe[i] == 1)
                {
                    foreach (char c in SearchTerm.ElementAt(0))
                    {
                        if (c == '\'')
                            container += "''";
                        else
                            container += c;
                    }
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
                        results.Add(myReader["ScientificName"].ToString());
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

        static public void get(string result)
        {
            Results.Add(result);
        }

        static public List<string> send()
        {
            return Results;

        }

        static public void clear()
        {
            Results.Clear();
        }


        public static List<string> display()
        {

            List<string> dispop = new List<string>();
            dispop.Add("CommonName");
            dispop.Add("ScientificName");
            dispop.Add("SpeciesName");
            dispop.Add("GenusName");
            
            List<string> count = new List<string>();
            
            foreach (string R in Reports)
            {
                Console.WriteLine(R);
                foreach (string D in dispop)
                    count.Add(D + ": " + solosearch(R, D) );
                count.Add(Environment.NewLine + "-------------------" + Environment.NewLine);
            }
            return count;
        }


        public static string solosearch(string SearchTerm, string Disp)
        {
            string SearchString = string.Empty;
            foreach (char c in SearchTerm)
            {
                if (c == '\'')
                    SearchString += "''";
                else
                    SearchString += c;
            }
            var results = new List<string>();
            SearchTerm = "'%" + SearchString + "%'";
            SqlDataReader myReader;
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "select * from plants join family on plants.familyid = family.familyID join Genus on plants.GenusID = genus.GenusID where family.Name like " + SearchTerm + " or GenusName like " + SearchTerm + " or SpeciesName like " + SearchTerm + " or ScientificName like " + SearchTerm + " or CommonName like " + SearchTerm;
            myCommand.CommandType = System.Data.CommandType.Text;
            myCommand.Connection = myConnection;
            myReader = myCommand.ExecuteReader();
            myReader.Read();
            string result;

            if (Disp == "CommonName")
            {
                if (myReader[Disp].ToString() == "")
                {
                    
                    result = myReader["ScientificName"].ToString();
                    myReader.Close();
                    return result;
                }
                else
                {

                    result = myReader[Disp].ToString();
                    myReader.Close();
                    return result;
                }
            }
            else
            {

                result = myReader[Disp].ToString();
                myReader.Close();
                return result;
            }
        }

        static public void Repget(IEnumerable<string> result)
        {
            Reports = result;
        }

        static public object Repsend()
        {
            return Reports;
        }

        static public void CurrentReport (string name)
        {
            Name = name;
        }

        static public string CurRepSend()
        {
            return Name;
        }




    }
}    



