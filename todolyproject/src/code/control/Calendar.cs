using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace todolyproject.src.code.control
{
    public class Calendar : Control
    {
        public Calendar(By locator) : base(locator)
        {
        }

        public void SetHour()
        {
            FindControl();
            Actions builder = new Actions(session.Session.Instance().GetBrowser());
            builder.MoveToElement(control).ClickAndHold().Perform();
        }
        public void SetMinute()
        {
            FindControl();
            Actions builder = new Actions(session.Session.Instance().GetBrowser());
            builder.MoveToElement(control).ClickAndHold().Perform();
        }

        public void StablishTime()
        {
            FindControl();
            Actions builder = new Actions(session.Session.Instance().GetBrowser());
            builder.MoveToElement(control).Release().Perform();
        }
    }
}
