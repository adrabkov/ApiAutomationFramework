using FrameworkCSharp.Driver;
using FrameworkCSharp.Enum;
using FrameworkCSharp.Exceptions;
using FrameworkCSharp.Pages;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace FrameworkCSharp.Elements
{
    public abstract class ElementBase : BaseEntity
    {
		protected internal By Locator { get; }
		protected internal IWebElement WebElement { get; set; }

		protected ILog Logger { get; set; }

		private const int DEFAULT_VALIDATION_TIMEOUT_IN_SEC = WaitDefaults.LONG_EVALUATION_TIMEOUT;
		private const int DEFAULT_TIMEOUT_IN_SEC = WaitDefaults.LONG_EVALUATION_TIMEOUT;

		protected ElementBase(By locator, IWebDriver webDriver, bool throwOnValidationFailure = true, int validationTimeoutInSec = DEFAULT_VALIDATION_TIMEOUT_IN_SEC)
		{
			WebDriver = webDriver;
			Locator = locator;
			Validate(throwOnValidationFailure, validationTimeoutInSec);
		}

		public void Validate(bool throwOnFailure, int timeoutInSec)
		{
			if (IsElementExists(Locator, timeoutInSec))
				WebElement = FindExistingElement(Locator, timeoutInSec);
			else if (throwOnFailure)
				throw new ElementValidationException(string.Format("Invalid Element: {0}", Locator));
		}

		public bool WaitForElementPresent(By locator, int timeoutSec = 5)
		{
			Boolean result = true;
			var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutSec));
			try
			{
				wait.Until(waiting =>
				{
					var webElements = WebDriver.FindElements(locator);
					return webElements.Count != 0;
				});
			}
			catch (TimeoutException)
			{
				result = false;
			}
			return result;
		}



		public ReadOnlyCollection<IWebElement> FindAllElements(By by)
		{
			return WebDriver.FindElements(by);
		}

		//public List<IWebElement> FindAllLIstElements(By by)
		//{
		//	return driver.FindElements(by).ToList();
		//}

		public bool IsPresent()
		{
			return WebDriver.FindElements(Locator).Count > 0;
		}

		public bool IsDisplayed(IWebElement webElement)
		{
			return webElement.Displayed;
		}

		public bool IsElementVisible(By Locator)
		{
			try
			{
				var iv = WebDriver.FindElement(Locator).Displayed;
				if (iv == true) { return true; } else { return false; }
			}
			catch (NoSuchElementException) { return false; }
		}

		public void WaitForElementVisible(By Locator, int timeoutSec = 5, int pollIntervalSec = 0)
		{
			if (!IsElementVisible(Locator, timeoutSec, pollIntervalSec))
				throw new Exception("Could not find visible element.");
		}

		public bool WaitForElementIsVisible(By Locator, int timeout)
		{

			var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
			wait.Timeout = TimeSpan.FromMinutes(1);
			wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

			try
			{
				wait.Until(ExpectedConditions.ElementIsVisible(Locator));
				return true;
			}

			catch (WebDriverTimeoutException)
			{
				return false;
			}
		}

		public bool WaitUntilElementIsVisible(By Locator, int timeout)
		{

			var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
			wait.Timeout = TimeSpan.FromMinutes(1);
			wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

			try
			{
				wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Locator));
				return true;
			}

			catch (TimeoutException)
			{
				return false;
			}
		}

		public void ClickElementBy(By by, int timeoutInSec = 10, int pollIntervalSec = 0)
		{
			var clickableElement = FindClickableElement(by, timeoutInSec, pollIntervalSec);
			clickableElement.Click();
		}

		protected T ClickElementBy<T>(By by, int timeoutInSec = DEFAULT_TIMEOUT_IN_SEC, int pollIntervalInSec = 0)
	where T : PageBase
		{
			return ClickElementBy<T>(WebDriver, by, timeoutInSec, pollIntervalInSec);
		}
		protected T ClickElementBy<T>(ISearchContext context, By by, int timeoutInSec = DEFAULT_TIMEOUT_IN_SEC, int pollIntervalInSec = 0)
			where T : PageBase
		{
			return PerformAndLogTrace(
				() =>
				{
					ClickElementBy(by, timeoutInSec, pollIntervalInSec);
					return (T)Activator.CreateInstance(typeof(T), WebDriver);
				},
				string.Format("ClickElementBy<{1}>: ({0})", by.ToString(), typeof(T).Name));
		}

		protected T ClickIWebElement<T>(IWebElement webElement, int timeoutInSec = DEFAULT_TIMEOUT_IN_SEC, int pollIntervalInSec = 0)
where T : PageBase
		{
			return ClickIWebElement<T>(WebDriver, webElement, timeoutInSec, pollIntervalInSec);
		}
		protected T ClickIWebElement<T>(ISearchContext context, IWebElement webElement, int timeoutInSec = DEFAULT_TIMEOUT_IN_SEC, int pollIntervalInSec = 0)
			where T : PageBase
		{
			return PerformAndLogTrace(
				() =>
				{
					webElement.Click();
					return (T)Activator.CreateInstance(typeof(T), WebDriver);
				},
				string.Format("ClickElementBy<{1}>: ({0})", webElement.ToString(), typeof(T).Name));
		}

		public void SendKeys(By by, string text, bool isClear=true)
		{
			var input = FindVisibleElement(by);
			if (isClear)
			{
				input.Clear();
			}
			input.SendKeys(text);
		}

		public void UploadFile(By by, string path)
		{
			var fileUploadElement = FindExistingElement(by);
			fileUploadElement.SendKeys(path);
		}


		public void SelectElementByValue(By by, string value)
		{
			var selectElement = new SelectElement(FindClickableElement(by));
			selectElement.SelectByValue(value);
		}

		public void SwitchToFrame(By by)
		{
			WebDriver.SwitchTo().Frame(FindExistingElement(by));
		}

		public void SwitchToParrentFrame()
		{
			WebDriver.SwitchTo().ParentFrame();
		}

		public void Move(By by)
		{
			var move = new Actions(WebDriver);
			move.MoveToElement(WebDriver.FindElement(by)).Build().Perform();
		}

		public void ScrollDownPage()
		{
			IJavaScriptExecutor js = ((IJavaScriptExecutor)WebDriver);
			js.ExecuteScript("window.scrollTo(0,document.body.offsetHeight)");
			Thread.Sleep(10000);
		}

		public void WaitForElementIsClickable(By locator)
		{
			var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
			wait.Until(ExpectedConditions.ElementToBeClickable(locator));
		}

		public string GetText(By by)
		{
			WaitForElementIsClickable(by);
			return WebDriver.FindElement(by).Text;
		}

		public void Click(By by)
		{
			WaitForElementIsClickable(by);
			WebDriver.FindElement(by).Click();
		}

		public void Click(By by, IWebElement element)
		{
			WaitForElementIsClickable(by);
			element.Click();
		}

		private T PerformAndLogTrace<T>(Func<T> func, string message, bool throwOnException = true)
		{
			T result = default(T);

			try
			{
				result = func();
			}
			catch (Exception)
			{
				if (throwOnException)
					throw;
			}

			return result;
		}
	}
}
