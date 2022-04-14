using OpenQA.Selenium;
using POM_UI.Pages;
using SpecFlowProjectAutomation.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectAutomation.StepDefinitions
{
    [Binding]
    public class LoginActionStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        HomePage homepage;
        LoginPage loginpage;

        public LoginActionStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"User is on Home Page")]
        public void GivenUserIsOnHomePage()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").setup();
            driver.Url = "http://practice.automationtesting.in/";
            driver.Manage().Window.Maximize();
            homepage = new HomePage(driver);
            homepage.clickonSignUpLink();
        }

        [When(@"User Navigate to LogIn Page")]
        public void WhenUserNavigateToLogInPage()
        {
            loginpage = new LoginPage(driver);
            loginpage.VerifyLoginPageHeader();
        }

        [When(@"User enters UserName and Password")]
        public void WhenUserEntersUserNameAndPassword()
        {   
            loginpage.EnterUserName("niranjan146@gmail.com");
            loginpage.EnterPassword("Test!Automation@Engineer#Test");
            loginpage.clickonLogin();
        }

        [Then(@"Message displayed Login Successfully")]
        public void ThenMessageDisplayedLoginSuccessfully()
        {
            loginpage.VerifyUserLoginHeader("niranjan146");
            loginpage.clickonLogout();
        }
    }
}
