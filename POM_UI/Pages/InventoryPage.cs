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
        private By inventory_items = By.XPath($"//div[@class='inventory_item']");
        private By inventory_items_name = By.XPath($"//div[@class='inventory_item_name']");

        #endregion


        #region Methods
        //Method to Select product based on text provided
        //param: Text = Prodcut name
        public string SelectItemforShopping(string text)
        {           
            string price_bar = "";
            IList<IWebElement> list = driver.FindElements(inventory_items);
            foreach (IWebElement ls in list)
            {
                IWebElement inventory_item_name = driver.FindElement(inventory_items_name);
                if (inventory_item_name.Text.Contains(text))
                {
                    price_bar = inventory_item_name.FindElement(By.XPath($"//div[@class='inventory_item_price']")).Text;
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
            common.ClickOnElement(driver.FindElement(By.XPath($"//a[@class='shopping_cart_link']")));
        }
        #endregion

    }
}
