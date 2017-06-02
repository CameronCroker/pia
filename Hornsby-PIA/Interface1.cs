using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data.SQLite;
using System.Data;

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
        static string View;


        static private string dataSource = "data source="+GetSolutionDirectory()+"\\SQLiteDB.db";
        static public SQLiteConnection conn = new SQLiteConnection(dataSource);
        
        static public string GetSolutionDirectory()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
        }
        public void connect()
        {
            try
            {
                conn.Open();
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
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        static public DataTable RetrieveData(string SQLquery)
        {
            DataTable data = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(SQLquery, conn);
            da.Fill(data);
            return data;
        }
        static public List<string> DisplayResults(DataTable data, string displayOption)
        {
            List<string> results = new List<string>();
            foreach (DataRow row in data.Rows)
            {
                if (row.Field<string>(displayOption) == "")
                {
                    results.Add(row.Field<string>("ScientificName") + " No " + displayOption + " Found");
                }
                else
                    results.Add(row.Field<string>(displayOption));
            }
            foreach (string r in results)
            {
                Console.WriteLine(r);
            }
            return results;
        }

        public async Task<List<string>> SimpleSearch(string SearchTerm, string Disp)
        {
            var results = new List<string>();
            SearchTerm = Sanitize(SearchTerm);
            SearchTerm = "'%" + SearchTerm + "%'";
            string query = "SELECT family.Name, CommonName, ScientificName,SpeciesName, Genus.GenusName, FlowerColour FROM PLANTS JOIN FAMILY ON PLANTS.FAMILYID = FAMILY.FAMILYID JOIN GENUS ON PLANTS.GENUSID = GENUS.GENUSID WHERE FAMILY.NAME LIKE " + SearchTerm + " OR GenusName LIKE " + SearchTerm + " OR SpeciesName LIKE " + SearchTerm + " OR ScientificName LIKE " + SearchTerm + " OR CommonName LIKE " + SearchTerm ;
            DataTable data = RetrieveData(query);
            results = DisplayResults(data, Disp);
            return results;
        }
        
        public List<string> AdvancedSearch(Dictionary<string,string> SearchTerm, int[] tipe, string Disp)
        {
            var results = new List<string>();
            string commandText = "select * from plants join family on plants.familyid = family.familyID join Genus on plants.GenusID = genus.GenusID join GeneralType on plants.GeneralTypeID = generaltype.GeneralTypeID where ";

            foreach (string ke in SearchTerm.Keys)
            {
                commandText += ke + " Like '%" + Sanitize(SearchTerm[ke])+"%'";
                if (ke != SearchTerm.Last().Key)
                {
                    commandText += " AND ";
                }
            }
            
            DataTable data = RetrieveData(commandText);
            results = DisplayResults(data, Disp);
            return results;
        }

        static public void get(string result)
        {
            if(!Results.Contains(result))
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
                foreach (string D in dispop)
                    count.Add(D + ": " + solosearch(R, D) );
                count.Add(Environment.NewLine + "-------------------" + Environment.NewLine);
            }
            return count;
        }
        static public string solosearch(string SearchTerm, string Disp)
        {
            SearchTerm = "'%" + Sanitize(SearchTerm) + "%'";

            string query = "SELECT * FROM PLANTS JOIN FAMILY ON PLANTS.FAMILYID = FAMILY.FAMILYID JOIN GENUS ON PLANTS.GENUSID = GENUS.GENUSID WHERE FAMILY.NAME LIKE " + SearchTerm + " OR GENUSNAME LIKE " + SearchTerm + " OR SPECIESNAME LIKE " + SearchTerm + " OR SCIENTIFICNAME LIKE " + SearchTerm + " OR COMMONNAME LIKE " + SearchTerm;
            List<string> result;
            DataTable data = RetrieveData(query);
            result = DisplayResults(data, Disp);

            return result.First().ToString();
        }
        static public string Sanitize(string s)
        {
            string admitted = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 ";
            StringBuilder output = new StringBuilder(s.Length);

            foreach (char c in s)
            {
                foreach (char adm in admitted)
                {
                    if (c == adm)
                    {
                        output.Append(c);
                    }
                }
            }

            return output.ToString();
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

        static public void CurrentReportView(string name)
        {
            View = name;
        }

        static public string CurRepViewSend()
        {
            return View;
        }





    }
}    



