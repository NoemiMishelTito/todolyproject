using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace todolyproject.src.code.factoryBrowser
{
    public class Edge : IBrowser
    {
        public IWebDriver Create()
        {
            Console.WriteLine("Setup");
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            IWebDriver driver = new EdgeDriver(path + "/resources/driver/msedgedriver.exe");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
