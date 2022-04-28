﻿using OpenQA.Selenium;
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

        //Method to Verify user added prodcut and price of product
        //param: itemName = product to check, price = price of product
        public bool VerifyUserCheckoutOverview(string itemName, string price)
        {
            bool flag = false;
            IList<IWebElement> list = driver.FindElements(By.XPath($"//div[@class='cart_item_label']"));
            foreach (IWebElement ls in list)
            {
                IWebElement inventory_item_name = driver.FindElement(By.XPath($"//div[@class='inventory_item_name']"));
                IWebElement priceValue = driver.FindElement(By.XPath($"//div[@class='item_pricebar']"));
                if (inventory_item_name.Text.Contains(itemName) && priceValue.Text.Contains(price))
                {
                    flag = true;
                    break;
                }
            }
            common.ClickOnElement(driver.FindElement(By.Id("finish")));
            return flag;
        }
    }
}