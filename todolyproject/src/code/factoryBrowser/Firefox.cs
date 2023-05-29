using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace todolyproject.src.code.factoryBrowser
{
    public class Firefox : IBrowser
    {
        public IWebDriver Create()
        {
            Console.WriteLine("Setup");
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            IWebDriver driver = new FirefoxDriver(path + "/resources/driver/mgeckodriver.exe");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
