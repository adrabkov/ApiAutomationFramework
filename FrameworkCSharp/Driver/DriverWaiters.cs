using System;
using OpenQA.Selenium;

namespace CAD.CD.Search.TestFramework.Driver
{
    public class DriverWaiters
    {
        public Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public Func<IWebDriver, bool> ElementIsNotVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return !element.Displayed;
                }
                catch (Exception)
                {
                    return true;
                }
            };
        }

        public Func<IWebDriver, bool> ElementIsEnabled(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Enabled;
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }

        public Func<IWebDriver, bool> ElementIsNotEnabled(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return !element.Enabled;
                }
                catch (Exception)
                {
                    return true;
                }
            };
        }
    }
}
