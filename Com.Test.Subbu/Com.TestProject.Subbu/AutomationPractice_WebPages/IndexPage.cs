using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Com.TestProject.Subbu.Utility;

public class IndexPage
{
    IWebDriver _driver;
    IWebElement webElement;
    WebConnector selenium = new WebConnector();

    public IndexPage(IWebDriver _driver)
    {
        this._driver = _driver;
        PageFactory.InitElements(_driver, this);
    }

    ////*[@id="block_top_menu"]/ul/li[3]/a
    ///

    [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[3]/a")]
    public IWebElement TShirtsLink { get; set; }


    public void TShirtsLinkClick()
    {
        TShirtsLink.Click();
    }

}