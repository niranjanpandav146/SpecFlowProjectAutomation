using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.SeleniumKeyHelper
{
    public class SeleniumKeyHelper
    {
        // Common method to click on UI Element 
        //Param : UI element as type IWebelement
        public void ClickOnElement(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        // Common method to enter text on UI Element 
        //Param : UI element as type IWebelement
        public void EnterTextToElement(IWebElement element,string text)
        {
            try
            {
                element.SendKeys(text);
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        // Common method to get text on UI Element 
        //Param : UI element as type IWebelement
        public string GetElementText(IWebElement element)
        {
            try
            {
                return element.Text;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }      
    }
}
