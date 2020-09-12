using NUnit.Framework;

using PhpTravels.Ui.Tests.Assertions;

namespace PhpTravels.Ui.Tests.Fixtures
{
	[TestFixture(Description = "UI tests for user account page")]
	[Parallelizable(ParallelScope.Children)]
	public class UserAccountTests : BaseUiTestFixture
	{
		[Test]
		public void CurrentDateIsDisplayedOnUserAccount()
		{
			LoginFacade.LoginAsDemoUser();
			AccountPage.AssertCurrentDateIsDisplayed();
		}
	}
}
