using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLFramework.Drivers
{
    public class Driver
    {
        public static bool HeadlessMode { get; private set; }
        public Driver(BrowserTypes browserType) => GoToBrowser(browserType);

        public IWebDriver Browser { get; private set; }

        private void GoToBrowser(BrowserTypes browser)
        {
            switch (browser)
            {
                case BrowserTypes.Chrome:
                    {
                        Browser = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
                        Browser.Manage().Window.Maximize();
                        break;
                    }
                case BrowserTypes.HeadLessChrome:
                    {
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("headless");
                        chromeOptions.AddArguments("--lang=en-US");
                        Browser = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions);
                        HeadlessMode = true;
                        break;
                    }

                default:
                    {
                        Browser = new ChromeDriver();
                        break;
                    }
            }

            Browser.Manage().Window.Maximize();

            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }


    public enum BrowserTypes
    {
        Chrome,
        HeadLessChrome
    }
}

