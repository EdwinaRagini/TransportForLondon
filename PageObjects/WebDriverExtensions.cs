using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PageObjects.Pages;

namespace PageObjects
{


    public static class WebDriverExtensions
    {
        

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            IWait<IWebDriver> wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void AccecptCookies(this IWebDriver driver)
        {
            try
            {

                driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Click();

                driver.FindElement(By.XPath("//h2[text()='Your cookie settings are saved']/parent::div/following-sibling::div/button/strong")).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cookies not enabled");
            }
        }


        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(timeout),
                    TimeSpan.FromMilliseconds(50));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                return element;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static IWebElement Get(this IWebDriver driver, By by)
        {
            return driver.FindElement(@by);
        }
   
        public static void GoTo(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void SubmitAndWait(this IWebDriver driver, IWebElement element)
        {
            try
            {
                element.Click();
                driver.WaitForPageToLoad();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static bool CheckElementExists(this IWebDriver driver, string id)
        {
            try
            {
                driver.FindElement(By.Id(id));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
