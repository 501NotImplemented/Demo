using PhpTravels.Ui.Components;

namespace PhpTravels.Ui.Tests.Assertions
{
	public static class AccountPageAssertions
	{
		public static void AssertCurrentDateIsDisplayed(this AccountPage page)
		{
			var actualDate = page.CurrentDate;
		}
	}
}
