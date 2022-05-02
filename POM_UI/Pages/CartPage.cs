using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.SeleniumKeyHelper;

namespace POM_UI.Pages
{
    public class CartPage
    {
        IWebDriver driver;
        SeleniumKeyHelper common;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            common = new SeleniumKeyHelper();
        }

        #region UI Objects
        private By cart_items = By.XPath($"//div[@class='cart_item']");        
        private By inventory_item_price = By.XPath($"//div[@class='inventory_item_price']");
        #endregion  

        #region Methods

        //Method to Verify user's cart items
        //param: text = product to check, price = price of product
        public void VerifyItemOnCart(string text, string price)
        {
            string cartItemPrice = "";
            IList<IWebElement> list = driver.FindElements(cart_items);
            foreach (IWebElement ls in list)
            {
                IWebElement inventory_item_name = driver.FindElement(By.XPath($"//div[@class='inventory_item_name']"));
                if (inventory_item_name.Text.Contains(text))
                {
                    cartItemPrice = inventory_item_name.FindElement(inventory_item_price).Text;
                    break;
                }
            }
            if (price.Equals(cartItemPrice))
            {
                Console.Write("Value Same");
            }
        }
        //Method to click on checkout button
        public void clickonCheckout()
        {
            common.ClickOnElement(driver.FindElement(By.Id("checkout")));
        }

        #endregion

    }
}
