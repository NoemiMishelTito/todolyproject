using OpenQA.Selenium;
using todolyproject.src.code.control;
using todolyproject.src.code.page;

namespace todolyproject.src.code.test
{
    [TestClass]
    public class TaOrderTasks : TestBase
    {
        loginpage gologin = new loginpage();
        ManageProjectPage project = new ManageProjectPage();
        ManageTasks tasks = new ManageTasks();

        [TestMethod]
        public void moveTasks()
        {
            gologin.LoginRedirection();
            gologin.LoginSession("mt_tester@test.com", "mt_tester");
            Assert.IsTrue(gologin.VerifyPage(), "ERROR !! the login was not successfully, review credentials please");
            project.OpenProject();
            Assert.IsTrue(project.VerifyProject(), "There was an error opening the folder");
            tasks.MoveATask();
        }

    }
}
