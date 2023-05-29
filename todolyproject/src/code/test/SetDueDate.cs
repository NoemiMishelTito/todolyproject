using OpenQA.Selenium;
using todolyproject.src.code.control;
using todolyproject.src.code.page;

namespace todolyproject.src.code.test
{
    [TestClass]
    public class SetDueDate : TestBase
    {
        loginpage gologin = new loginpage();
        ManageProjectPage project = new ManageProjectPage();
        ManageTasks tasks = new ManageTasks();

        [TestMethod]
        public void SetDueDateForATask()
        {
            gologin.LoginRedirection();
            gologin.LoginSession("mt_tester@test.com", "mt_tester");
            Assert.IsTrue(gologin.VerifyPage(), "ERROR !! the login was not successfully, review credentials please");
            project.OpenProject();
            tasks.OpenCalendar();
            tasks.SetDate();
            Assert.IsTrue(tasks.VerifyDate(), "There was an error and the date was not modified");
        }

    }
}
