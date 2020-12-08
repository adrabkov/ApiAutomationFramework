using CAD.CD.Search.TestFramework.Config;
using FrameworkCSharp.Driver;
using FrameworkCSharp.Enum;
using FrameworkCSharp.Pages;
using FrameworkCSharp.Utilities;
using FrameworkCSharp.Utilities.API.Requests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Concurrent;

namespace FrameworkCSharp
{
    public abstract class BaseTest : DriverHolder
    {
        protected readonly Settings _settings = ConfigLoader.GetSettings("QASettings");
        protected ApiRequests apiRequests = new ApiRequests();
        private ConcurrentDictionary<string, AutomationContext> _automationContext = new ConcurrentDictionary<string, AutomationContext>();
        private const int IMPLICIT_TIMEOUT = WaitDefaults.IMPLICIT_TIMEOUT;
        protected static IWebDriver driver;

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
            driver = GetDriver(_settings.Browser);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLICIT_TIMEOUT);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Clean();
        }

        public T Navigate<T>()
    where T : PageBase
        {
            driver.Navigate().GoToUrl(_settings.VKUrl);
            return (T)Activator.CreateInstance(typeof(T), new[] { driver });
        }

    }
}
