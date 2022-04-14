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
        public void ClickOnElement(IWebElement element)
        {
            element.Click();
        }

        public void EnterTextToElement(IWebElement element,string text)
        {
            element.SendKeys(text);
        }

        public string GetElementText(IWebElement element)
        {
            return element.Text;
        }
    }
}
