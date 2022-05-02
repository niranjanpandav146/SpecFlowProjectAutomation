using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectAutomation.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;


        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        public IWebDriver setup(string browserName)
        {         
            driver = SetupBrowser(browserName);          
            _scenarioContext.Set(driver, "WebDriver");
            driver.Manage().Window.Maximize();
            return driver;
        }

        public IWebDriver SetupBrowser(string browserName)
        {
            if (browserName.ToLower() == "chrome")
                return new ChromeDriver();
            if (browserName.ToLower() == "firefox")
                return new FirefoxDriver(getFirefoxoptions());
            
            return new ChromeDriver();
        }

        private static FirefoxDriverService getFirefoxoptions()
        {            
            return FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName)+@"\Support", "geckodriver.exe");
        }

    }
}
