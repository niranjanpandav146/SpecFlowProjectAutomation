using NUnit.Framework;
using OpenQA.Selenium;

namespace Utility.SeleniumKeyHelper
{
    public static class SeleniumKeyHelper
    {
        // Common method to click on UI Element 
        //Param : UI element as type IWebelement
        public static void ClickOnElement(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Element Not Clicked" + ex.Message);
            }
            
        }
        // Common method to enter text on UI Element 
        //Param : UI element as type IWebelement
        public static void EnterTextToElement(IWebElement element,string text)
        {
            try
            {
                element.SendKeys(text);
            }
            catch (Exception ex)
            {
                Assert.Fail("Element Input Error " + ex.Message);
            }
        }
        // Common method to get text on UI Element 
        //Param : UI element as type IWebelement
        public static string GetElementText(IWebElement element)
        {
            string elementText = "";
            try
            {
                elementText= element.Text;
            }
            catch (Exception ex)
            {
                Assert.Fail("Element Text Error " + ex.Message);
            }
            return elementText;
        }      
    }
}
