using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationBase.Base
{
    public abstract class AbstractPage : IPage
    {
        public IWebDriver Driver { get; protected set; }

        public AbstractPage(IWebDriver webdriver)
        {
            this.Driver = webdriver;
        }

        public abstract bool IsValid();
    }
}
