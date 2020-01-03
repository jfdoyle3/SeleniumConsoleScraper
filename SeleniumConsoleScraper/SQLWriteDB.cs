using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SeleniumConsoleScraper
{
    public class SqlWriteDB
    {
        public static void SeleniumStocks(List<string> stockList)
        {
            Console.Write("connecting to SeleniumDB: ");
            string connectionstring = @"data source=(localdb)\mssqllocaldb;initial catalog=SeleniumDB;integrated security=true";

            string type = "Selenium";

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                Console.Write("Successful\n");
                Console.Write("Writing to SeleniumDB: ");
                for (int i = 0; i < stockList.Count; i++)
                {
                    connection.Open();

                    SqlCommand insertstatement = new SqlCommand("insert into [SeleniumStocks] (datestamp, symbol, lastprice, change, chgpc, markettime, volume, avgvol3m, marketcap,method) values (@datestamp, @symbol, @lastprice, @change, @chgpc, @markettime, @volume, @avgvol3m, @marketcap, @method)", connection);
                    insertstatement.Parameters.AddWithValue("@datestamp", DateTime.Now.ToString());
                    insertstatement.Parameters.AddWithValue("@symbol", stockList[i].ToString());
                    insertstatement.Parameters.AddWithValue("@lastprice", stockList[i].ToString());
                    insertstatement.Parameters.AddWithValue("@change", stockList[i].ToString());
                    insertstatement.Parameters.AddWithValue("@chgpc", stockList[i].ToString());
                    insertstatement.Parameters.AddWithValue("@markettime", stockList[i].ToString());
                    insertstatement.Parameters.AddWithValue("@volume", stockList[i].ToString());
                    insertstatement.Parameters.AddWithValue("@avgvol3m", stockList[i].ToString());
                    insertstatement.Parameters.AddWithValue("@marketcap", stockList[i].ToString());
                    insertstatement.Parameters.AddWithValue("@method", type);


                    insertstatement.ExecuteNonQuery();
                    connection.Close();
                }
                Console.Write("Successful");
            }
        }
    }
      

