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
    public class TShirtsPage
    {
        IWebDriver _driver;
        IWebElement webElement;
        WebConnector selenium = new WebConnector();

        public TShirtsPage(IWebDriver _driver)
        {
            this._driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/ul/li/div/div[1]/div/a[1]/img")]
        public IWebElement TShirts_ImageLink { get; set; }

        //[FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div[3]/div[2]/ul/li")]
        //public IWebElement TShirts_Image { get; set; }


        [FindsBy(How = How.XPath, Using = "html/body/div/div[2]/div/div[3]/div[2]/ul/li/div/div[2]/div[1]")]
        public IWebElement TShirts_ImageArea { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div/div[3]/div/div/div/div[4]/form/div/div[3]/div[1]/p/button")]
        public IWebElement TShirts_AddCartButton { get; set; }

        ///html/body/div/div/div[3]/form/div/div[3]/div[1]/p/button

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a")]
        public IWebElement TShirts_ProceedToCheckOutButton { get; set; }

        ///
        WebDriverWait wait;
        public void AddCart_Click()
        {
            TShirts_ImageArea.Click();

            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));

            //Actions actions = new Actions(_driver);
            //actions.MoveToElement(TShirts_ImageArea).Click().Perform();
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(200));

            
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a")));
            TShirts_ProceedToCheckOutButton.Click();
            //TShirts_ProceedToCheckOutButton.Click();


        }

    }
}
