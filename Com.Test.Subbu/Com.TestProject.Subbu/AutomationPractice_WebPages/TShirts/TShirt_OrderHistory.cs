using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.TestProject.Subbu.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace Com.TestProject.Subbu.AutomationPractice_WebPages.TShirts
{
    public class TShirt_OrderHistory
    {
        IWebDriver _driver;
        IWebElement webElement;
        WebConnector selenium = new WebConnector();

        public TShirt_OrderHistory(IWebDriver _driver)
        {
            this._driver = _driver;
            PageFactory.InitElements(_driver, this);
        }


        //SHOPPING-CART SUMMARY
        [FindsBy(How = How.XPath, Using = "html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr")]
        public IWebElement TShirts_OrderSumaryTable { get; set; }

        Dictionary<string, string> dictOrderSummaryDetails = new Dictionary<string, string>();

        ///html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr
        public Dictionary<string,string> GetOrderDetails()
        {
            Dictionary<string, string> lstOrderDetails = new Dictionary<string, string>();

            IWebElement ntTable = _driver.FindElement(By.XPath("html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody/tr"));

            string[] stringSeparators = new string[] { "\r\n" };
            string[] actData = ntTable.Text.Split(stringSeparators, StringSplitOptions.None);


            IWebElement tableElement = _driver.FindElement(By.XPath("html/body/div/div[2]/div/div[3]/div/div[2]/table/tbody"));

            IList<IWebElement> trCollection = tableElement.FindElements(By.TagName("tr"));
            IList<IWebElement> tdCollection;

            foreach (IWebElement element in trCollection)
            {
                tdCollection = element.FindElements(By.TagName("td"));
                lstOrderDetails.Add("productName", tdCollection[1].Text.Split(stringSeparators, StringSplitOptions.None)[0]);
                lstOrderDetails.Add("unitPrice", tdCollection[3].Text);
                lstOrderDetails.Add("qty", _driver.FindElement(By.XPath("//*[@id='product_1_1_0_0']/td[5]/input[2]")).GetAttribute("value"));
                lstOrderDetails.Add("total", tdCollection[5].Text);
                

            }

            return lstOrderDetails;


        }

    }
}
