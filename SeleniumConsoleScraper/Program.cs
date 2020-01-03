using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumConsoleScraper
{
    public class Program
    {
        static void Main(string[] args)
        {
            Scraper stockList = new Scraper();
            SqlWriteDB.SeleniumStocks(stockList);


        }
    }
}





