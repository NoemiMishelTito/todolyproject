using OpenQA.Selenium;
using todolyproject.src.code.control;

namespace todolyproject.src.code.page
{
    public class loginpage
    {

        public Button loginBtn = new Button(By.XPath("//img[@src=\"/Images/design/pagelogin.png\"]"));
        public TextBox emailTxtBox = new TextBox(By.Id("ctl00_MainContent_LoginControl1_TextBoxEmail"));
        public TextBox pwTxtBox = new TextBox(By.Id("ctl00_MainContent_LoginControl1_TextBoxPassword"));
        public Button startLogin = new Button(By.Id("ctl00_MainContent_LoginControl1_ButtonLogin"));
        public Button logoutBtn = new Button(By.Id("ctl00_HeaderTopControl1_LinkButtonLogout"));

        public void LoginRedirection()
        {
            loginBtn.Click();
        }
        public void LoginSession(String email, String pw)
        {
            emailTxtBox.SetText(email);
            pwTxtBox.SetText(pw);
            startLogin.Click();
        }
        public Boolean VerifyPage()
        {
            return logoutBtn.IsControlDisplayed();
        }
    }
}
