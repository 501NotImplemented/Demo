using NUnit.Framework;
using PhpTravels.Ui.Components;
using PhpTravels.Ui.Tests.Assertions;

namespace PhpTravels.Ui.Tests.Fixtures
{
	[TestFixture(Description = "UI tests for user account page")]
	[Parallelizable]
	public class UserAccountTests : BaseUiTestFixture
	{
		private static AccountPage AccountPage => new AccountPage();

		[Test]
		public void CurrentDateIsDisplayedOnUserAccount()
		{
			UserLoginFacade.LoginAsDemoUser();
			AccountPage.AssertCurrentDateIsDisplayed();
		}
	}
}
