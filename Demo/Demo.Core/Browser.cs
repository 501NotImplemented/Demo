using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
				if (WebDrivers.IsValueCreated)
				{
					return WebDrivers.Value;
				}

				if (WebDrivers.Values.Count > 0)
				{
					return WebDrivers.Values.First();
				}

				throw new InvalidOperationException("Driver is not started for given thread");
			}

			internal set => WebDrivers.Value = value;
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
			var chrome = new ChromeDriver(driverDirectory, chromeOptions);
			WebDrivers.Value = chrome;

			SetTimeouts();

			DeleteAllCookies();
		}

		private static void SetTimeouts()
		{
			Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			Instance.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
			Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
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
	}
}
