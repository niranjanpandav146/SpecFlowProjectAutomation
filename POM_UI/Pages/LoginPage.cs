using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.SeleniumKeyHelper;

namespace POM_UI.Pages
{
    public class LoginPage
    {
        IWebDriver driver;
        SeleniumKeyHelper common;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            common = new SeleniumKeyHelper();
        }

        #region Methods
        //Method for user login
        //param: userNameType = type of userNameUI Element , passwordType = type of PaswordUI Element , userNameValue = UserName , Password = Password 
        public void LoginToApplication(string userNameType,string passwordType,string buttonType,string userNameValue,string passwordValue)
        {
            common.EnterTextToElement(driver.FindElement(By.XPath($"//input[@id='{userNameType}']")), userNameValue);
            common.EnterTextToElement(driver.FindElement(By.XPath($"//input[@id='{passwordType}']")), passwordValue);
            common.ClickOnElement(driver.FindElement(By.XPath($"//input[@type='{buttonType}']")));
        }
        #endregion


    }
}
