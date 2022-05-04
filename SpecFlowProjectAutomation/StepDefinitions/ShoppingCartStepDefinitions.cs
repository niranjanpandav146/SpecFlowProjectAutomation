using POM_UI.Pages;
using SpecFlowProjectAutomation.Base;
using TechTalk.SpecFlow.Assist;


namespace SpecFlowProjectAutomation.StepDefinitions
{
    [Binding]
    public class ShoppingCartStepDefinitions :BaseStep
    {      
        public string price = "";

        [Given(@"User navigate to saucedemo application")]
        public void GivenUserNavigateToSaucedemoApplication(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            try
            {
                OpenBrowser(data.browserName);
                NavigateSite(data.url);                
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [Given(@"User login to saucedemo application")]
        public void GivenUserLoginToSaucedemoApplication(Table table)
        {
            dynamic data = table.CreateDynamicInstance();            
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage =CurrentPage.As<LoginPage>().LoginToApplication("user-name","password","submit", data.userName, data.password);            
        }

        [Given(@"User add product to shopping cart")]
        public void GivenUserAddProductToShoppingCart(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            price=CurrentPage.As<InventoryPage>().SelectItemforShopping(data.productName);
            CurrentPage=CurrentPage.As<InventoryPage>().ClickCart();
        }

        [Given(@"User open my shopping cart to check product price")]
        public void GivenUserOpenMyShoppingCartToCheckProductPrice(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            CurrentPage.As<CartPage>().VerifyItemOnCart(data.productName, price);
            CurrentPage =CurrentPage.As<CartPage>().ClickonCheckout();
        }

        [Given(@"User enter checkout information")]
        public void GivenUserEnterCheckoutInformation(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            CurrentPage = CurrentPage.As<CheckoutUserInformationPage>().FillUserInformation(data.firstName, data.lastName,"411057");
        }

        [Then(@"User check for product and price in checkout overview")]
        public void ThenUserCheckForProductAndPriceInCheckoutOverview(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            CurrentPage.As<CheckoutOverviewPage>().VerifyUserCheckoutOverview(data.productName, price);
        }
    }
}
