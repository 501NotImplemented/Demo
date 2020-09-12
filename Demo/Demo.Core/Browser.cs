using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Demo.Core
{
	/// <summary>
	/// Wrapper around webdriver
	/// </summary>
	public class Browser
	{
		/// <summary>
		/// Storage of webdrivers
		/// </summary>
		private static readonly ThreadLocal<IWebDriver> WebDrivers = new ThreadLocal<IWebDriver>(true);

		/// <summary>
		/// Storage of EventFiringBrowsers
		/// </summary>
		private static readonly ThreadLocal<IWebDriver> EventFiringDrivers = new ThreadLocal<IWebDriver>(true);

		private Browser()
		{
		}

		/// <summary>
		/// Gets or sets webDriver storage for parallelization on a single machine
		/// </summary>
		public static IWebDriver Instance
		{
			get
			{
				if (EventFiringDrivers.IsValueCreated)
				{
					return EventFiringDrivers.Value;
				}

				if (EventFiringDrivers.Values.Count > 0)
				{
					return EventFiringDrivers.Values.First();
				}

				throw new InvalidOperationException("Driver is not started for given thread");
			}

			internal set => EventFiringDrivers.Value = value;
		}

		private static ChromeOptions ChromeProfile
		{
			get
			{
				var chromeOptions = new ChromeOptions();
				chromeOptions.AddArguments("start-maximized", "--no-sandbox");

				return chromeOptions;
			}
		}

		public static string Title => Instance.Title;

		/// <summary>
		/// Gets or sets webDriver storage for parallelization in a single machine
		/// </summary>
		private static IWebDriver NativeDriverInstance
		{
			get => WebDrivers.Value;

			set => WebDrivers.Value = value;
		}

		/// <summary>
		/// Wait for active JQuery to complete
		/// </summary>
		/// <param name="numberOfRequests">Number of active requests to be left, default to 0</param>
		/// <param name="timeOut">Timeout, seconds</param>
		public static void WaitForActiveJQueryToComplete(int numberOfRequests = 0, int timeOut = 20)
		{
			var isJqueryPresent = IsJQueryUsedOnThePage();

			if (isJqueryPresent)
			{
				var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeOut));
				wait.Until(driver => ((IJavaScriptExecutor) Instance).ExecuteScript($"return jQuery.active == {numberOfRequests}"));
			}
		}

		public static bool IsJQueryUsedOnThePage()
		{
			var script = "return window.jQuery != undefined";
			var isJqueryUsed = Convert.ToBoolean(InvokeScript(script));
			return isJqueryUsed;
		}

		/// <summary>
		/// Invoke JavaScript
		/// </summary>
		/// <param name="script">Script source</param>
		/// <param name="args">Optional arguments</param>
		/// <returns>String</returns>
		public static string InvokeScript(string script, params object[] args)
		{
			var javaScriptExecutor =
				Instance as IJavaScriptExecutor;
			var result = javaScriptExecutor.ExecuteScript(script, args);
			return Convert.ToString(result);
		}

		/// <summary>
		/// Wait for document.readyState status on the page to be completed
		/// </summary>
		/// <param name="timeOut">Timeout, seconds</param>
		public static void WaitForPageReadyStateToComplete(double timeOut = 280.00)
		{
			var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeOut));
			wait.Until(driver => ((IJavaScriptExecutor) Instance).ExecuteScript("return document.readyState").Equals("complete"));
		}

		/// <summary>
		/// Navigate to specified URL
		/// </summary>
		/// <param name="url">URL to navigate</param>
		public static void NavigateTo(string url)
		{
			Instance.Navigate().GoToUrl(url);
		}

		/// <summary>
		/// Start the browser instance
		/// </summary>
		public static void Start()
		{
			// Location of the driver executable, since we're adding the driver via Nuget, they're placed in the bin directory
			var driverDirectory = AppDomain.CurrentDomain.BaseDirectory;

			var chromeOptions = ChromeProfile;
			NativeDriverInstance = new ChromeDriver(driverDirectory, chromeOptions);
			EventFiringDrivers.Value = new EventFiringBrowser(NativeDriverInstance);

			SetTimeouts();

			DeleteAllCookies();
		}

		private static void SetTimeouts()
		{
			NativeDriverInstance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			NativeDriverInstance.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
			NativeDriverInstance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
		}

		/// <summary>
		/// Close the browser window
		/// </summary>
		public static void Close()
		{
			Instance.Close();
		}

		/// <summary>
		/// Quit driver
		/// </summary>
		public static void Quit()
		{
			Instance.Quit();
		}

		/// <summary>
		/// Delete all browser cookies
		/// </summary>
		public static void DeleteAllCookies()
		{
			Instance.Manage().Cookies.DeleteAllCookies();
		}

		/// <summary>
		/// Wait for URL to be opened
		/// </summary>
		/// <param name="expectedUrl">Expected URL</param>
		/// <param name="timeOut">Timeout, seconds</param>
		public static void WaitForUrlToBeOpened(string expectedUrl, TimeSpan timeOut)
		{
			var wait = new WebDriverWait(Instance, timeOut);
			wait.Until(ExpectedConditions.UrlToBe(expectedUrl.ToLower()));
		}

		public static void WaitForPageTitleToContain(string expectedPart)
		{
			Wait.Until(() => Title.Contains(expectedPart), TimeSpan.FromSeconds(5));
		}
	}
}
