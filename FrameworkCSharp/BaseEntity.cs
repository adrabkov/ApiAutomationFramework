using FrameworkCSharp.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp
{
    public class BaseEntity
    {
        protected internal IWebElement WebElement { get; set; }
        protected IWebDriver WebDriver { get; set; }

        protected IWebElement FindVisibleElement(By by, int timeoutInSeconds = 5, int pollIntervalSec = 0)
        {
            return EvaluateElement(ExpectedConditions.ElementIsVisible(by), timeoutInSeconds, pollIntervalSec);
        }

        protected IWebElement FindClickableElement(By by, int timeoutInSeconds = 5, int pollIntervalSec = 0)
        {
            return EvaluateElement(ExpectedConditions.ElementToBeClickable(by), timeoutInSeconds, pollIntervalSec);
        }

        protected IWebElement FindExistingElement(By by, int timeoutInSeconds = 5, int pollIntervalSec = 0)
        {
            return EvaluateElement(ExpectedConditions.ElementExists(by), timeoutInSeconds, pollIntervalSec);
        }


        protected bool IsElementVisible(By by, int timeoutInSec = 5, int pollIntervalSec = 0)
        {
            try
            {
                return EvaluateElement(ExpectedConditions.ElementIsVisible(by), timeoutInSec, pollIntervalSec) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected bool IsElementExists(By by, int timeoutInSec = 5, int pollIntervalSec = 0)
        {
            try
            {
                return EvaluateElement(ExpectedConditions.ElementExists(by), timeoutInSec, pollIntervalSec) != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected T EvaluateElement<T>(Func<IWebDriver, T> condition, int timeoutInSec = 5, int pollIntervalSec = 0)
        {
            return EvaluateElement<T>(condition, () => WebDriver.Navigate().Refresh(), timeoutInSec, pollIntervalSec);
        }

        protected T EvaluateScript<T>(string script, int timeoutInSec = 5, int pollIntervalSec = 0)
        {
            if (timeoutInSec > 0 || pollIntervalSec > 0)
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSec));

                if (pollIntervalSec > 0)
                    wait.PollingInterval = TimeSpan.FromSeconds(pollIntervalSec);

                return wait.Until((webDriver) =>
                {
                    return (T)(WebDriver as IJavaScriptExecutor).ExecuteScript(script);
                });
            }
            return (T)(WebDriver as IJavaScriptExecutor).ExecuteScript(script);
        }

        protected T EvaluateElement<T>(Func<IWebDriver, T> condition, Action refreshAction, int timeoutInSec = 5, int pollIntervalSec = 0)
        {
            if (timeoutInSec > 0 || pollIntervalSec > 0)
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSec));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                if (pollIntervalSec > 0)
                {
                    wait.PollingInterval = TimeSpan.FromSeconds(pollIntervalSec);
                    return wait.Until((webDriver) =>
                    {
                        refreshAction();

                        if (!WaitForAjaxLoad())
                            throw new Exception("AJAX failed to completed in time.");

                        return condition(webDriver);
                    });
                }

                if (!WaitForAjaxLoad())
                    throw new Exception("AJAX failed to completed in time.");

                return wait.Until(condition);
            }

            if (!WaitForAjaxLoad())
                throw new Exception("AJAX failed to completed in time.");

            return condition(WebDriver);
        }

        protected bool IsDocumentReady(int timeoutInSec = 10)
        {
            try
            {
                return EvaluateScript<bool>("return document.readyState == 'complete'", timeoutInSec);
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected bool WaitForAjaxLoad()
        {
            if (!IsDocumentReady())
                throw new Exception("Document is not ready in time.");

            var isJQueryDefined = EvaluateScript<bool>("return window.jQuery !== undefined", 0, 0);

            if (isJQueryDefined)
            {
                try
                {
                    var wait = new WebDriverWait(WebDriver, TimeSpan.FromMinutes(1));
                    wait.PollingInterval = TimeSpan.FromMilliseconds(100);
                    wait.Until(wd => (bool)(WebDriver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
