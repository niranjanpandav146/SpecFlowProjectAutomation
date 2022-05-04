using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectAutomation.Base;
using Utility.SeleniumKeyHelper;

namespace POM_UI.Pages
{
    public class CartPage : BasePage
    {       
        #region UI Objects
        private IList<IWebElement> cartItems => DriverContext.Driver.FindElements(By.ClassName("cart_item"));
        private IWebElement inventoryItemName => DriverContext.Driver.FindElement(By.ClassName("inventory_item_name"));
        private IWebElement inventory_item_price => DriverContext.Driver.FindElement(By.ClassName("inventory_item_price"));
        private IWebElement buttonCheckout => DriverContext.Driver.FindElement(By.Id("checkout"));
        #endregion  

        #region Methods

        //Method to Verify user's cart items
        //param: text = product to check, price = price of product
        public void VerifyItemOnCart(string productName, string price)
        {
            try
            {
                string cartItemPrice = "";
                IList<IWebElement> list = cartItems;
                foreach (IWebElement ls in list)
                {
                    if (inventoryItemName.Text.Contains(productName))
                    {
                        cartItemPrice = inventory_item_price.Text;
                        break;
                    }
                }
                Assert.That(price, Is.EqualTo(cartItemPrice));
                //Assert.eq(price, cartItemPrice);               
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message,"Product Price Not Verified");             
            }

        }
        //Method to click on checkout button
        public CheckoutUserInformationPage ClickonCheckout()
        {
            SeleniumKeyHelper.ClickOnElement(buttonCheckout);
            return GetInstance<CheckoutUserInformationPage>();
        }

        #endregion

    }
}
