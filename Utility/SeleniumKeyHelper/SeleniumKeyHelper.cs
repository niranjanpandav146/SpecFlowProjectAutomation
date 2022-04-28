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
            element.Click();
        }
        // Common method to enter text on UI Element 
        //Param : UI element as type IWebelement
        public void EnterTextToElement(IWebElement element,string text)
        {
            element.SendKeys(text);
        }
        // Common method to get text on UI Element 
        //Param : UI element as type IWebelement
        public string GetElementText(IWebElement element)
        {
            return element.Text;
        }      
    }
}
