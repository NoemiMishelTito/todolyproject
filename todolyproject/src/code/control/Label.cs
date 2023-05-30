using OpenQA.Selenium;

namespace todolyproject.src.code.control
{
    public class Label : Control
    {
        public Label(By locator) : base(locator)
        {
        }

        public string GetColor()
        {
            FindControl();
            return control.GetCssValue("color");
        }
    }
}
