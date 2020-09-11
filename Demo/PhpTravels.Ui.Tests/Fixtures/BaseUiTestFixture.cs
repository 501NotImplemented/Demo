using Demo.Core;
using NUnit.Framework;
using PhpTravels.Ui.Facades;

namespace PhpTravels.Ui.Tests.Fixtures
{
	[TestFixture]
	public class BaseUiTestFixture
	{
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

		protected static UserLoginFacade UserLoginFacade => new UserLoginFacade();
	}
}
