﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace testConSel
{
    public class Program
    {
        static void Main(string[] args)
        {
            var runScraper = new Scraper();

            runScraper.Scrape();
        }
    }

    public class Stock
    {
        public string Symbol { get; set; }
        public string Price { get; set; }
        public string Change { get; set; }
        public string PChange { get; set; }
        public string Volume { get; set; }
        public string MarketCap { get; set; }
        public string ScrapeTime { get; set; }
    }

    public class Scraper
    {
        public List<Stock> Scrape()
        {
            //ChromeOptions options = new ChromeOptions();

            //// Add capbilities to ChromeOptions
            //options.AddArguments("test -Type", "--ignore-certificate-errors", "--disable-gpu", "disable-popups");

            //// Launching browser with desired capabilities + proper binary file location
            ////IWebDriver driver = new ChromeDriver(@"\Users\gregs\Desktop\CD\CapstoneConsoleApp\CapstoneConsoleApp\bin", options);
            //IWebDriver driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();

            //// create default wait 100 seconds + set to ignore the most persistent and disruptive timeout errors that break scraper
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100000));
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverTimeoutException), typeof(UnhandledAlertException));

            //driver.Navigate().GoToUrl("https://login.yahoo.com/config/login?.src=finance&amp;.intl=us&amp;.done=https%3A%2F%2Ffinance.yahoo.com%2Fportfolios");

            //wait.Until(waiter => waiter.FindElement(By.Id("login-username")));
            //IWebElement username = driver.FindElement(By.Id("login-username"));
            //username.SendKeys("jfdoyle_iii");
            //username.SendKeys(Keys.Enter);

            //// EXPLICIT WAIT
            //wait.Until(waiter => waiter.FindElement(By.Id("login-passwd")));
            //IWebElement password = driver.FindElement(By.Id("login-passwd"));
            //password.SendKeys("m93Fe8YHn");
            //IWebElement loginButton = driver.FindElement(By.Id("login-signin"));
            //loginButton.SendKeys(Keys.Enter);
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--headless");
            option.AddArgument("window-size=1200,1100");

            using (IWebDriver driver = new ChromeDriver(option))
            {
                driver.Navigate().GoToUrl("https://finance.yahoo.com");

                WebDriverWait waitSignIn = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                waitSignIn.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("uh-signedin")));

                IWebElement signIn = driver.FindElement(By.Id("uh-signedin"));
                signIn.Click();

                WebDriverWait waitLogin = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                waitLogin.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login-username")));

                IWebElement LoginField = driver.FindElement(By.Id("login-username"));
                LoginField.SendKeys("jfdoyle_iii");
                LoginField.SendKeys(Keys.Enter);

                WebDriverWait waitPassword = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                waitPassword.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("login-passwd")));


                IWebElement passwordField = driver.FindElement(By.Id("login-passwd"));
                passwordField.SendKeys("m93Fe8YHn");
                passwordField.SendKeys(Keys.Enter);



                driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_2/view/v1");
                WebDriverWait waitStockTable = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                waitStockTable.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//table")));


                IWebElement list = driver.FindElement(By.TagName("tbody"));
                ReadOnlyCollection<IWebElement> items = list.FindElements(By.TagName("tr"));
                int count = items.Count;



                // create list to store stock data type
                List<Stock> stockList = new List<Stock>();

                // print the contents of that list to the console
                Console.WriteLine("The Portfolio of stocks is as follows: ");

                //Loop iterate through portfolio of stocks, gathering data
                // current issue is the 
                for (int i = 1; i <= count; i++)
                {
                    string symbol = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[1]/a")).GetAttribute("innerText");
                    Console.WriteLine(symbol);
                    string price = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[2]/span")).GetAttribute("innerText");
                    Console.WriteLine(price);
                    string change = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[3]/span")).GetAttribute("innerText");
                    Console.WriteLine(change);
                    string pchange = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[4]/span")).GetAttribute("innerText");
                    Console.WriteLine(pchange);
                    string volume = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[7]/span")).GetAttribute("innerText");
                    Console.WriteLine(volume);
                    string marketcap = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[13]/span")).GetAttribute("innerText");
                    Console.WriteLine(marketcap);
                    string scrapeTime = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[6]/span")).GetAttribute("innerText");
                    Console.WriteLine(scrapeTime);


                    // for each stock entry, a new stock object is created
                    // the above data is set equal to the field within the object
                    Stock newStock = new Stock();
                    newStock.Symbol = symbol;
                    newStock.Price = price;
                    newStock.Change = change;
                    newStock.PChange = pchange;
                    newStock.ScrapeTime = scrapeTime;
                    newStock.Volume = volume;
                    newStock.MarketCap = marketcap;

                    // that stock is then added to the list of stocks
                    stockList.Add(newStock);
                }

                driver.Quit();

                return stockList;

                //using (SelStocksContext db = new SelStocksContext())
                //{

                //    for (int i = 0; i < stockList.Count; i++)
                //    {

                //        testSel stockTable = new testSel
                //        {

                //            Symbol = stockList[i].ToString(),
                //            LastPrice = stockList[i].ToString(),
                //            Change = stockList[i].ToString(),
                //            ChgPc = stockList[i].ToString(),
                //            Currency = stockList[i].ToString(),
                //            MarketTime = stockList[i].ToString(),
                //            Volume = stockList[i].ToString(),
                //            AvgVol3m = stockList[i].ToString(),
                //            MarketCap = stockList[i][1.ToString(),
                //        };

                //        db.StockTables.Add(stockTable);
                //        db.SaveChanges();
                //    }
                //}
            }
        }
    }
}