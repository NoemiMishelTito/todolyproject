using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace todolyproject
{
    // This file was created to execute all the test cases, it will use ONLY as a guide to restructure it properly
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void OpenBrowser()
        {
            Console.WriteLine("Setup");
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + "/resources/driver/chromedriver.exe");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://todo.ly/");
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            Console.WriteLine("Clean");
            driver.Quit();
        }

        [TestMethod]
        public void TheOrderOfATaskmove()
        {
            Console.WriteLine("[TCs-4] Project – Modificar el orden de una tarea");
            Login();
            driver.FindElement(By.Id("ItemId_4102319")).Click();
            Thread.Sleep(1000);
            Assert.IsTrue((driver.FindElement(By.ClassName("CurrentProjectTitle")).Text.Equals("Project-Mojix")), "The project did not open correctly");
            Actions actions = new Actions(driver);

            IWebElement task1 = driver.FindElement(By.CssSelector("li#ItemId_11152068"));
            IWebElement task4 = driver.FindElement(By.CssSelector("li#ItemId_11152274"));
            IWebElement task2 = driver.FindElement(By.CssSelector("li#ItemId_11152272"));
            IWebElement task3 = driver.FindElement(By.CssSelector("li#ItemId_11152273"));

            IWebElement grippyImage1 = task1.FindElement(By.CssSelector("img[src='/Images/grippy.png'][class='handle DragHandler']"));
            actions.MoveToElement(grippyImage1).Perform();
            actions.DragAndDrop(grippyImage1, task4).Perform();

            IWebElement grippyImage2 = task4.FindElement(By.CssSelector("img[src='/Images/grippy.png'][class='handle DragHandler']"));
            actions.MoveToElement(grippyImage2).Perform();
            actions.DragAndDrop(grippyImage2, task2).Perform();
        }

        public void Login()
        {
            // click login button
            driver.FindElement(By.XPath("//img[@src=\"/Images/design/pagelogin.png\"]")).Click();
            // fill email textbox
            driver.FindElement(By.Id("ctl00_MainContent_LoginControl1_TextBoxEmail")).SendKeys("mt_tester@test.com");
            // fill password textbox
            driver.FindElement(By.Id("ctl00_MainContent_LoginControl1_TextBoxPassword")).SendKeys("mt_tester");
            // click login button
            driver.FindElement(By.Id("ctl00_MainContent_LoginControl1_ButtonLogin")).Click();
            // verify -> the logout button should be displayed
            Assert.IsTrue(driver.FindElement(By.Id("ctl00_HeaderTopControl1_LinkButtonLogout")).Displayed,
                "ERROR !! the login was not successfully, review credentials please");
        }

    }
}