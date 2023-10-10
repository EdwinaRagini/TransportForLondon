using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Pages
{
    public class PlanMyJourneyPage : TflBasePage
    {
        public PlanMyJourneyPage(IWebDriver webDriver) : base(webDriver) { WebDriverExtensions.WaitForElement(webDriver, TflName, 5); }

        public By TflName => By.CssSelector("h1[class='tfl-name']");

        public By FromInput => By.CssSelector("input[id='InputFrom']");

        public By ToInput => By.CssSelector("input[id='InputTo']");
        public By PlanMyJourneyButton => By.CssSelector("input[id='plan-journey-button']");
        public By InputFromErrorMessageSpan => By.CssSelector("span[id='InputFrom-error']");
        public By InputToErrorMessageSpan => By.CssSelector("span[id='InputTo-error']");
        public By ChangeTimeLink => By.CssSelector("a[class=change-departure-time]");
        public By  ArrivingTime=> By.XPath("//label[text()='Arriving']");
        public By  Time => By.CssSelector("select[id=Time]");
        public By LeavingButton => By.CssSelector("input[id='departing']");
        public By ArrivingButton => By.CssSelector("input[id='arriving']");
        public By Day => By.CssSelector("select[id='Date']");
        public By ValidationErrors => By.CssSelector("span[class=field-validation-error]");
        public By  RecentTab=> By.CssSelector("li[id=jp-recent-tab-home]");
        public By JourneyPlanResults => By.XPath("//div[@id='jp-recent-content-home-']/a[@class='plain-button journey-item']");
  
        public List<string> FormValidationErrors()
        {
            var findElements = WebDriver.FindElements(ValidationErrors);
            var errors = new List<string>();

            foreach (var element in findElements)
            {
                element.GetText();
                errors.Add(element.Text);
            }
            return errors;
        }

        public List<string> RecentJourneyPlanResultsText()
        {
            var findElements = WebDriver.FindElements(JourneyPlanResults);

            var text = new List<string>();
            foreach (var element in findElements)
            {
                element.GetText();
                text.Add(element.Text);
            }
            return text;
        }

        public void SendFromInputText(string input)
        {
            WebDriver.FindElement(FromInput).SendText(input);
        }
        public void SendToInputText(string input)
        {
            WebDriver.FindElement(ToInput).SendText(input + Keys.Tab);
        }
        public void ClickPlanMyJourneyButton()
        {
            WebDriver.FindElement(PlanMyJourneyButton).Click();
        }
        public void ClickLeavingButton()
        {
            WebDriver.FindElement(LeavingButton).Click();
        }

        public void ClickArrivingButton()
        {
            WebDriver.FindElement(ArrivingButton).Click();
        }

        public string InputFromFieldErrorText
        {
            get  => WebDriver.FindElement(InputFromErrorMessageSpan).Text;
        }

        public string InputToFieldErrorText
        {
            get => WebDriver.FindElement(InputToErrorMessageSpan).Text;
        }

        public void ClickOnChangeTime()
        {
            WebDriver.FindElement(ChangeTimeLink).Click();
        }

        public void SelectTime(string time)
        {
            WebDriver.FindElement(Time).SelectTextFromDropDown(time);
        }
        public void SelectDay(string day)
        {
            WebDriver.FindElement(Day).SelectTextFromDropDown(day);
        }
        public void ClickOnRecentTab()
        {
            WebDriver.FindElement(RecentTab).Click();
        }

        public JourneyResultsPage ValidJourneyDetails(string fromInput,string toInput)
        {
            SendFromInputText(fromInput);
            SendToInputText(toInput);
            return new JourneyResultsPage(WebDriver);
        }
    }
}
