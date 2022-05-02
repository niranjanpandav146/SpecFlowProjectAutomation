using NUnit.Framework;
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
        private IWebElement Inventory_item_price => driver.FindElement(By.ClassName("inventory_item_price"));
        private IWebElement ButtonCheckout => driver.FindElement(By.Id("checkout"));
        #endregion  

        #region Methods

        //Method to Verify user's cart items
        //param: text = product to check, price = price of product
        public void VerifyItemOnCart(string text, string price)
        {
            try
            {
                string cartItemPrice = "";
                IList<IWebElement> list = Cart_items;
                foreach (IWebElement ls in list)
                {
                    if (InventoryItemName.Text.Contains(text))
                    {
                        cartItemPrice = Inventory_item_price.Text;
                        break;
                    }
                }
                Assert.AreEqual(price, cartItemPrice,"Product and Price Verified from Cart");               
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message,"Product Price Not Verified");
                throw;
            }

        }
        //Method to click on checkout button
        public void ClickonCheckout()
        {
            common.ClickOnElement(ButtonCheckout);
        }

        #endregion

    }
}
