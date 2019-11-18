using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;


namespace SeleniumConsoleScraper
{
    public class Scraper
    {
            public List<Stock> Scrape()
            {

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

                    // //*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[1]/td[13]/span

                    IWebElement list = driver.FindElement(By.TagName("tbody"));
                    ReadOnlyCollection<IWebElement> items = list.FindElements(By.TagName("tr"));
                    int count = items.Count;
                    Console.WriteLine();
                    Console.WriteLine("items: {0}", count);



                    // create list to store stock data type
                    List<Stock> stockList = new List<Stock>();

                    // print the contents of that list to the console
                    Console.WriteLine("The Portfolio of stocks is as follows: ");

                    //Loop iterate through portfolio of stocks, gathering data
                    // current issue is the 
                    for (int i = 1; i <= count; i++)
                    {
                        Console.WriteLine(DateTime.Now);
                        string symbol = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[1]/a")).GetAttribute("innerText");
                        Console.WriteLine(symbol);
                        string lastPrice = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[2]")).GetAttribute("innerText");
                        Console.WriteLine(lastPrice);
                        string change = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[3]")).GetAttribute("innerText");
                        Console.WriteLine(change);
                        string chgpc = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[4]")).GetAttribute("innerText");
                        Console.WriteLine(chgpc);
                        string marketTime = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[6]")).GetAttribute("innerText");
                        Console.WriteLine(marketTime);
                        string volume = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[7]")).GetAttribute("innerText");
                        Console.WriteLine(volume);
                        string avgvol3m = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[9]")).GetAttribute("innerText");
                        Console.WriteLine(avgvol3m);
                        string marketcap = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + i + "]/td[13]")).GetAttribute("innerText");
                        Console.WriteLine(marketcap);
                        string method = "Sel";
                        Console.WriteLine(method);

                        // for each stock entry, a new stock object is created
                        // the above data is set equal to the field within the object
                        Stock newStock = new Stock();
                        newStock.DateStamp = DateTime.Now.ToString();
                        newStock.Symbol = symbol;
                        newStock.LastPrice = lastPrice;
                        newStock.Change = change;
                        newStock.ChgPc = chgpc;
                        newStock.MarketTime = marketTime;
                        newStock.Volume = volume;
                        newStock.AvgVol3m = avgvol3m;
                        newStock.MarketCap = marketcap;
                        newStock.Method = method;

                        // that stock is then added to the list of stocks
                        stockList.Add(newStock);
                    }

                    driver.Quit();

                    return stockList;


                }
            }
        }
    }
