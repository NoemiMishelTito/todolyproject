using OpenQA.Selenium;
using todolyproject.src.code.control;

namespace todolyproject.src.code.page
{
    public class ManageProjectPage
    {

        public Button optionBtn= new Button(By.XPath("//li[@id='ItemId_4102319']//td[@class='ItemIndicator']"));
        public Button iconBtn = new Button(By.CssSelector("span.IconFrame[iconid='3']"));
        public Button listIconElement = new Button(By.XPath("//li[@id='ItemId_4102319']//div[@id='ListIcon' and contains(@style, 'alert.png')]"));
        public Button openPro = new Button(By.Id("ItemId_4102319"));
        public Label nameProject = new Label(By.ClassName("CurrentProjectTitle"));

        public void OpenProject()
        {
            openPro.Click();
        }

        public bool VerifyProject()
        {
            return nameProject.IsControlDisplayed();
        }
        public void ModifyProjectIcon()
        {

            optionBtn.mouseOver();
            if (optionBtn.IsControlDisplayed())
            {
                optionBtn.Click();
                iconBtn.Click();
            }
        }
        public bool VerifyIconModify()
        {
            string styleAttributeValue = listIconElement.GetAttribute();
            bool isAlertIcon = styleAttributeValue.Contains("alert.png");
            return isAlertIcon;
        }
    }
}
