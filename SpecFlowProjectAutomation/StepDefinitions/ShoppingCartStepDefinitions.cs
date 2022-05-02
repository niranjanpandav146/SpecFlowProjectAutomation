using OpenQA.Selenium;
using POM_UI.Pages;
using System;
using TechTalk.SpecFlow;
using SpecFlowProjectAutomation.Drivers;
using TechTalk.SpecFlow.Assist;
using AventStack.ExtentReports.Model;

namespace SpecFlowProjectAutomation.StepDefinitions
{
    [Binding]
    public class ShoppingCartStepDefinitions
    {
        IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;        
        LoginPage loginpage;
        InventoryPage inventorypage;
        CartPage cartpage;
        CheckoutUserInformationPage checkoutuserinfopage;
        CheckoutOverviewPage checkoutOverviewPage;
        public string price = "";
      

        public ShoppingCartStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"User navigate to saucedemo application")]
        public void GivenUserNavigateToSaucedemoApplication(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").setup(data.browserName);
            driver.Url = data.url; 
        }

        [Given(@"User login to saucedemo application")]
        public void GivenUserLoginToSaucedemoApplication(Table table)
        {   
                loginpage = new LoginPage(driver);
                dynamic data = table.CreateDynamicInstance();
                loginpage.LoginToApplication("user-name", "password", "submit", data.userName, data.password);         
        }

        [Given(@"User add product to shopping cart")]
        public void GivenUserAddProductToShoppingCart(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            inventorypage =new InventoryPage(driver);
            price = inventorypage.SelectItemforShopping(data.productName);
            inventorypage.ClickCart();
        }

        [Given(@"User open my shopping cart to check product price")]
        public void GivenUserOpenMyShoppingCartToCheckProductPrice(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            cartpage = new CartPage(driver);
            cartpage.VerifyItemOnCart(data.productName, price);
            cartpage.clickonCheckout();
        }

        [Given(@"User enter checkout information")]
        public void GivenUserEnterCheckoutInformation(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            checkoutuserinfopage = new CheckoutUserInformationPage(driver);
            checkoutuserinfopage.FillUserInformation(data.firstName, data.lastName,"411057");
        }

        [Then(@"User check for product and price in checkout overview")]
        public void ThenUserCheckForProductAndPriceInCheckoutOverview(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            checkoutOverviewPage = new CheckoutOverviewPage(driver);
            checkoutOverviewPage.VerifyUserCheckoutOverview(data.productName, price);
        }
    }
}
