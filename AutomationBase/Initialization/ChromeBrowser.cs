using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace AutomationBase.Initialization
{
    public class ChromeBrowser : AbstractBrowserInitFactory
    {
        public string BinPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        public override IWebDriver InitDriver(string url)
        {
            ChromeOptions defaultOptions = new ChromeOptions();
            
            return InitDriver(url, defaultOptions);
        }

        public override IWebDriver InitDriver(string url, DriverOptions options)
        {
            var chromeOptions = options as ChromeOptions;
            var target = new Uri(BinPath);
            if (chromeOptions != null)
                return new ChromeDriver(ChromeDriverService.CreateDefaultService(target.LocalPath), chromeOptions);
            else
                return new ChromeDriver(ChromeDriverService.CreateDefaultService(target.LocalPath));
        }
    }
}
