using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Pages
{
    public class JourneyResultsPage : TflBasePage
    {
        public JourneyResultsPage(IWebDriver webDriver) : base(webDriver) { WebDriverExtensions.WaitForElement(webDriver, OtherOptionsHeader, 10); }
        public By JourneyDetailsPageHeader => By.CssSelector("span[class=jp-results-headline]");
        public By FieldValidationError => By.CssSelector("li[class='field-validation-error']");
        public By OtherOptionsHeader => By.CssSelector("div[class='extra-journey-options multi-modals clearfix'] h2");
        public By JourneyResults => By.CssSelector("div[class='journey-results publictransport no-map']");
        public By SummaryJourneyResults => By.CssSelector("div[class='summary-results publictransport not-cycle-hire']");
        public By ToLocationText =>By.XPath("//div[@class='journey-result-summary']//span[text()='To:']/parent::div//strong");
        public By FromLocationText =>By.XPath("//div[@class='journey-result-summary']//span[text()='From:']/parent::div//strong");
        private By ArrivingTimeText => By.XPath("//div[@class='journey-result-summary']//span[text()='Arriving:']/parent::div//strong");
        private By EditJourney => By.CssSelector("a[class='edit-journey'] span");
        private By HomeButton =>By.XPath("//div[@class='journey-planner-results']//span[text()='Home']");
        public By FirstOption => By.CssSelector("div[id=option-2-heading]");
        public By UpdateMyJourneyButton => By.CssSelector("input[id='plan-journey-button']");

        public string GetHeaderText
        {
            get => WebDriver.FindElement(JourneyDetailsPageHeader).Text;
        }
        public string GetToLocationText
        {
            get => WebDriver.FindElement(ToLocationText).Text;
        }
        public string GetFromLocationText
        {
            get => WebDriver.FindElement(FromLocationText).Text;
        }
        public string GetArrivingText
        {
            get => WebDriver.FindElement(ArrivingTimeText).Text;
        }
        public void ClickOnEditJourney()
        {
           WebDriver.FindElement(EditJourney).Click();
        }

        public void ClickUpdateMyJourneyButton()
        {
            WebDriver.FindElement(UpdateMyJourneyButton).Click();
        }

        public string GetOtherHeaderOptionsText
        {
            get => WebDriver.FindElement(OtherOptionsHeader).Text;
        }

        public string GetFieldValidationErrorText
        {
            get => WebDriver.FindElement(FieldValidationError).Text;
        }

        public bool GetJourneyResultsText
        {
            get => WebDriver.FindElement(JourneyResults).ElementDisplayed();
        }

        public bool GetSummaryJourneyResultsText
        {
            get => WebDriver.FindElement(SummaryJourneyResults).ElementDisplayed();

        }
        public void ClickOnHomeButton()
        {
            WebDriver.FindElement(HomeButton).Click();
        }
        public void ClickOnFirstOptionFromResults()
        {
            WebDriver.FindElement(FirstOption).Click();
        }

    }
}
