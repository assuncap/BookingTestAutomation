using AutomationBase.Base;
using AutomationBase.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingComAutomation.Pages
{
    public class SearchResultsPage : AbstractPage
    {
        public const string SEARCH_BAR_ID_LOCATOR = "ss";
        public const string SEARCH_BUTTON_ID_LOCATOR = "//button[@data-sb-id='main']";
        public const string HOTEL_LINK_XPATH_LOCATOR = "//div[@id='search_results_table']//h3//a//span[contains(text(),'{0}')]";
        public const string FIVE_START_FILTER_XPATH_LOCATOR = "//a[@data-id='class-5']";
        public const string SHOW_ALL_FACILITIES_XPATH_LOCATOR = "//div[@id='filter_facilities']//button//span[contains(text(),'Show all')]";
        public const string SPA_FILTER_XPATH_LOCATOR = "//a[@data-id='hotelfacility-54']";

        public IWebElement FiveStartFilter => Driver.WaitUntilElementExists(By.XPath(FIVE_START_FILTER_XPATH_LOCATOR));

       
        public IWebElement SpaFilter => Driver.WaitUntilElementExists(By.XPath(SPA_FILTER_XPATH_LOCATOR));
        public IWebElement SearchBar => Driver.WaitUntilElementExists(By.Id(SEARCH_BAR_ID_LOCATOR));



        public SearchResultsPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public SearchResultsPage SetFilter(string filtername)
        {
            switch (filtername.ToLower())
            {
                case "spa":
                    SetSpaFilter();
                    break;

                case "sauna":
                    SetSpaFilter();
                    break;

                case "five star":
                    SetFiveStartFilter();
                    break;

                case "5 star":
                    SetFiveStartFilter();
                    break;
                default:
                    Console.WriteLine($"Filter '{filtername}' was not matched to any of the options.");
                    break;
            }

            return this;
        }

        /// <summary>
        /// Sets filter for Five Start Hotels
        /// </summary>
        /// <returns></returns>
        public SearchResultsPage SetFiveStartFilter()
        {
            Driver.ScrollToElement(FiveStartFilter);
            FiveStartFilter.Click();

            return this;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotel">Hotel Name</param>
        /// <param name="expected">expected aute come</param>
        /// <param name="message">Message to be displayed if assertion fails</param>
        public void AssertListing(string hotel,bool expected, string message)
        {
            var locator = String.Format(HOTEL_LINK_XPATH_LOCATOR, hotel);
            var link = Driver.WaitUntilElementExists(By.XPath(locator),5);
     
            Assert.AreEqual((link != null), expected, message);

        }

        public override bool IsValid()
        {
            return (SearchBar != null && SearchBar.Displayed);
        }

        /// <summary>
        /// Spa
        /// </summary>
        public void SetSpaFilter()
        {
            var showallBtn = Driver.WaitUntilElementExists(By.XPath("//div[@id='filter_facilities']//button"));
            if(showallBtn != null && showallBtn.Displayed)
            {
                Driver.ScrollToElement(showallBtn);
                showallBtn.Click();
            }
            SpaFilter.Click();




        }
    }
}
