using System;
using AutomationBase.Initialization;
using BookingComTests.Helpers;
using NUnit.Framework;

namespace BookingComTests.Tests
{
    [TestFixture]
    public class BasicTest
    {
        public const string PARAMETER_ENVIRONMENT = "Environment";
        public const string PARAMETER_BROWSER = "Browser";
        [OneTimeSetUp]
        public void Init()
        {
            string url = "https://www.booking.com"; //default target url;
            string browser = "chrome"; //default browser
            if (TestContext.Parameters.Exists(PARAMETER_ENVIRONMENT)){
                url = TestContext.Parameters[PARAMETER_ENVIRONMENT];
            }
            if (TestContext.Parameters.Exists(PARAMETER_BROWSER))
            {
                browser = TestContext.Parameters[PARAMETER_BROWSER];
            }
            //get browser factory & init browser
            var browserFactory = BrowsersFactory.InitNamedBrowser(browser);
            WebDriverHelper.Initialize(browserFactory.InitDriver(url));


        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            WebDriverHelper.Instance.Dispose();
        }

        [Test]
        public void BookingMainPage()
        {

        }
    }
}
