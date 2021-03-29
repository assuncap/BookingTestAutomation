using AutomationBase.Helpers;
using BookingComAutomation.Pages;
using BookingComTests.Helpers;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace BookingComTests.Steps
{
    [Binding]
    public class BaseStepDefinition
    {
        private ScenarioContext _context;
        public BaseStepDefinition(ScenarioContext injectedContext)
        {
            _context = injectedContext;
        }


        [Given(@"Booking\.com homepage is loaded")]
        public void GivenBooking_ComHomepageIsLoaded()
        {
            var url = StaticConfig.Url;
            if (TestContext.Parameters.Exists(StaticConfig.PARAMETER_ENVIRONMENT))
            {
                url = TestContext.Parameters[StaticConfig.PARAMETER_ENVIRONMENT];
            }
            _context.StorePage(HomePage.GotoHomePage(WebDriverHelper.Instance, url));
        }

        [Given(@"I Search for a room for (.*) in '(.*)' for (.*) night (.*) days from today")]
        public void GivenISearchForARoomForInForNightDaysFromToday(int people, string location, int nights, int targetDays)
        {
            var homepage = _context.ValidateCurrentPage<HomePage>();
            _context.StorePage(homepage.SearchBy(location, DateTimeHelper.FromToday(targetDays), nights));
        }

        [When(@"I filter by '(.*)'")]
        public void WhenIFilterBy(string filter)
        {
            var searchresults = _context.ValidateCurrentPage<SearchResultsPage>();
            searchresults.SetFilter(filter);
        }

        [Then(@"Assert '(.*)' is '(.*)'")]
        public void ThenAssertIs(string hotel, bool outcome)
        {
            var searchresults = _context.ValidateCurrentPage<SearchResultsPage>();
            searchresults.AssertListing(hotel, outcome, $"Failed to validate that hotel '{hotel}' Listed = {outcome}");
        }

    }
}
