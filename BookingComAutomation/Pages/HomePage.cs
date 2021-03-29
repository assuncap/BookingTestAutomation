using AutomationBase.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingComAutomation.Pages
{
    /// <summary>
    /// Booking.com home page
    /// </summary>
    public class HomePage : AbstractPage
    {
        public HomePage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
