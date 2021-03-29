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
    }
}
