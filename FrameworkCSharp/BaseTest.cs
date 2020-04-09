using FrameworkCSharp.Driver;
using FrameworkCSharp.Enum;
using FrameworkCSharp.Pages;
using FrameworkCSharp.Utilities;
using FrameworkCSharp.Utilities.API;
using FrameworkCSharp.Utilities.API.Requests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp
{
    public abstract class BaseTest
    {
        public static IWebDriver driver;
        protected CustomerData customerData = new CustomerData();
        protected ApiRequests apiRequests = new ApiRequests();
        private static readonly string Url = CustomerData.URL;
        private ConcurrentDictionary<string, AutomationContext> _automationContext = new ConcurrentDictionary<string, AutomationContext>();
        private const int IMPLICIT_TIMEOUT = WaitDefaults.IMPLICIT_TIMEOUT;

        protected AutomationContext Automation
        {
            get
            {
                var key = TestContext.CurrentContext.Test.ID;

                if (_automationContext.ContainsKey(key))
                    return _automationContext[key];

                var context = new AutomationContext(TestContext.CurrentContext.Test.MethodName ?? TestContext.CurrentContext.Test.Name);

                if (!_automationContext.TryAdd(key, context))
                    throw new Exception("Could not initialize AutomationContext for test.");

                return context;
            }
        }

        [SetUp]
        public void SetUp()
        {
            driver = DriverHolder.GetInstance();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLICIT_TIMEOUT);
        }

        [TearDown]
        public void CloseBrowser()
        {
            DriverHolder.Clean();
        }

        public static T Navigate<T>()
    where T : PageBase
        {
            driver.Navigate().GoToUrl(Url);
            return (T)Activator.CreateInstance(typeof(T), new[] { driver });
        }
    }
}
