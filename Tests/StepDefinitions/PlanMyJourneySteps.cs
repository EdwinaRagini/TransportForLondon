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
using TFLFramework.AppConfig;
using TFLFramework.Models;
using TFLFramework.PageLocators;

namespace TFLFramework.StepDefinitions
{
    [Binding]
    public class PlanMyJourneySteps
    {
        private readonly FeatureContext _featureContext;

        private PlanMyJourneyLocator _planMyJourney;
        private JourneyDetailsLocator _jouneyDetails;

        public PlanMyJourneySteps(FeatureContext featureContext)
        {
            var driver = (IWebDriver)featureContext[AppConstants.Browser];
            _planMyJourney = new PlanMyJourneyLocator(driver);
            _jouneyDetails = new JourneyDetailsLocator(driver);
            _featureContext = featureContext;
        }

        [Given(@"I enter locations")]
        public void GivenIEnterLocations(Table table)
        {
            var locations = table.CreateInstance<PlanMyJourneyEntity>();

            _planMyJourney.InputLocations(locations);
            _featureContext[StepConstants.ToLocation] = locations.ToLocation;
            _featureContext[StepConstants.FromLocation] = locations.FromLocation;

        }

        [StepDefinition(@"I Edit the journey location details")]
        public void GivenIEditTheJourneyLocationDetails(Table table)
        {
            var locations = table.CreateInstance<PlanMyJourneyEntity>();

            _jouneyDetails.InputLocations(locations);
            _featureContext[StepConstants.ToLocation] = locations.ToLocation;
            _featureContext[StepConstants.FromLocation] = locations.FromLocation;
        }


        [Given(@"I update Change time options")]
        public void GivenIUpdateChangeTimeOptions(Table table)
        {
            var changeTimeOptions = table.CreateInstance<PlanMyJourneyEntity>();

            _planMyJourney.ClickOnChangeTime();
            if (changeTimeOptions.Option == "Arriving")
            {
                _planMyJourney.ClickOnArravingTime();
            }
            _planMyJourney.SelectTime(changeTimeOptions.DepartureTime);
            _featureContext[StepConstants.ArrivingTime] = changeTimeOptions.DepartureTime;
        }

        [When(@"I click on plan a journey reference link")]
        public void WhenIClickOnPlanAJourneyReferenceLink()
        {
            _jouneyDetails.ClickOnHomeButton();
        }

        [When(@"I click on a result")]
        public void WhenIClickOnAResult()
        {
            _jouneyDetails.ClickOnFirstOptionFromResults();
        }


        [When(@"click on recent journey tab")]
        public void WhenClickOnRecentJourneyTab()
        {
            _planMyJourney.ClickOnRecentTab();
        }



        [When(@"I click on plan my journey button")]
        public void WhenIClickOnPlanMyJourneyButton()
        {
            _planMyJourney.ClickOnPlanMyJourneyButton();
        }


        [When(@"I click on update my journey button")]
        public void WhenIClickOnUpdateMyJourneyButton()
        {
            _jouneyDetails.ClickOnPlanMyJourneyButton();
        }

        [When(@"I click on edit journey button")]
        public void WhenIClickOnEditJourneyButton()
        {
            _jouneyDetails.ClickOnEditJourney();
        }



        [Then(@"I validate my journey results")]
        public void ThenIValidateMyJourneyResults()
        {
            _jouneyDetails.GetHeaderText().Should().BeEquivalentTo("Journey results");
            _jouneyDetails.GetToLocationText().Should().BeEquivalentTo(_featureContext[StepConstants.ToLocation].ToString());
            _jouneyDetails.GetFromLocationText().Should().BeEquivalentTo(_featureContext[StepConstants.FromLocation].ToString());

            _jouneyDetails.GetJourneyResultsText().Should().BeTrue();
        }

        [Then(@"I should see fieldvalidation errors")]
        public void ThenIShouldSeeFieldvalidationErrors(Table table)
        {
            var expectedErrors = table.Rows.Select(r => r["Error"]);
            var actualErrors = _planMyJourney.FormValidationErrors();
            actualErrors.Should().Contain(expectedErrors);

        }

        [Then(@"I should see a field validation error")]
        public void ThenIShouldSeeAFieldValidationError(Table table)
        {
            var error = table.Rows.Select(r => r["Error"]);
            _jouneyDetails.GetHeaderText().Should().BeEquivalentTo("Journey results");
            _jouneyDetails.GetFieldValidationErrorText().Should().Contain(error.FirstOrDefault());

        }

        [Then(@"I validate my updated journey results")]
        public void ThenIValidateMyUpdatedJourneyResults()
        {
            _jouneyDetails.GetHeaderText().Should().BeEquivalentTo("Journey results");
            _jouneyDetails.GetToLocationText().Should().BeEquivalentTo(_featureContext[StepConstants.ToLocation].ToString());
            _jouneyDetails.GetFromLocationText().Should().BeEquivalentTo(_featureContext[StepConstants.FromLocation].ToString());

            // Just checking for Time selected is displaying
            _jouneyDetails.GetArrivingText().Should().Contain(_featureContext[StepConstants.ArrivingTime].ToString());

            _jouneyDetails.GetJourneyResultsText().Should().BeTrue();
        }


        [Then(@"I should be able to see the recent jouneys")]
        public void ThenIShouldBeAbleToSeeTheRecentJouneys()
        {
            var actualResults = _planMyJourney.RecentJourneyPlanResultsText();



            var expectedResult = _featureContext[StepConstants.FromLocation].ToString() + " to " + _featureContext[StepConstants.ToLocation].ToString();

            actualResults.Should().Contain(expectedResult);
        }
    }
}
