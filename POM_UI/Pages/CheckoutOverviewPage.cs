using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProjectAutomation.Base;
using Utility.SeleniumKeyHelper;

namespace POM_UI.Pages
{
    public class CheckoutOverviewPage : BasePage
    {       
        #region UI Objects
        private IList<IWebElement> labelcartItem => DriverContext.Driver.FindElements(By.ClassName("cart_item_label"));
        private IWebElement inventoryItemName => DriverContext.Driver.FindElement(By.ClassName("inventory_item_name"));
        private IWebElement priceValue => DriverContext.Driver.FindElement(By.ClassName("item_pricebar"));
        private IWebElement btnFinish => DriverContext.Driver.FindElement(By.Id("finish"));
        #endregion

        #region Methods
        //Method to Verify user added prodcut and price of product
        //param: itemName = product to check, price = price of product
        public void VerifyUserCheckoutOverview(string productName, string price)
        {
            try
            {
                bool flag = false;
                IList<IWebElement> list = labelcartItem;
                foreach (IWebElement ls in list)
                {
                    if (inventoryItemName.Text.Contains(productName) && priceValue.Text.Contains(price))
                    {
                        flag = true;
                        break;
                    }
                }
                Assert.IsTrue(flag,"Product Verified with Price");
                SeleniumKeyHelper.ClickOnElement(btnFinish);                
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message,"Unable to Verify User Product On Checkout Overview");
            }            
        }
        #endregion
    }
}
