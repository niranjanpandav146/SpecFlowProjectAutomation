using OpenQA.Selenium;
using SpecFlowProjectAutomation.Base;
using Utility.SeleniumKeyHelper;
namespace POM_UI.Pages
{
    public class LoginPage : BasePage
    {
        #region Methods
        //Method for user login
        //param: userNameType = type of userNameUI Element , passwordType = type of PaswordUI Element , userNameValue = UserName , Password = Password 
        public InventoryPage LoginToApplication(string userNameType,string passwordType,string buttonType,string userNameValue,string passwordValue)
        {
            SeleniumKeyHelper.EnterTextToElement(DriverContext.Driver.FindElement(By.XPath($"//input[@id='{userNameType}']")), userNameValue);
            SeleniumKeyHelper.EnterTextToElement(DriverContext.Driver.FindElement(By.XPath($"//input[@id='{passwordType}']")), passwordValue);
            SeleniumKeyHelper.ClickOnElement(DriverContext.Driver.FindElement(By.XPath($"//input[@type='{buttonType}']")));

            return GetInstance<InventoryPage>();
        }
        #endregion


    }
}
