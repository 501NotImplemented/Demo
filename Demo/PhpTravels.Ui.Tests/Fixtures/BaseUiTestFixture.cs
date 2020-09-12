using Demo.Core;
using NUnit.Framework;
using PhpTravels.Ui.Facades;

namespace PhpTravels.Ui.Tests.Fixtures
{
	public class BaseUiTestFixture
	{
		protected static UserLoginFacade UserLoginFacade => new UserLoginFacade();

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

		[OneTimeTearDown]
		public void FixtureTeardown()
		{
			Browser.Quit();
		}
	}
}
