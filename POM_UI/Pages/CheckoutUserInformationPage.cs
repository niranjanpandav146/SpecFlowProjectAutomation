using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.SeleniumKeyHelper;

namespace POM_UI.Pages
{
    public class CheckoutUserInformationPage
    {
        IWebDriver driver;
        SeleniumKeyHelper common;
        public CheckoutUserInformationPage(IWebDriver driver)
        {
            this.driver = driver;
            common = new SeleniumKeyHelper();
        }

        #region Methods
        //Method to fill user information
        //param: firstName = User's FirstName, lastName = User's LastName , zip = User's Zip
        public void FillUserInformation(string firstName, string lastName, string zip)
        {
            common.EnterTextToElement(driver.FindElement(By.Id("first-name")), firstName);
            common.EnterTextToElement(driver.FindElement(By.Id("last-name")), lastName);
            common.EnterTextToElement(driver.FindElement(By.Id("postal-code")), zip);
            common.ClickOnElement(driver.FindElement(By.Id("continue")));
        }

        #endregion
    }
}
