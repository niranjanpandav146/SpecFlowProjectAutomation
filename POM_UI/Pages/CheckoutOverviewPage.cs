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
    public class CheckoutOverviewPage
    {
        IWebDriver driver;
        SeleniumKeyHelper common;
        public CheckoutOverviewPage(IWebDriver driver)
        {
            this.driver = driver;
            common = new SeleniumKeyHelper();
        }

        #region UI objects
        private IList<IWebElement> LabelcartItemLabel => driver.FindElements(By.ClassName("cart_item_label"));
        private IWebElement InventoryItemName => driver.FindElement(By.ClassName("inventory_item_name"));
        private IWebElement PriceValue => driver.FindElement(By.ClassName("item_pricebar"));
        private IWebElement BtnFinish => driver.FindElement(By.Id("finish"));
        #endregion

        #region Methods
        //Method to Verify user added prodcut and price of product
        //param: itemName = product to check, price = price of product
        public void VerifyUserCheckoutOverview(string itemName, string price)
        {
            try
            {
                bool flag = false;
                IList<IWebElement> list = LabelcartItemLabel;
                foreach (IWebElement ls in list)
                {
                    if (InventoryItemName.Text.Contains(itemName) && PriceValue.Text.Contains(price))
                    {
                        flag = true;
                        break;
                    }
                }
                Assert.IsTrue(flag,"Product Verified with Price");
                common.ClickOnElement(BtnFinish);                
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message,"Unable to Verify User Checkout Overview");
            }
            
        }
        #endregion
    }
}
