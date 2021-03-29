using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationBase.Initialization
{
    public static class BrowsersFactory
    {
        /// <summary>
        /// Get factory for a given browser
        /// </summary>
        /// <param name="browser">name of the browser to be initialized</param>
        /// <returns></returns>
        public static AbstractBrowserInitFactory InitNamedBrowser(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    return InitChromeBrowser();

                case "firefox":
                    return InitFirefoxBrowser();
                default:
                    //default browser
                    throw new Exception($"Browser '{browser}' was not matched to any supported browser.");
                    
            }
        }

        public static AbstractBrowserInitFactory InitChromeBrowser()
        {
            return new ChromeBrowser();
        }

        public static AbstractBrowserInitFactory InitFirefoxBrowser()
        {
            return new FirefoxBrowser();
        }

    }
}
