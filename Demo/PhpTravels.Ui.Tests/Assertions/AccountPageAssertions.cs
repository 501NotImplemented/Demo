using System;
using System.Globalization;
using NUnit.Framework;
using PhpTravels.Ui.Components;

namespace PhpTravels.Ui.Tests.Assertions
{
	public static class AccountPageAssertions
	{
		public static void AssertCurrentDateIsDisplayed(this AccountPage page)
		{
			var actualDate = page.CurrentDate;
			var expectedDate = DateTime.UtcNow.Date.ToString("dd MMMM yyyy", new DateTimeFormatInfo());
			StringAssert.AreEqualIgnoringCase(expectedDate, actualDate, "Displayed date does not match today date on account page");
		}
	}
}
