using AutomationBase.Initialization;
using BookingComTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BookingComTests.Hooks
{
    [Binding]
    public sealed class Init
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        /// <summary>
        /// should run one
        /// </summary>
        [BeforeTestRun]
        public void BeforeTestRun()
        {
            string browser = "chrome"; //default browser
            var url = StaticConfig.Url;
            if (TestContext.Parameters.Exists(StaticConfig.PARAMETER_ENVIRONMENT))
            {
                url = TestContext.Parameters[StaticConfig.PARAMETER_ENVIRONMENT];
            }
            if (TestContext.Parameters.Exists(StaticConfig.PARAMETER_BROWSER))
            {
                browser = TestContext.Parameters[StaticConfig.PARAMETER_BROWSER];
            }
            //get browser factory & init browser
            var browserFactory = BrowsersFactory.InitNamedBrowser(browser);
            WebDriverHelper.Initialize(browserFactory.InitDriver(url));

        }

        [AfterTestRun]
        public void AfterTestRun()
        {
            WebDriverHelper.Instance.Dispose();
        }



    }
}
