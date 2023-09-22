using Microsoft.VisualBasic;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
namespace VS_Master_API.Models
{
    public class GetNumbers
    {

        public GetNumbers()
        {

        }

        DbConnectionClass GetDbConnection = new DbConnectionClass();
        public void ExecuteQueryNow(string StrQuery)
        {
            var Connstr = GetDbConnection.DbConnString();
            try
            {
                SqlConnection Conn = new SqlConnection(Connstr.ToString());
                SqlCommand CMd = new SqlCommand(StrQuery, Conn);
                Conn.Open();
                CMd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                var k = ex.Message;
            }
        }


        public string RetriveParticularColumns(string SqlQuery, Int16 ColNo)
        {
            var Connstr = GetDbConnection.DbConnString();
            string functionReturnValue = "";

            SqlConnection conn = new SqlConnection(Connstr.ToString());
            SqlCommand cmd1 = new SqlCommand(SqlQuery, conn);
            SqlDataReader dr1;
            try
            {
                conn.Open();
                dr1 = cmd1.ExecuteReader();

                while ((dr1.Read()))
                {
                    if (!dr1[ColNo].Equals(System.DBNull.Value))
                    {
                        functionReturnValue = dr1[ColNo].ToString();
                    }
                    else
                    {
                        functionReturnValue = "";
                    }
                }
                dr1.Close();
            }
            catch (Exception ex)
            {
                var er = ex.Message;
                // rpr.Error = ex.Message;
            }
            finally
            {
                cmd1.Dispose();
                conn.Close();
            }
            return functionReturnValue;

        }


        public void ActivityTrackNow(string message)
        {

            try
            {
                if ((message.Length > 0))
                {
                    StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\EROTLOG\\API_log.txt");
                    sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - " + message);
                    sw.Close();
                }

            }
            catch (Exception)
            {
            }
        }

        public void ActivityTrackNowEROT(string message)
        {

            try
            {
                if ((message.Length > 0))
                {
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss");

                    StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\EROTLOG\\" + filename + ".txt");
                    sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - " + message);
                    sw.Close();
                }

            }
            catch (Exception)
            {
            }
        }


        public void ActivityTrackNowEROTKK(string message, int Check)
        {

            string CurrDir = AppDomain.CurrentDomain.BaseDirectory.ToString();

            try
            {
                if ((message.Length > 0))
                {
                    string filename = "";

                    if (Check > 0)
                    {
                        filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_OKJson";
                        StreamWriter sw = File.AppendText(CurrDir + "\\EROTLOG\\" + filename + ".txt");
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - " + message);
                        sw.Close();
                    }
                    else
                    {
                        filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_NOTJson";
                        StreamWriter sw = File.AppendText(CurrDir + "\\EROTLOG\\" + filename + ".txt");
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " - " + message);
                        sw.Close();
                    }



                }

            }
            catch (Exception)
            {
            }
        }

        public static string StripOutNow(string From, string What)
        {
            string StripOutNow = "";
            try
            {
                int i;

                From = From.Replace("\"", " ");
                From = From.ToString().Replace(System.Environment.NewLine, " ");
                From = From.Replace(",", " ").Trim();
                From = From.Replace("@", " ").Trim();
                From = From.Replace("@@", " ").Trim();
                From = From.Replace("\r\n", " ");
                From = From.Replace(".", " ");
                From = From.Replace("&", " ");
                From = From.Replace(":", " ");
                From = From.Replace("'", " ");
                From = From.Replace("\n", " ");
                From = From.Replace("/", " ");
                From = From.Replace("**", " ");

                From = Regex.Replace(From, @"[^0-9a-zA-Z._'*]+", " ");

                string s = From;
                for (i = 1; i <= Strings.Len(What); i++)
                {
                    var ssk = Strings.Mid(What, i, 1);
                    // StripOutNow =  (s, Strings.Mid(What, i, 1), " ");
                    StripOutNow = s.ToString().Replace(ssk, " ");
                }
            }
            catch (Exception)
            {

                return StripOutNow = "";
            }
            return StripOutNow;


        }


    }


}
