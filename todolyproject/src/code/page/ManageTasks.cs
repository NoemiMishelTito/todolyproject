using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;
using todolyproject.src.code.control;

namespace todolyproject.src.code.page
{

    public class ManageTasks
    {
        // CALENDAR
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
        // PRIORITY
        public Button menuBtn = new Button(By.CssSelector("#ItemId_11152068 .ItemMenu"));
        public Item priority1 = new Item(By.CssSelector(".PrioFrame[iconid='1']"));
        public Item priority2 = new Item(By.CssSelector(".PrioFrame[iconid='2']"));
        public Item priority3 = new Item(By.CssSelector(".PrioFrame[iconid='3']"));
        public Item priority4 = new Item(By.CssSelector(".PrioFrame[iconid='4']"));
        public Label taskcolor = new Label(By.CssSelector("[itemid='11152068'] .ItemContentDiv"));
        // TASKS
        public Item task1 = new Item(By.CssSelector("li#ItemId_11152068"));
        public Item task2 = new Item(By.CssSelector("li#ItemId_11152272"));
        public Item task3 = new Item(By.CssSelector("li#ItemId_11152273"));
        public Item task4 = new Item(By.CssSelector("li#ItemId_11152274"));
        public DragHandle grippyImage = new DragHandle(By.CssSelector("img[src='/Images/grippy.png'][class='handle DragHandler']"));

        public void SelectPriority(String option)
        {
            task1.mouseOver();
            menuBtn.Click();

            switch (option)
            {
                case "1":
                    priority1.Click();
                    break;
                case "2":
                    priority2.Click();
                    break;
                case "3":
                    priority3.Click();
                    break;
                case "4":
                    priority4.Click();
                    break;
                default:
                    break;
            }

        }

        public bool CompareCssValue(string expectedValue)
        {
            string actualValue = taskcolor.GetColor();
            return actualValue.Equals(expectedValue);
        }

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

        public void MoveATask()
        {
            grippyImage.FindControl2();
            grippyImage.DragandDrop(grippyImage, task4);
        }

    }
}
