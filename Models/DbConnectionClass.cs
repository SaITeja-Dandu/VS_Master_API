using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;
namespace VS_Master_API.Models
{
    public class DbConnectionClass
    {
        public IConfiguration GetConfiBuild()
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return configBuilder.Build();
        }

        public DbConnectionClass() { }

        public string DbConnString()
        {
            var configuration = GetConfiBuild();
            var FinalConnstri = (configuration.GetSection("ConnectionStrings").GetSection("DBConnection").Value).ToString();
            return FinalConnstri;
            //  conn = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("DBConnection").Value);
        }
        //public string RetriveParticularColumns(string SqlQuery, Int16 ColNo)
        //{
        //    var Connstr = DbConnString();
        //    string functionReturnValue = "";

        //    SqlConnection conn = new SqlConnection(Connstr.ToString());
        //    SqlCommand cmd1 = new SqlCommand(SqlQuery, conn);
        //    SqlDataReader dr1;
        //    try
        //    {
        //        conn.Open();
        //        dr1 = cmd1.ExecuteReader();

        //        while ((dr1.Read()))
        //        {
        //            if (!dr1[ColNo].Equals(System.DBNull.Value))
        //            {
        //                functionReturnValue = dr1[ColNo].ToString();
        //            }
        //            else
        //            {
        //                functionReturnValue = "";
        //            }
        //        }
        //        dr1.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        var er = ex.Message;
        //        // rpr.Error = ex.Message;
        //    }
        //    finally
        //    {
        //        cmd1.Dispose();
        //        conn.Close();
        //    }
        //    return functionReturnValue;

        //}
    }
}