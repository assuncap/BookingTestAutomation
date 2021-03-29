using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationBase.Helpers
{
    public static class DateTimeHelper
    {

        /// <summary>
        /// Returns Datetime X number of days rfom Today. Works with negative values too.
        /// </summary>
        /// <param name="ndays">Number of days to target date. Can be negative.</param>
        /// <returns></returns>
        public static DateTime FromToday(int ndays)
        {
            return DateTime.Today.AddDays(ndays);
        }
    }
}
