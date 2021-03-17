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


namespace Com.TestProject.Subbu.AutomationPractice_WebPages
{
   public class PersonalInformation
    {
        IWebDriver _driver;
        IWebElement webElement;
        WebConnector selenium = new WebConnector();

        WebDriverWait wait;

        public PersonalInformation(IWebDriver _driver)
        {
            this._driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/div/div[1]/ul/li[4]/a/span")]
        public IWebElement PersonalInformationButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='firstname']")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='old_passwd']")]
        public IWebElement CurrentPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/div/form/fieldset/div[11]/button")]
        public IWebElement SaveButton { get; set; }


        public void UpdatePersonalInformation(string strFirstName,string strCurrentPassword)
        {
            PersonalInformationButton.Click();

            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));
            FirstName.Clear();
            FirstName.SendKeys(strFirstName);
            CurrentPassword.SendKeys(strCurrentPassword);
            SaveButton.Click();
        }
    }
}
