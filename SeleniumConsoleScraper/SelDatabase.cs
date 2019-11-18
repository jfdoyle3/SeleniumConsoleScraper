using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SeleniumConsoleScraper
{
    public class SelDatabase
    {
        public void SeltoDatabase(dynamic stockList)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Selenium;Integrated Security=True";

            string type = "Sel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                foreach (var stock in stockList)
                {
                    connection.Open();

                    SqlCommand insertStatement = new SqlCommand("INSERT into [SelStockTable] (DateStamp, Symbol, LastPrice, Change, ChgPc, MarketTime, Volume, Price, AvgVol3m, MarketCap,Method) VALUES (@DateStamp, @Symbol, @LastPrice, @Change, @ChgPc, @MarketTime, @Volume, @Price, @AvgVol3m, @MarketCap, @Method)", connection);
                    insertStatement.Parameters.AddWithValue("@DateStamp", DateTime.Now.ToString());
                    insertStatement.Parameters.AddWithValue("@Symbol", stock["symbol"].ToString());
                    insertStatement.Parameters.AddWithValue("@LastPrice", stock["lastPrice"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Change", stock["marketChange"]["fmt"].ToString());insertStatement.Parameters.AddWithValue("@ChgPct", stock["regularMarketChangePercent"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Time", stock["regularMarketTime"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Change", stock["regularMarketChange"]["fmt"].ToString());
                    
                    insertStatement.Parameters.AddWithValue("@Price", stock["regularMarketPrice"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Closing", stock["regularMarketPreviousClose"]["fmt"].ToString());
                    insertStatement.Parameters.AddWithValue("@Method", type);



                    insertStatement.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
