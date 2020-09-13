using Demo.Core;
using Demo.Core.Engine;

using NUnit.Framework;

using OpenQA.Selenium;

using PhpTravels.Ui.Components;
using PhpTravels.Ui.Components.Dashboard;
using PhpTravels.Ui.Workflows.Facades;

namespace PhpTravels.Ui.Tests.Fixtures
{
	public class BaseUiTestFixture
	{
		private readonly DriverContext _driverContext = new DriverContext();

		protected AccountPage AccountPage => new AccountPage(Driver);

		protected AdminLoginPage AdminLoginPage => new AdminLoginPage(Driver);

		protected DashboardPage DashboardPage => new DashboardPage(Driver);

		protected IWebDriver Driver { get; private set; }

		protected LoginFacade LoginFacade => new LoginFacade(UserLoginPage, AdminLoginPage, AccountPage, DashboardPage);

		protected UserLoginPage UserLoginPage => new UserLoginPage(Driver);

		[OneTimeTearDown]
		public void FixtureTeardown()
		{
			Driver.Quit();
		}

		[SetUp]
		public void Setup()
		{
			_driverContext.Start();
			Driver = _driverContext.Driver;
		}

		[TearDown]
		public void TestTearDown()
		{
			Driver.DeleteAllCookies();
		}
	}
}
