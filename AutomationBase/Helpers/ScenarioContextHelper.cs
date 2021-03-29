using AutomationBase.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AutomationBase.Helpers
{
    public static class ScenarioContextHelper
    {
        public const string PAGE = "page";
        public static T ValidateCurrentPage<T>(this ScenarioContext context) where T : class
        {
            if (!context.ContainsKey(PAGE))
            {
                Assert.Fail("No page is been stored");
            }
            var page = context[PAGE] as T;
            if (page == null)
            {
                Assert.Fail("Browser Located at wrong page!");
            }

            return page;
        }

        public static IPage GetCurrentPage(this ScenarioContext context)
        {
            return context[PAGE] as IPage;
        }

        public static void StorePage(this ScenarioContext context, IPage page)
        {
            context[PAGE] = page;
        }

        public static bool PageIsInstanceOf<T>(this ScenarioContext context) where T : IPage
        {
            var page = context[PAGE];
            return (page is T);
        }
    }
}
