using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hornsby_PIA
{
    class Interface1
    {

        SqlConnection myConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\cameron\\Documents\\Visual Studio 2015\\Projects\\Sample\\C# and C++\\CppWindowsStoreAppAccessSQLServer\\Database\\Test.mdf\";Initial Catalog = Test; Integrated Security = True");


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

        public void upload()
        {
            SqlCommand myCommand = new SqlCommand("INSERT INTO table (Column1, Column2) " +
                                     "Values ('string', 1)", myConnection);

            myCommand.ExecuteNonQuery();
        }

        public void read()
        {
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from table",
                                                         myConnection);
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
    }
}


