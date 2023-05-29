using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using todolyproject.src.code.control;

namespace todolyproject.src.code.page
{

    public class ManageTasks
    {

        public Button task1 = new Button(By.Id("ItemId_11152068"));
        public Button SetDueDateBtn = new Button(By.XPath("//div[contains(text(), 'Set Due Date')]"));
        public Button dateBtn = new Button(By.CssSelector("#ItemId_11152068 .ItemDueDateInner"));
        public Calendar hour = new Calendar(By.CssSelector(".ui_tpicker_hour_slider"));
        public Calendar minute = new Calendar(By.CssSelector(".ui_tpicker_minute_slider"));
        public Calendar date1 = new Calendar(By.LinkText("29"));
        public Calendar date2 = new Calendar(By.LinkText("31"));
        public Calendar item = new Calendar(By.CssSelector(".ui-state-focus"));
        public Button saveBtn = new Button(By.CssSelector("#EditDueDate11152068 #LinkShowDueDateSave"));
        private Calendar fdate1 = new Calendar(By.CssSelector("li#ItemId_11152068 div.ItemDueDateInner.ItemDueDateInner_pp2"));
        private Calendar fdate2 = new Calendar(By.CssSelector("li#ItemId_11152068 div.ItemDueDateInner.ItemDueDateInner_pp0"));
        private Calendar date3;

        public void OpenCalendar()
        {
            task1.mouseOver();
            if (SetDueDateBtn.IsControlDisplayed())
            {
                SetDueDateBtn.Click();
                date3 = date1;
            } else if (dateBtn.IsControlDisplayed())
            {
                dateBtn.Click();
                date3 = date2;
            }
        }

        public void SetDate()
        {
            date3.Click();
            hour.SetHour();
            item.StablishTime();
            hour.Click();
            minute.SetMinute();
            item.StablishTime();
            minute.Click();
            saveBtn.Click();
        }

        public bool VerifyDate()
        {
            if (fdate1.IsControlDisplayed())
            {
                return true;
            }else if (fdate2.IsControlDisplayed())
            {
                return true;
            }
            else { return false; }
        }

    }
}
