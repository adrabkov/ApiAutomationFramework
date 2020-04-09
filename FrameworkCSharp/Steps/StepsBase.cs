using FrameworkCSharp.Elements;
using FrameworkCSharp.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Steps
{
    public class StepsBase : ElementBase
    {
        protected readonly PageBase RootPage;
        protected PageBase CurrentPage;

        protected StepsBase(PageBase page, IWebDriver webDriver)
             : base(page.Locator, webDriver)
        {
            RootPage = CurrentPage = page;
        }

        public virtual T GetPage<T>()
            where T : PageBase
        {
            return (T)Activator.CreateInstance(typeof(T), new[] { WebDriver });
        }
    }
}
