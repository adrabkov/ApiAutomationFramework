﻿using FrameworkCSharp.Elements;
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

        protected T GetCurrentPage<T>(bool throwOnError = true, string castError = null)
    where T : PageBase
        {
            if (CurrentPage == null)
            {
                if (throwOnError)
                    throw new Exception("Current Page has not been set.");
                return null;
            }

            var castedPage = CurrentPage as T;
            if (castedPage == null && throwOnError)
                throw new Exception(castError ?? string.Format("Current Page must be '{0}'.", typeof(T).Name));
            return castedPage;
        }
    }
}
