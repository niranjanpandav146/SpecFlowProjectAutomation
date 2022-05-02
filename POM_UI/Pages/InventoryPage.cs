using OpenQA.Selenium;
using Utility.SeleniumKeyHelper;

namespace POM_UI.Pages
{
    public class InventoryPage
    {
        IWebDriver driver;
        SeleniumKeyHelper common;
        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
            common = new SeleniumKeyHelper();
        }


        #region UI objects
        private IList<IWebElement> Inventory_items => driver.FindElements(By.ClassName("inventory_item"));
        private IWebElement Inventory_items_name => driver.FindElement(By.ClassName("inventory_item_name"));       
        private IWebElement Inventory_item_price => driver.FindElement(By.ClassName("inventory_item_price"));
        private IWebElement LinkShoppingCart => driver.FindElement(By.ClassName("shopping_cart_link"));
        #endregion

        #region Methods
        //Method to Select product based on text provided
        //param: Text = Prodcut name
        public string SelectItemforShopping(string text)
        {           
            string price_bar = "";
            IList<IWebElement> list = Inventory_items;
            foreach (IWebElement ls in list)
            {                
                if (Inventory_items_name.Text.Contains(text))
                {
                    price_bar = Inventory_item_price.Text;
                    IWebElement addToCart = driver.FindElement(By.XPath($"//button[@id='{"add-to-cart-" + text.ToLower().Replace(" ","-")}']"));
                    common.ClickOnElement(addToCart);
                    break;
                }
            }
            return price_bar;
        }
        //Method to click over Cart
        public void ClickCart()
        {
            common.ClickOnElement(LinkShoppingCart);
        }
        #endregion

    }
}
