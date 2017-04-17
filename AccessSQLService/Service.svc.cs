using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AccessSQLService.Model;

namespace AccessSQLService
{
    public class Service1 : IService
    {
        public string SqlConStr = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\cameron\\Documents\\Visual Studio 2015\\Projects\\Sample\\C# and C++\\CppWindowsStoreAppAccessSQLServer\\Database\\Test.mdf\";Initial Catalog = Test; Integrated Security = True";

        public IList<Article> QueryArticle()
        {
            DataSet ds = new DataSet();
            using (SqlConnection sqlCon = new SqlConnection(SqlConStr))
            {
                try
                {
                    sqlCon.Open();
                    string sqlStr = "select Title, Text from TestTable";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlStr, sqlCon);
                    sqlDa.Fill(ds);
                }
                catch
                {
                    return null;
                }
                finally
                {
                    sqlCon.Close();
                }
            }

            List<Article> articleList = new List<Article>();
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                articleList.Add(new Article()
                {
                    Title = dr["Title"] as string,
                    Text = dr["Text"] as string
                });
            }

            return articleList;
        }
    }
}
