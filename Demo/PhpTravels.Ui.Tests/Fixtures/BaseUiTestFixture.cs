using Demo.Core;

using NUnit.Framework;

using PhpTravels.Ui.Components;
using PhpTravels.Ui.Components.Dashboard;
using PhpTravels.Ui.Facades;

namespace PhpTravels.Ui.Tests.Fixtures
{
	public class BaseUiTestFixture
	{
		protected static AccountPage AccountPage => new AccountPage();

		protected AdminLoginPage AdminLoginPage => new AdminLoginPage();

		protected DashboardPage DashboardPage => new DashboardPage();

		protected LoginFacade LoginFacade => new LoginFacade(UserLoginPage, AdminLoginPage, AccountPage, DashboardPage);

		protected UserLoginPage UserLoginPage => new UserLoginPage();

		[OneTimeTearDown]
		public void FixtureTeardown()
		{
			Browser.Quit();
		}

		[SetUp]
		public void Setup()
		{
			Browser.Start();
		}

		[TearDown]
		public void TestTearDown()
		{
			Browser.DeleteAllCookies();
		}
	}
}
