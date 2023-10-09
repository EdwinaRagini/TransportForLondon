using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLFramework.Extensions
{
    public static class WebElementExtensions
    {
        public static void SendKeys(this IWebElement element, string value)
        {
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.SendKeys(value);
            element.SendKeys(Keys.Tab);
        }

        public static void SelectTextFromDropDown(this IWebElement element, string value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(value);
        }

        public static string GetText(this IWebElement element) => element.Text;

        public static bool ElementDisplayed(this IWebElement element) => element.Displayed;
    }
}
