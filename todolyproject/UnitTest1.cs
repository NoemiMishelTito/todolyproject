using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace todolyproject
{
    // This file was created to execute all the test cases, it will use as a guide to restructure it properly
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
        public void ModifyTheIconOfAnExistingProject()
        {
            Console.WriteLine("[TCs-1] Project – Modificar el icono de un proyecto existente\t7");
            Login();
            IWebElement itemIndicator = driver.FindElement(By.XPath("//li[@id='ItemId_4102319']//td[@class='ItemIndicator']"));
            // Mouse over element
            Actions actions = new Actions(driver);
            actions.MoveToElement(itemIndicator).Perform();
            IWebElement optionsImage = itemIndicator.FindElement(By.XPath(".//img[@title='Options']"));
            Assert.IsTrue(optionsImage.Displayed, "The Options icon is not displayed.");
            optionsImage.Click();
            // Select one Icon
            driver.FindElement(By.CssSelector("span.IconFrame[iconid='3']")).Click();
            // Verify if the icon was modify
            IWebElement listItemElement = driver.FindElement(By.Id("ItemId_4102319"));
            IWebElement listIconElement = listItemElement.FindElement(By.Id("ListIcon"));
            string styleAttributeValue = listIconElement.GetAttribute("style");
            bool isAlertIcon = styleAttributeValue.Contains("alert.png");
            Assert.IsTrue(isAlertIcon, "The icon was not changed correctly");
        }

        [TestMethod]
        public void SetDueDataForATask()
        {
            Console.WriteLine("[TCs-2] Project – Establecer fecha límite a una tarea");
            Login();
            driver.FindElement(By.Id("ItemId_4102319")).Click();
            Thread.Sleep(1000);
            // Verify -> 'Options' icon works correctly
            Assert.IsTrue((driver.FindElement(By.ClassName("CurrentProjectTitle")).Text.Equals("Project-Mojix")), "The project did not open correctly");
            IWebElement task1 = driver.FindElement(By.Id("ItemId_11152068"));
            // mouse over task
            Actions actions = new Actions(driver);
            actions.MoveToElement(task1).Perform();
            Thread.Sleep(1000);
            // Check if "ItemDueDate" class has a different text than 'Set Due Date'
            string text = driver.FindElement(By.CssSelector("#ItemId_11152068 .ItemDueDateInner")).Text;
            if (text == "Set Due Date")
            {
                driver.FindElement(By.XPath("//div[contains(text(), 'Set Due Date')]")).Click();
            }
            else
            {
                driver.FindElement(By.CssSelector("#ItemId_11152068 .ItemDueDateInner")).Click();
            }
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("31")).Click();
            //Choose hours
            {
                var hours = driver.FindElement(By.CssSelector(".ui_tpicker_hour_slider"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(hours).ClickAndHold().Perform();
            }
            {
                var hours = driver.FindElement(By.CssSelector(".ui-state-focus"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(hours).Release().Perform();
            }
            driver.FindElement(By.CssSelector(".ui_tpicker_hour_slider")).Click();

            //Choose minutes
            {
                var min = driver.FindElement(By.CssSelector(".ui_tpicker_minute_slider"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(min).ClickAndHold().Perform();
            }
            {
                var min = driver.FindElement(By.CssSelector(".ui-state-focus"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(min).Release().Perform();
            }
            driver.FindElement(By.CssSelector(".ui_tpicker_minute_slider")).Click();

            //Save due date
            driver.FindElement(By.CssSelector("#EditDueDate11152068 #LinkShowDueDateSave")).Click();
        }

        [TestMethod]
        public void SetPriorityToATask()
        {
            Console.WriteLine("[TCs-3] Project – Establecer prioridad a una tarea");
            Login();
            driver.FindElement(By.Id("ItemId_4102319")).Click();
            Thread.Sleep(1000);
            // Verify -> 'Options' icon works correctly
            Assert.IsTrue((driver.FindElement(By.ClassName("CurrentProjectTitle")).Text.Equals("Project-Mojix")), "The project did not open correctly");
            IWebElement task1 = driver.FindElement(By.Id("ItemId_11152068"));
            // Mouse over task
            Actions actions = new Actions(driver);
            actions.MoveToElement(task1).Perform();
            Thread.Sleep(1000);
            IWebElement optionsImage = driver.FindElement(By.CssSelector("#ItemId_11152068 .ItemMenu"));
            Assert.IsTrue(optionsImage.Displayed, "The Options icon is not displayed.");
            optionsImage.Click();

            // Select priority with iconid = 1
            driver.FindElement(By.CssSelector(".PrioFrame[iconid='1']")).Click();
            IWebElement priority = driver.FindElement(By.Id("ItemId_11152068"));
            IWebElement taskcontent = driver.FindElement(By.CssSelector("[itemid='11152068'] .ItemContentDiv"));
            Thread.Sleep(2000);
            Assert.AreEqual("rgba(255, 51, 0, 1)", taskcontent.GetCssValue("color"), "The color style for priority 1 is not red");

            // Select priority with iconid = 2
            actions.MoveToElement(task1).Perform();
            driver.FindElement(By.CssSelector("#ItemId_11152068 .ItemMenu")).Click();
            driver.FindElement(By.CssSelector(".PrioFrame[iconid='2']")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("rgba(22, 139, 184, 1)", taskcontent.GetCssValue("color"), "The color style for priority 1 is not blue");

            // Select priority with iconid = 3
            actions.MoveToElement(task1).Perform();
            driver.FindElement(By.CssSelector("#ItemId_11152068 .ItemMenu")).Click();
            driver.FindElement(By.CssSelector(".PrioFrame[iconid='3']")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("rgba(81, 153, 45, 1)", taskcontent.GetCssValue("color"), "The color style for priority 1 is not green");

            // Select priority with iconid = 4
            actions.MoveToElement(task1).Perform();
            driver.FindElement(By.CssSelector("#ItemId_11152068 .ItemMenu")).Click();
            driver.FindElement(By.CssSelector(".PrioFrame[iconid='4']")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("rgba(0, 0, 0, 1)", taskcontent.GetCssValue("color"), "The color style for priority 1 is not black");

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