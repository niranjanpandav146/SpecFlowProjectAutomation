using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.SeleniumKeyHelper;

namespace POM_UI.Pages
{
    public class HomePage
    {
        IWebDriver driver;
        SeleniumKeyHelper common;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            common = new SeleniumKeyHelper();
        }

        //string _linksignUpLink = "//a[@class='Button--hby7mx Button--s7p5bc ieqcHu js__event-link']";

        //public void clickonSignUpLink()
        //{
        //    driver.FindElement(By.XPath(_linksignUpLink)).Click();
        //}

        string _linkMyAccount = "//a[@href='http://practice.automationtesting.in/my-account/']";

        public void clickonSignUpLink()
        {
            //driver.FindElement(By.XPath(_linkMyAccount)).Click();
            common.ClickOnElement(driver.FindElement(By.XPath(_linkMyAccount)));
        }
    }
}
