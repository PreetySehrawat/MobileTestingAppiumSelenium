using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionSample
{
    public class DatabaseUtils
    {
        private SqlConnection sqlConn;

        static List<Datacollection> dbdataCol = new List<Datacollection>();

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        public static void ClearData()
        {
            dbdataCol.Clear();
        }


        public void Connect_To_Database()
        {
            try
            {
                string connectionstring = @"Data Source=servicebookingdbservtest.database.windows.net;Initial Catalog=ServiceBookingDb;User ID=ExperiecoAdmin;Password=9aJrtENEU6JV3h$";
                using (sqlConn = new SqlConnection(connectionstring))
                {
                    sqlConn.Open();

                    SqlCommand command;
                    SqlDataReader datareader;

                    //string sql = "select * from dbo.Customers where customerno in( 123123,300300,200200,1, 128228)";

                    string sql = "select * from Appointments;";

                    command = new SqlCommand(sql, sqlConn);

                    //command.ExecuteNonQuery();
                    //datareader = command.ExecuteNonQuery();  -- For Update/Delete/Insert
                    datareader = command.ExecuteReader();  //For Select

                    var columns = new List<string>();
                    int k = 1;
                    while (datareader.Read())
                    {
                       
                        for (int j = 0; j < datareader.FieldCount; j++)
                        {
                            Datacollection dtTable = new Datacollection()
                            {
                                rowNumber = k,
                                colName = datareader.GetName(j),
                                colValue = datareader.GetValue(j).ToString()
                            };

                            dbdataCol.Add(dtTable);                          
                        }
                        k++;
                    }

                    Console.WriteLine(columns);

                    //DataTable table = new DataTable();
                    //table.Load(command.ExecuteReader());

                    //string WhereClause = "JobDate = '2018-11-26'";
                    //DataRow[] foundRows;

                    //foundRows = table.Select(WhereClause);                

                    //for(int i = 0; i < foundRows.Length; i++)
                    //{
                    //    Console.WriteLine(foundRows[i][0]);
                    //}

                    datareader.Close();
                    command.Dispose();
                    sqlConn.Close();
                }
                
            }
            catch(Exception e)
            {
                //Log the exception in Error log
                Console.WriteLine("Exception occurred in Connect_To_Database!" + Environment.NewLine + e.Message.ToString());
            }
            finally
            {
                if (sqlConn != null) sqlConn.Close();
            }
        }


        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations

                rowNumber = rowNumber - 1;
                string data = (from colData in dbdataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


                return data.ToString();
            }

            catch (Exception e)
            {
                //Added by Kumar
                Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                return null;
            }
        }
    }
}
