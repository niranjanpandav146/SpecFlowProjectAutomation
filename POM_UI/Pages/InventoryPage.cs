using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectAutomation.Base;
using Utility.SeleniumKeyHelper;

namespace POM_UI.Pages
{
    public class InventoryPage : BasePage
    {  
        #region UI Objects
        private IList<IWebElement> inventoryItems => DriverContext.Driver.FindElements(By.ClassName("inventory_item"));
        private IWebElement inventoryItemsName => DriverContext.Driver.FindElement(By.ClassName("inventory_item_name"));       
        private IWebElement inventoryItemPrice => DriverContext.Driver.FindElement(By.ClassName("inventory_item_price"));
        private IWebElement linkShoppingCart => DriverContext.Driver.FindElement(By.ClassName("shopping_cart_link"));
        #endregion

        #region Methods
        //Method to Select product based on text provided
        //param: Text = Prodcut name
        public string SelectItemforShopping(string text)
        {
            string price_bar = "";
            try
            {                
                IList<IWebElement> list = inventoryItems;
                foreach (IWebElement ls in list)
                {
                    if (inventoryItemsName.Text.Contains(text))
                    {
                        price_bar = inventoryItemPrice.Text;
                        IWebElement addToCart = DriverContext.Driver.FindElement(By.XPath($"//button[@id='{"add-to-cart-" + text.ToLower().Replace(" ", "-")}']"));
                        SeleniumKeyHelper.ClickOnElement(addToCart);                      
                        break;
                    }                
                }               
            }
            catch (Exception)
            {
                Assert.Fail("Unable to Select Product from Inventory");              
            }
            return price_bar;

        }
        //Method to click over Cart
        public CartPage ClickCart()
        {
            try
            {
                SeleniumKeyHelper.ClickOnElement(linkShoppingCart);
            }
            catch(Exception)
            {
                Assert.Fail("Unable to Click on Cart");
            }
            return GetInstance<CartPage>();
        }
        #endregion

    }
}
