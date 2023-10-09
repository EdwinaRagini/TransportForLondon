using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TFLFramework.Extensions
{
    public static class WebDriverExtensions
    {


        public static bool DoesElementExist(this IWebDriver driver, string id)
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

        public static void AccecptCookies(this IWebDriver driver)
        {
            try
            {

                driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Click();

                driver.FindElement(By.XPath("//h2[text()='Your cookie settings are saved']/parent::div/following-sibling::div/button/strong")).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No Cookies Enabled");
            }

        }

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(120)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static IWebElement WaitForElementToExist(this IWebDriver driver, By by, int timeout = 30)
        {
            try
            {
                var wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(timeout),
                    TimeSpan.FromMilliseconds(50));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                return element;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static IWebElement GetElement(this IWebDriver driver, By by)
        {
            return driver.FindElement(@by);
        }

        public static void NavigateTo(this IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }


        public static void SubmitAndWait(this IWebDriver driver, IWebElement locator)
        {
            try
            {
                locator.Click();
                driver.WaitForPageToLoad();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
