using AutomationBase.Base;
using AutomationBase.Helpers;
using NUnit.Framework;
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
        public const string SEARCH_BAR_ID_LOCATOR = "ss";
        public const string CHECKIN_XPATH_LOCATOR = "";
        public const string NEXT_MONTH_XPATH_LOCATOR = "//div[@data-bui-ref='calendar-next']";
        public const string CHECKIN_PICKER_XPATH_LOCATOR = "//div[@data-mode='checkin']";
        public const string CALENDAR_DAY_XPATH_LOCATOR = "//td[@data-date='{0}']";
        public const string SEARCH_BUTTON_ID_LOCATOR = "//button[@data-sb-id='main']";
        public const string HOMEPAGE_PARAMETER = "HOMEPAGE";

        public IWebElement searchBar => Driver.WaitUntilElementExists(By.Id(SEARCH_BAR_ID_LOCATOR));
        public IWebElement checkinPicker => Driver.WaitUntilElementExists(By.XPath(CHECKIN_PICKER_XPATH_LOCATOR));
        public IWebElement nextMonthArrow => Driver.WaitUntilElementExists(By.XPath(NEXT_MONTH_XPATH_LOCATOR));

        public IWebElement searchButton => Driver.WaitUntilElementExists(By.XPath(SEARCH_BUTTON_ID_LOCATOR));


        public static HomePage GotoHomePage(IWebDriver driver)
        {
            var address = @"http://wwww.booking.com";
            if(TestContext.Parameters.Exists(HOMEPAGE_PARAMETER))
            {
                address = TestContext.Parameters[HOMEPAGE_PARAMETER];
            }
            return GotoHomePage(driver, address);
        }

        public static HomePage GotoHomePage(IWebDriver driver, string address)
        {
            driver.Navigate().GoToUrl(address);
            return new HomePage(driver);
        }

        public HomePage(IWebDriver webdriver) : base(webdriver)
        {
        }

        /// <summary>
        /// Checks if page has is been displayed properly
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            return (searchBar != null && searchBar.Displayed);
        }

        public SearchResultsPage SearchBy(string searchCity, DateTime checkInDate, int nights)
        {

            var checkoutDate = checkInDate.AddDays(nights);

            searchBar.SendKeys(searchCity);


            SetCheckInCheckoutDate(checkInDate, checkoutDate);
            searchButton.Click();
            return new SearchResultsPage(Driver);
        }

        public void SetCheckInCheckoutDate(DateTime checkin, DateTime checkout)
        {
            checkinPicker.Click();
            var moves = calcMonthMoves(DateTime.Now, checkin);
            //move to target month
            for (int i = 0; i < moves; i++)
            {
                nextMonthArrow.Click();
            }
            clickDate(checkin);

            moves = calcMonthMoves(checkin, checkout);
            for (int i = 0; i < moves; i++)
            {
                nextMonthArrow.Click();
            }
            clickDate(checkout);

        }


        /// <summary>
        /// Calcs the number of times the date picker needs to be clicked
        /// </summary>
        /// <param name="from">date currently set</param>
        /// <param name="to">target date</param>
        /// <returns></returns>
        private int calcMonthMoves(DateTime from, DateTime to)
        {
            var moves = to.Month - from.Month;
            if (moves < 0)
                moves += 12;
            return moves;
            
        }

        private void clickDate(DateTime target)
        {
           
            var locator = String.Format(CALENDAR_DAY_XPATH_LOCATOR, target.ToString("yyyy-MM-dd"));
            var td = Driver.WaitUntilElementExists(By.XPath(locator));
            td.Click();
        }
    }
}
