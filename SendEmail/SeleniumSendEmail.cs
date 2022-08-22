using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SendImail
{
    class SeleniumSendEmail
    {
        String test_url = "https://accounts.ukr.net/";
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

            // Logging
            var login = driver.FindElement(By.Name("login")); 
            login.SendKeys("testmail8855");
            var password = driver.FindElement(By.XPath("//label[@class='cvxzFsio']/input[@type='password']")); 
            password.SendKeys("1983k1983");
            var logging = driver.FindElement(By.CssSelector("button.Ol0-ktls"));
            logging.Click();
            
            // trying to handle captcha
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[starts-with(@name, 'a-') and starts-with(@src, 'https://www.google.com/recaptcha')]")));//acceptAgree.Click();button.Ol0-ktls
            var captcha = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='recaptcha-checkbox-border']")));
            captcha.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//aside[@class='sidebar']/button[@class]")));
           
            // Writing and sending e-mail
            var writeLetter = driver.FindElement(By.XPath("//aside[@class='sidebar']/button[@class]"));
            writeLetter.Click();
            var sendTo = driver.FindElement(By.CssSelector("div.sendmsg input[type=text]"));
            sendTo.SendKeys("testmail28855@ukr.net");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("mce_0_ifr")));
            var letterVvod = driver.FindElement(By.Id("mce_0_ifr"));
            letterVvod.SendKeys("Hello my friend!");
            var sendButton = driver.FindElement(By.CssSelector("div.sendmsg__bottom-controls .button"));
            sendButton.Click();
          
               
        }


        [TearDown]
        public void close_Browser()
        {
           driver.Quit();
        }
    }
}