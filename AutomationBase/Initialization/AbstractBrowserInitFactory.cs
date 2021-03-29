using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace AutomationBase.Initialization
{/// <summary>
/// Abtsract factory for browser init
/// </summary>
    public abstract class AbstractBrowserInitFactory
    {
        public abstract IWebDriver InitDriver(string url);
        public abstract IWebDriver InitDriver(string url, DriverOptions options);


    }
}
