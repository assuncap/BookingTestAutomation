using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationBase.Helpers
{
    public static class SelectionHelper
    {
        /// <summary>
        /// Tryies to find element number of times
        /// </summary>
        /// <param name="driver">webdriver</param>
        /// <param name="locator"></param>
        /// <param name="waitTimeSeconds"></param>
        /// <returns></returns>
        public static IWebElement WaitUntilElementExists(this IWebDriver driver, By locator, int waitTimeSeconds = 10)
        {
            try
            {
                return (new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeSeconds))).Until(
                    ExpectedConditions.ElementExists(locator));
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine($"WaitUntilElementExists : WebDriverTimeoutException, {waitTimeSeconds} secs, locator {locator}");
                return null;
            }
            catch (StaleElementReferenceException)
            {
                Console.WriteLine($"WaitUntilElementExists : StaleElementReferenceException, {waitTimeSeconds} secs, locator {locator}");
                return null;
            }
        }

        public static IWebElement ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            Action scroll = () =>
            {
                var window = driver.Manage().Window;
                int wHeight = window.Size.Height;
                int wPosY = window.Position.Y;
                int ePosY = element.Location.Y;
                if (Math.Abs(wPosY - ePosY) > wHeight * 0.5)
                {
                    var npos = (ePosY - 150);
                    var str = "window.scrollTo(0," + npos + ")";
                    ((IJavaScriptExecutor)driver).ExecuteScript(str);
                    Console.WriteLine($"Scrolling to (0,{npos})");
                }
            };
            scroll();
            
            return element;
        }

    }
}
