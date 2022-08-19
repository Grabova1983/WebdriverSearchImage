using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium_Webdriver_Search_Image
{
    class SeleniumWebdriver
    {
        String test_url = "https://www.google.com/";
        IWebDriver driver;
       
        
        [SetUp]
        public void CreateDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
                    
       
        [Test]
        public void testSearch()
        {
            driver.Navigate().GoToUrl(test_url);
            var acceptAgree = driver.FindElement(By.Id("L2AGLb"));
            acceptAgree.Click();
            var poiskVvod = driver.FindElement(By.Name("q"));
            poiskVvod.SendKeys("image" + Keys.Enter);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var refImages = driver.FindElement(By.XPath("//a[text()='Картинки' or text()='Images']"));
            refImages.Click();
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                var image = driver.FindElement(By.TagName("img")).FindElement(By.XPath("//img[@jsname='Q4LuWd']"));
            }
            
            catch
            {
                throw new Exception("Sorry, but there are no images!");
            }
                                                    
                Assert.Pass("Images are found");           
        }
                

        [TearDown]
        public void close_Browser()
        {
           driver.Quit();
        }
    }
}