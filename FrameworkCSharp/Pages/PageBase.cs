using log4net;
using OpenQA.Selenium;
using FrameworkCSharp.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Pages
{
    public abstract class PageBase : ElementBase
    {
        protected PageBase(By locator, IWebDriver webDriver)
            : base(locator, webDriver) { }

        public void Refresh() => WebDriver.Navigate().Refresh();
        public string GetUrl() => WebDriver.Url;
    }
}
