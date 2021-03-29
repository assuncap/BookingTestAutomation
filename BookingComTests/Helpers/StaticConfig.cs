using System;
using System.Collections.Generic;
using System.Text;

namespace BookingComTests.Helpers
{
    /// <summary>
    /// Contains static configuration. If you need to change it then it shouldn't be in here
    /// </summary>
    public static class StaticConfig
    {
        public const string PARAMETER_ENVIRONMENT = "Environment";
        public const string PARAMETER_BROWSER = "Browser";
        public static string Url = "https://www.booking.com"; //default target url in case it's not provided anywhere else

        public const string CURRENT_PAGE = "CURRENT_PAGE";
    }
}
