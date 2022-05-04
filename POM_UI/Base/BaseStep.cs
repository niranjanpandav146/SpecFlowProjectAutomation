using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SpecFlowProjectAutomation.Base
{
    public abstract class BaseStep : Base
    {
        public static void OpenBrowser(string browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    DriverContext.Driver = new ChromeDriver();                   
                    break;
                case "firefox":
                    DriverContext.Driver = new FirefoxDriver(GetFirefoxoptions());
                    break;                  
            }
        }

        private static FirefoxDriverService GetFirefoxoptions()
        {
            return FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName) + @"\Support", "geckodriver.exe");
        }

        public virtual void NavigateSite(string url)
        {
            DriverContext.Driver.Manage().Window.Maximize();
            DriverContext.Driver.Navigate().GoToUrl(url);  
            
        }
    }
}
