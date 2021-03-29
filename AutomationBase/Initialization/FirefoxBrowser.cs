using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AutomationBase.Initialization
{
    public class FirefoxBrowser : AbstractBrowserInitFactory
    {
        public string BinPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        public override IWebDriver InitDriver(string url)
        {
            FirefoxOptions options = new FirefoxOptions();
            return InitDriver(url, options);
        }

        public override IWebDriver InitDriver(string url, DriverOptions options)
        {
            var firefoxOptions = options as FirefoxOptions;
            var target = new Uri(BinPath);
            if (firefoxOptions != null)
                return new FirefoxDriver(FirefoxDriverService.CreateDefaultService(target.LocalPath), firefoxOptions);
            else
                return new FirefoxDriver(FirefoxDriverService.CreateDefaultService(target.LocalPath));
        }
    }
}
