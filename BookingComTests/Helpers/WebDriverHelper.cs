using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingComTests.Helpers
{
    public static class WebDriverHelper
    {
        public static IWebDriver Instance { get; private set; }
        public static void Initialize(IWebDriver driverInstance)
        {
            Instance = driverInstance;
        }

     
    }
}
