using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Tests;
using PageObjects;
using PageObjects.Pages;
using Xunit;

namespace TFLFramework.StepDefinitions
{
    [Binding]
    public class PlanMyJourneySteps
    {
        private readonly FeatureContext _featureContext;

        private PlanMyJourneyPage _planMyJourney;
        private JourneyResultsPage _journeyResults;

        public PlanMyJourneySteps(FeatureContext featureContext)
        {
            var driver = (IWebDriver)featureContext[Constants.Browser];
            _planMyJourney = new PlanMyJourneyPage(driver);
            _journeyResults = new JourneyResultsPage(driver);
            _featureContext = featureContext;
        }

        [Given(@"I enter the From and To Locations")]
        public void GivenIEnterTheFromAndToLocations(Table table)
        {
            var locations = table.CreateInstance<PlanMyJourneyModel>();

            _planMyJourney.ValidJourneyDetails(locations.FromLocation, locations.ToLocation);
            _featureContext[StepConstants.ToLocation] = locations.ToLocation;
            _featureContext[StepConstants.FromLocation] = locations.FromLocation;
        }

        [Given(@"I set the Change time in Journey Planner")]
        public void GivenISetTheChangeTimeInJourneyPlanner(Table table)
        {
            var changeTimeOptions = table.CreateInstance<PlanMyJourneyModel>();

            _planMyJourney.ClickOnChangeTime();

            switch (changeTimeOptions.TimeOptions.ToUpper())
            {
                case "ARRIVING":
                    _planMyJourney.ClickArrivingButton();
                    break;
                case "LEAVING":
                    _planMyJourney.ClickLeavingButton();
                    break;
                default:
                    _planMyJourney.ClickArrivingButton();
                    break;
            }
            _planMyJourney.SelectDay(changeTimeOptions.Day);
            _planMyJourney.SelectTime(changeTimeOptions.Time);
            _featureContext[StepConstants.ArrivingTime] = changeTimeOptions.Time;
        }

        [When(@"I edit the journey location details")]
        public void WhenIEditTheJourneyLocationDetails(Table table)
        {
            var locations = table.CreateInstance<PlanMyJourneyModel>();

            _planMyJourney.ValidJourneyDetails(locations.FromLocation, locations.ToLocation);
            _featureContext[StepConstants.ToLocation] = locations.ToLocation;
            _featureContext[StepConstants.FromLocation] = locations.FromLocation;
        }

        [When(@"I select a travel option")]
        public void WhenISelectATravelOption()
        {
            _journeyResults.ClickOnFirstOptionFromResults();
        }

        [When(@"I navigate to plan a journey home page")]
        public void WhenINavigateToPlanAJourneyHomePage()
        {
            _journeyResults.ClickOnHomeButton();
        }

        [When(@"I click on the Recent tab")]
        public void WhenIClickOnTheRecentTab()
        {
            _planMyJourney.ClickOnRecentTab();
        }

        [When(@"I click on update my journey button")]
        public void WhenIClickOnUpdateMyJourneyButton()
        {
            _journeyResults.ClickUpdateMyJourneyButton();
        }

        [When(@"I click on edit journey button")]
        public void WhenIClickOnEditJourneyButton()
        {
            _journeyResults.ClickOnEditJourney();
        }

        [Then(@"I verify the field error messages in Plan my journey page")]
        public void ThenIVerifyTheFieldErrorMessagesInPlanMyJourneyPage(Table table)
        {
            var journey = table.CreateInstance<PlanMyJourneyModel>();
            var actualErrors = _planMyJourney.FormValidationErrors();
            actualErrors.Should().Contain(journey.Error);
        }

        [Then(@"I verify the error messages in Journey Results page")]
        public void ThenIVerifyTheErrorMessagesInJourneyResultsPage(Table table)
        {
            var journey = table.CreateInstance<PlanMyJourneyModel>();
            _journeyResults.GetHeaderText.Should().BeEquivalentTo(StepConstants.JourneyResults);
            _journeyResults.GetFieldValidationErrorText.Should().Contain(journey.Error);
        }

        [Then(@"I verify the arrival time on journey results")]
        public void ThenIVerifyTheArrivalTimeOnJourneyResults()
        {
            _journeyResults.GetHeaderText.Should().BeEquivalentTo(StepConstants.JourneyResults);
            _journeyResults.GetToLocationText.Should().BeEquivalentTo(_featureContext[StepConstants.ToLocation].ToString());
            _journeyResults.GetFromLocationText.Should().BeEquivalentTo(_featureContext[StepConstants.FromLocation].ToString());
            _journeyResults.GetArrivingText.Should().Contain(_featureContext[StepConstants.ArrivingTime].ToString());
            _journeyResults.GetJourneyResultsText.Should().BeTrue();
            _journeyResults.GetSummaryJourneyResultsText.Should().BeTrue();
        }

        [Then(@"I verify the recent journeys made")]
        public void ThenIVerifyTheRecentJourneysMade()
        {
            var actualResults = _planMyJourney.RecentJourneyPlanResultsText();
            var expectedResult = _featureContext[StepConstants.FromLocation].ToString()+" to "+_featureContext[StepConstants.ToLocation].ToString();

            actualResults.Should().Contain(expectedResult);
        }


        [StepDefinition(@"I verify the details in journey results")]
        public void ThenIVerifyTheDetailsInJourneyResults()
        {
            _journeyResults.GetHeaderText.Should().BeEquivalentTo("Journey results");
            _journeyResults.GetToLocationText.Should().BeEquivalentTo(_featureContext[StepConstants.ToLocation].ToString());
            _journeyResults.GetFromLocationText.Should().BeEquivalentTo(_featureContext[StepConstants.FromLocation].ToString());
            _journeyResults.GetJourneyResultsText.Should().BeTrue();
            _journeyResults.GetSummaryJourneyResultsText.Should().BeTrue();
        }

        [StepDefinition(@"I click on plan my journey button")]
        public void WhenIClickOnPlanMyJourneyButton()
        {
            _planMyJourney.ClickPlanMyJourneyButton();
        }
    }
}
