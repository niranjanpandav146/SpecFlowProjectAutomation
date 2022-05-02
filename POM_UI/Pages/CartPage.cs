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
        
        private IList<IWebElement> Cart_items => driver.FindElements(By.ClassName("cart_item"));
        private IWebElement InventoryItemName => driver.FindElement(By.ClassName("inventory_item_name"));
        private IWebElement inventory_item_price => driver.FindElement(By.ClassName("inventory_item_price"));
        private IWebElement buttonCheckout => driver.FindElement(By.Id("checkout"));
        #endregion  

        #region Methods

        //Method to Verify user's cart items
        //param: text = product to check, price = price of product
        public void VerifyItemOnCart(string text, string price)
        {
            string cartItemPrice = "";
            IList<IWebElement> list = Cart_items;
            foreach (IWebElement ls in list)
            {              
                if (InventoryItemName.Text.Contains(text))
                {
                    cartItemPrice = inventory_item_price.Text;
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
            common.ClickOnElement(buttonCheckout);
        }

        #endregion

    }
}
