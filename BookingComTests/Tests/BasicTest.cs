using System;
using AutomationBase.Helpers;
using AutomationBase.Initialization;
using BookingComAutomation.Pages;
using BookingComTests.Helpers;
using NUnit.Framework;

namespace BookingComTests.Tests
{
    [TestFixture]
    public class BasicTest
    {
       public String URL = StaticConfig.Url;

        [OneTimeSetUp]
        public void Init()
        {
            string browser = "chrome"; //default browser
            if (TestContext.Parameters.Exists(StaticConfig.PARAMETER_ENVIRONMENT)){
                URL = TestContext.Parameters[StaticConfig.PARAMETER_ENVIRONMENT];
            }
            if (TestContext.Parameters.Exists(StaticConfig.PARAMETER_BROWSER))
            {
                browser = TestContext.Parameters[StaticConfig.PARAMETER_BROWSER];
            }
            //get browser factory & init browser
            var browserFactory = BrowsersFactory.InitNamedBrowser(browser);
            WebDriverHelper.Initialize(browserFactory.InitDriver(URL));


        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            WebDriverHelper.Instance.Dispose();
        }

        [Test(Description = "Search for Five Star Hotels in Limerick")]
        public void BookingFiveStarSavoy()
        {

            var homepage = HomePage.GotoHomePage(WebDriverHelper.Instance, URL);
            Assert.IsTrue(homepage.IsValid(),"Failed to validate that homepage has loaded properly.");
            var searchResult =  homepage.SearchBy("Limerick", DateTimeHelper.FromToday(90),1);
            searchResult.SetFiveStartFilter();
            searchResult.AssertListing("The Savoy Hotel", true, "Expected to list 'The Savoy Hotel'");
        }


        [Test(Description = "Search for Five Star Hotels in Limerick but not finding George Limerick Hotel")]
        public void NotListingGeorgeOnFiveStarFilter()
        {

            var homepage = HomePage.GotoHomePage(WebDriverHelper.Instance, URL);
            Assert.IsTrue(homepage.IsValid(), "Failed to validate that homepage has loaded properly.");
            var searchResult = homepage.SearchBy("Limerick", DateTimeHelper.FromToday(90), 1);
            searchResult.SetFiveStartFilter();
            searchResult.AssertListing("George Limerick Hotel", false, "Expected not to list 'George Limerick Hotel'");
        }

        

        [Test(Description = "Search for Hotels in Limerick with Spa")]
        public void BookingWithSauna()
        {

            var homepage = HomePage.GotoHomePage(WebDriverHelper.Instance, URL);
            Assert.IsTrue(homepage.IsValid(), "Failed to validate that homepage has loaded properly.");
            var searchResult = homepage.SearchBy("Limerick", DateTimeHelper.FromToday(90), 1);
            searchResult.SetSpaFilter();
            searchResult.AssertListing("Limerick Strand Hotel", true, "Expected to list 'Limerick Strand Hotel'");
            

        }

        [Test(Description = "Search for Hotels in Limerick with Spa but not finding George Limerick Hotel")]
        public void NotListingGeorgeOnSaunaFilter()
        {

            var homepage = HomePage.GotoHomePage(WebDriverHelper.Instance, URL);
            Assert.IsTrue(homepage.IsValid(), "Failed to validate that homepage has loaded properly.");
            var searchResult = homepage.SearchBy("Limerick", DateTimeHelper.FromToday(90), 1);
            searchResult.SetSpaFilter();
            searchResult.AssertListing("George Limerick Hotel", false, "Expected not to list 'George Limerick Hotel'");


        }

    }
}
