using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Demo.Core
{
	public static class BrowserExtensions
	{
		/// <summary>
		/// Delete all browser cookies
		/// </summary>
		public static void DeleteAllCookies(this IWebDriver driver)
		{
			driver.Manage().Cookies.DeleteAllCookies();
		}

		public static bool IsJQueryUsedOnThePage(this IWebDriver driver)
		{
			var script = "return window.jQuery != undefined";
			var isJqueryUsed = Convert.ToBoolean(((IJavaScriptExecutor)driver).ExecuteScript(script));
			return isJqueryUsed;
		}

		/// <summary>
		/// Navigate to specified URL
		/// </summary>
		/// <param name="url">URL to navigate</param>
		public static void NavigateTo(this IWebDriver driver, string url)
		{
			driver.Navigate().GoToUrl(url);
		}

		/// <summary>
		/// Wait for active JQuery to complete
		/// </summary>
		/// <param name="numberOfRequests">Number of active requests to be left, default to 0</param>
		/// <param name="timeOut">Timeout, seconds</param>
		public static void WaitForActiveJQueryToComplete(this IWebDriver driver, int numberOfRequests = 0, int timeOut = 20)
		{
			var isJqueryPresent = driver.IsJQueryUsedOnThePage();

			if (isJqueryPresent)
			{
				var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
				wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript($"return jQuery.active == {numberOfRequests}"));
			}
		}

		/// <summary>
		/// Wait for document.readyState status on the page to be completed
		/// </summary>
		/// <param name="timeOut">Timeout, seconds</param>
		public static void WaitForPageReadyStateToComplete(this IWebDriver driver, double timeOut = 280.00)
		{
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
			wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
		}

		public static void WaitForPageTitleToContain(this IWebDriver driver, string expectedPart)
		{
			Wait.Until(() => driver.Title.Contains(expectedPart), TimeSpan.FromSeconds(5));
		}

		/// <summary>
		/// Wait for URL to be opened
		/// </summary>
		/// <param name="expectedUrl">Expected URL</param>
		/// <param name="timeOut">Timeout, seconds</param>
		public static void WaitForUrlToBeOpened(this IWebDriver driver, string expectedUrl, TimeSpan timeOut)
		{
			var wait = new WebDriverWait(driver, timeOut);
			wait.Until(ExpectedConditions.UrlToBe(expectedUrl.ToLower()));
		}
	}
}
