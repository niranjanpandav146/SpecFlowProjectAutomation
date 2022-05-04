using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectAutomation.Base;
using Utility.SeleniumKeyHelper;

namespace POM_UI.Pages
{
    public class CheckoutUserInformationPage : BasePage
    {
        #region Methods
        //Method to fill user information
        //param: firstName = User's FirstName, lastName = User's LastName , zip = User's Zip
        public CheckoutOverviewPage FillUserInformation(string firstName, string lastName, string postalCode)
        {
            try
            {
                SeleniumKeyHelper.EnterTextToElement(DriverContext.Driver.FindElement(By.Id("first-name")), firstName);
                SeleniumKeyHelper.EnterTextToElement(DriverContext.Driver.FindElement(By.Id("last-name")), lastName);
                SeleniumKeyHelper.EnterTextToElement(DriverContext.Driver.FindElement(By.Id("postal-code")), postalCode);
                SeleniumKeyHelper.ClickOnElement(DriverContext.Driver.FindElement(By.Id("continue")));
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to Fill User Details " + ex.Message);
            }
            return GetInstance<CheckoutOverviewPage>();
        }
        #endregion
    }
}
