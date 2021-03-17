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
    public class SignInPage
    {
        IWebDriver _driver;
        IWebElement webElement;
        WebConnector selenium = new WebConnector();

        WebDriverWait wait;

        public SignInPage(IWebDriver _driver)
        {
            this._driver = _driver;
            PageFactory.InitElements(_driver, this);
        }


        
        [FindsBy(How = How.XPath, Using = "//*[@id='header']/div[2]/div/div/nav/div[1]/a")]
        public IWebElement SiginTab { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='email']")]
        public IWebElement EmailAddres { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='passwd']")]
        public IWebElement Password { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='SubmitLogin']")]
        public IWebElement SigninButton { get; set; }


        public void ClickOnSiginTab()
        {
            SiginTab.Click();
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));
        }

        public void ClickOnSignInButton(string strEmail, string strPassword)
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));
            EmailAddres.SendKeys(strEmail);
            Password.SendKeys(strPassword);
            SigninButton.Click();

        }
    }
}
