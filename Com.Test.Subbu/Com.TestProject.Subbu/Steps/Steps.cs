using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Com.TestProject.Subbu.AutomationPractice_WebPages.TShirts;
using TechTalk.SpecFlow.NUnit;
using NUnit.Framework;
using Com.TestProject.Subbu.AutomationPractice_WebPages;

namespace Com.TestProject.Subbu.Steps
{
    [Binding]
    public class Steps
    {
        IWebDriver driver;

        IndexPage indexPage;
        TShirtsPage tShirtsPage;
        TShirt_OrderHistory shirt_OrderHistory;
        SignInPage signInPage;
        PersonalInformation personalInformation;

        IEnumerable<OrderDetails> orderDetails = null;

        [Given(@"I launch below application using ""(.*)"" and ""(.*)"" browser")]
        public void GivenILaunchBelowApplicationUsingAndBrowser(string strSiteURL, string strBrowserType)
        {
            if (strBrowserType == "Chrome")
            {
                driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            }
            driver.Navigate().GoToUrl(strSiteURL);

            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);

        }

        [Then(@"I click on T-SHIRTS tab")]
        public void ThenIClickOnT_SHIRTSTab()
        {
            indexPage = new IndexPage(driver);
            indexPage.TShirtsLinkClick();

        }
        [Then(@"I select and click on T-Shirts AddCart")]
        public void ThenISelectAndClickOnT_ShirtsAddCart()
        {
            tShirtsPage = new TShirtsPage(driver);
            tShirtsPage.AddCart_Click();
        }

        [Then(@"I validae Order Summary")]
        public void ThenIValidaeOrderSummary(Table table)
        {
            orderDetails = table.CreateSet<OrderDetails>();

            Dictionary<string, string> lstGetOrderDetails = new Dictionary<string, string>();

            shirt_OrderHistory = new TShirt_OrderHistory(driver);

            lstGetOrderDetails = shirt_OrderHistory.GetOrderDetails();

            var expData = (from expOrderDetails in orderDetails
                           select new
                           {
                               expOrderDetails.productName,
                               expOrderDetails.unitPrice,
                               expOrderDetails.qty,
                               expOrderDetails.total
                           }
                          ).ToList();
            foreach (var item in expData)
            {
                foreach (var actValue in lstGetOrderDetails)
                {
                    if (nameof(item.productName) == actValue.Key)
                    {
                        Assert.AreEqual(item.productName, actValue.Value);
                    }
                    else if (nameof(item.unitPrice) == actValue.Key)
                    {
                        Assert.AreEqual(item.unitPrice, actValue.Value);
                    }
                    else if (nameof(item.qty) == actValue.Key)
                    {
                        Assert.AreEqual(item.qty, actValue.Value);
                    }
                    else if (nameof(item.total) == actValue.Key)
                    {
                        Assert.AreEqual(item.total, actValue.Value);
                    }
                }
            }

            driver.Quit();
        }

        [Then(@"I click on Sigin button")]
        public void ThenIClickOnSiginButton()
        {
            signInPage = new SignInPage(driver);
            signInPage.ClickOnSiginTab();
        }
        [Then(@"Enter login details ""(.*)"" and ""(.*)""")]
        public void ThenEnterLoginDetailsAnd(string userName, string password)
        {
            signInPage = new SignInPage(driver);
            signInPage.ClickOnSignInButton(userName, password);
        }

        [Then(@"Update Personal Information ""(.*)"" and ""(.*)""")]
        public void ThenUpdatePersonalInformationAnd(string strFirstName, string strCurrentPassword)
        {
            personalInformation = new PersonalInformation(driver);
            personalInformation.UpdatePersonalInformation(strFirstName, strCurrentPassword);
            driver.Quit();
        }

    }

    public class OrderDetails
    { 
        public string productName { get; set; }
        public string colorAndSize { get; set; }
        public string unitPrice { get; set; }
        public string qty { get; set; }
        public string total { get; set; }
        public OrderDetails() { }
    }


}
