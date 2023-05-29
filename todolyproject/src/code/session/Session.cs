using OpenQA.Selenium;
using todolyproject.src.code.factoryBrowser;

namespace todolyproject.src.code.session
{
    public class Session
    {
        // attribute of the same type
        private static Session instance = null;
        private IWebDriver browser;
        // private constructor
        private Session()
        {
            browser = FactoryBrowser.Make("chrome").Create();
        }

        // public static method for global access
        public static Session Instance()
        {
            if (instance == null)
            {
                instance = new Session();
            }
            return instance;
        }

        public void CloseBrowser()
        {
            Console.WriteLine("CloseBrowser");
            instance = null;
            browser.Quit();
        }

        public IWebDriver GetBrowser()
        {
            return browser;
        }

        public string GetCurrentUrl()
        {
            return browser.Url;
        }
    }
}
