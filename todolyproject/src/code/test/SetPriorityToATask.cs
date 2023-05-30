using OpenQA.Selenium;
using todolyproject.src.code.control;
using todolyproject.src.code.page;

namespace todolyproject.src.code.test
{
    [TestClass]
    public class SetPriorityToATask : TestBase
    {
        loginpage gologin = new loginpage();
        ManageProjectPage project = new ManageProjectPage();
        ManageTasks tasks = new ManageTasks();

        [TestMethod]
        public void SetPriority()
        {
            gologin.LoginRedirection();
            gologin.LoginSession("mt_tester@test.com", "mt_tester");
            Assert.IsTrue(gologin.VerifyPage(), "ERROR !! the login was not successfully, review credentials please");
            project.OpenProject();
            Assert.IsTrue(project.VerifyProject(), "There was an error opening the folder");
            tasks.SelectPriority("1");
            Assert.IsTrue(tasks.CompareCssValue("rgba(255, 51, 0, 1)"), "The color style for priority 1 is not red");
            tasks.SelectPriority("2");
            Assert.IsTrue(tasks.CompareCssValue("rgba(22, 139, 184, 1)"), "The color style for priority 1 is not blue");
            tasks.SelectPriority("3");
            Assert.IsTrue(tasks.CompareCssValue("rgba(81, 153, 45, 1)"), "The color style for priority 1 is not green");
            tasks.SelectPriority("4");
            Assert.IsTrue(tasks.CompareCssValue("rgba(0, 0, 0, 1)"), "The color style for priority 1 is not black");
        }

    }
}
