using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using PhpTravels.Ui.Components;
using PhpTravels.Ui.Components.Home;

namespace PhpTravels.Ui.Tests.Assertions
{
	public static class AccountPageAssertions
	{
		public static void AssertCurrentDateIsDisplayed(this AccountPage page)
		{
			var actualDate = page.CurrentDate;
			var expectedDate = DateTime.Now.Date.ToString("dd MMMM yyyy", new DateTimeFormatInfo());
			StringAssert.AreEqualIgnoringCase(expectedDate, actualDate, "Displayed date does not match today date on account page");
		}

		public static void AssertCheapestHotelIs(this FeaturedHotelsSection section, Hotel expectedHotel)
		{
			var cheapestHotel = section.Cheapest;
			cheapestHotel.Should().BeEquivalentTo(expectedHotel, "Cheapest hotel should match the expected");
		}
	}
}
