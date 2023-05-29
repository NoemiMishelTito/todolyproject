using OpenQA.Selenium;
using todolyproject.src.code.control;
using todolyproject.src.code.page;

namespace todolyproject.src.code.test
{
    [TestClass]
    public class ModifyIcon : TestBase
    {
        loginpage gologin = new loginpage();
        ManageProjectPage icon = new ManageProjectPage();

        [TestMethod]
        public void ModiFyIcon()
        {
            gologin.LoginRedirection();
            gologin.LoginSession("mt_tester@test.com", "mt_tester");
            Assert.IsTrue(gologin.VerifyPage(), "ERROR !! the login was not successfully, review credentials please");
            icon.ModifyProjectIcon();
            Assert.IsTrue(icon.VerifyIconModify(), "The icon was not changed correctly");
        }

    }
}
