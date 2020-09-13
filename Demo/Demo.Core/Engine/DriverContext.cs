using System;
using System.Linq;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Demo.Core.Engine
{
	/// <summary>
	/// Wrapper around webdriver
	/// </summary>
	public class DriverContext
	{
		/// <summary>
		/// Storage of EventFiringBrowsers
		/// </summary>
		private readonly ThreadLocal<IWebDriver> _eventFiringDrivers = new ThreadLocal<IWebDriver>(true);

		/// <summary>
		/// Storage of webdrivers
		/// </summary>
		private readonly ThreadLocal<IWebDriver> _webDrivers = new ThreadLocal<IWebDriver>(true);

		/// <summary>
		/// Gets webDriver
		/// </summary>
		public IWebDriver Driver
		{
			get
			{
				if (_eventFiringDrivers.IsValueCreated)
				{
					return _eventFiringDrivers.Value;
				}

				if (_eventFiringDrivers.Values.Count > 0)
				{
					return _eventFiringDrivers.Values.First();
				}

				throw new InvalidOperationException("Driver is not started for given thread");
			}

			internal set => _eventFiringDrivers.Value = value;
		}

		private ChromeOptions ChromeProfile
		{
			get
			{
				var chromeOptions = new ChromeOptions();
				chromeOptions.AddArguments("start-maximized", "--no-sandbox");

				return chromeOptions;
			}
		}

		/// <summary>
		/// Gets or sets webDriver storage for parallelization in a single machine
		/// </summary>
		private IWebDriver NativeDriverInstance
		{
			get => _webDrivers.Value;

			set => _webDrivers.Value = value;
		}

		/// <summary>
		/// Start the browser instance
		/// </summary>
		public void Start()
		{
			// Location of the driver executable, since we're adding the driver via Nuget, they're placed in the bin directory
			var driverDirectory = AppDomain.CurrentDomain.BaseDirectory;

			var chromeOptions = ChromeProfile;
			NativeDriverInstance = new ChromeDriver(driverDirectory, chromeOptions);
			_eventFiringDrivers.Value = new EventFiringBrowser(NativeDriverInstance);

			SetTimeouts();

			Driver.DeleteAllCookies();
		}

		private void SetTimeouts()
		{
			NativeDriverInstance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			NativeDriverInstance.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
			NativeDriverInstance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
		}
	}
}
