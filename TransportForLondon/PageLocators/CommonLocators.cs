using OpenQA.Selenium;
using TFLFramework.Models;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TFLFramework.Models;

namespace TFLFramework.PageLocators
{
    public class CommonLocators
    {
        protected IWebDriver Driver;


        public CommonLocators(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "InputFrom")]
        private readonly IWebElement InputFromLocation;

        [FindsBy(How = How.Id, Using = "InputTo")]
        private readonly IWebElement InputToLocation;

        [FindsBy(How = How.Id, Using = "plan-journey-button")]
        private readonly IWebElement PlanMyJourneyButton;

        public void InputLocations(PlanMyJourneyEntity planJourney)
        {

            if (!string.IsNullOrEmpty(planJourney.FromLocation))
                InputFromLocation.SendKeys(planJourney.FromLocation);
            if (!string.IsNullOrEmpty(planJourney.ToLocation))
                InputToLocation.SendKeys(planJourney.ToLocation);
        }

        public void ClickOnPlanMyJourneyButton()
        {
            PlanMyJourneyButton.Click();
        }


    }
}
