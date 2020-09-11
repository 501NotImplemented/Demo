using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
		private static readonly ThreadLocal<IWebDriver> WebDrivers = new ThreadLocal<IWebDriver>();

		private Browser()
		{
		}

		/// <summary>
		/// Gets or sets webDriver storage for parallelization in a single machine
		/// </summary>
		public static IWebDriver Instance
		{
			get
			{
				if (WebDrivers.Value == null)
				{
					Start();
				}

				return WebDrivers.Value;
			}

			set => WebDrivers.Value = value;
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
		/// Start the browser instance
		/// </summary>
		public static void Start()
		{
			// Location of the driver executable, since we're adding the driver via Nuget, they're placed in the bin directory
			var driverDirectory = AppDomain.CurrentDomain.BaseDirectory;

			var chromeOptions = ChromeProfile;
			WebDrivers.Value = new ChromeDriver(driverDirectory, chromeOptions);

			Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			Instance.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
			Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

			DeleteAllCookies();
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
	}
}
