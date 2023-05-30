using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace todolyproject.src.code.control
{
    public class Item : Control
    {
        public Item(By locator) : base(locator)
        {
        }

        public void mouseOver()
        {
            FindControl();
            Actions actions = new Actions(session.Session.Instance().GetBrowser());
            actions.MoveToElement(control).Perform();
        }

        public string GetAttribute()
        {
            FindControl();
            return control.GetAttribute("style");
        }
    }
}
