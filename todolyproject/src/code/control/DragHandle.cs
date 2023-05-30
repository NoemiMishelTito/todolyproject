using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace todolyproject.src.code.control
{
    public class DragHandle : Control
    {
        public DragHandle(By locator) : base(locator)
        {
        }

        public void mouseOver()
        {
            FindControl();
            Actions actions = new Actions(session.Session.Instance().GetBrowser());
            actions.MoveToElement(control).Perform();
        }

        public void DragandDrop(DragHandle sourceElement, Control destinationElement)
        {
            sourceElement.FindControl2();
            destinationElement.FindControl2();
            Actions actions = new Actions(session.Session.Instance().GetBrowser());
            actions.DragAndDrop(sourceElement.GetElement(), destinationElement.GetElement()).Perform();
        }
    }
}
