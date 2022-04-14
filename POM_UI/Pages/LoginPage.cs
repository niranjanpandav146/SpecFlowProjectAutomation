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

       private string _inputUserName = "//input[@id='username']";
       private string _inputPassword = "//input[@id='password']";
       private string _buttonLogin = "//input[@name='login']";
       private string _headerLogin = "//h2[contains(text(),'Login')]";
       private string _contentMyAccountSection = "//div[@class='woocommerce-MyAccount-content']";
       private string _buttonlogOut = "//a[@href='http://practice.automationtesting.in/my-account/customer-logout/']";
        public void EnterUserName(string userName)
        {   
            common.EnterTextToElement(driver.FindElement(By.XPath(_inputUserName)),userName);
        }
        public void EnterPassword(string password)
        {
            common.EnterTextToElement(driver.FindElement(By.XPath(_inputPassword)),password);
        }
        public void clickonLogin()
        {
            common.ClickOnElement(driver.FindElement(By.XPath(_buttonLogin)));
        }

        public void VerifyLoginPageHeader()
        {
            string value = common.GetElementText(driver.FindElement(By.XPath(_headerLogin)));
            if(value.Contains("Login"))
            {
                Console.WriteLine("Verified on Login Page Navigation");
            }
        }

        public void VerifyUserLoginHeader(string text)
        {
            string value = common.GetElementText(driver.FindElement(By.XPath(_contentMyAccountSection)));
            if (value.Contains(text))
            {
                Console.WriteLine(text + " Verified "+text+" Logged in Successfully");
            }
        }

        public void clickonLogout()
        {
            common.ClickOnElement(driver.FindElement(By.XPath(_buttonlogOut)));
        }



    }
}
