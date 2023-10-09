using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TFLFramework.AppConfig;
using TFLFramework.Drivers;
using TFLFramework.Extensions;

namespace Tests
{
    [Binding]
    public class LifeCycle
    {
        [BeforeScenario()]
        public static void Setup(FeatureContext featureContext)
        {
            var webDriver = new Driver(AppConfigBuilder.Instance.BrowserType);
            webDriver.Browser.NavigateTo(AppConfigBuilder.Instance.Url);
            webDriver.Browser.WaitForPageToLoad();
            webDriver.Browser.AccecptCookies();
            featureContext[AppConstants.Browser] = webDriver.Browser;
        }

        [AfterScenario()]
        public static void Teardown(FeatureContext featureContext)
        {
            var webDriver = (IWebDriver)featureContext[AppConstants.Browser];
            webDriver.Quit();
        }
    }
}
