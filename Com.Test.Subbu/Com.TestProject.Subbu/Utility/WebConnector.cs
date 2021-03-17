using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;



namespace Com.TestProject.Subbu.Utility
{
    class WebConnector
    {
        public static ChromeDriver _driver;
        public WebConnector()
        {
        }

        public void OpenChromeBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximize");
            options.AddAdditionalCapability("useAutomationExtension", false);

            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);


        }


    }
}
