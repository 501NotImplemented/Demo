using NUnit.Framework;

using PhpTravels.Ui.Components.Home;
using PhpTravels.Ui.Entities;
using PhpTravels.Ui.Tests.Assertions;

namespace PhpTravels.Ui.Tests.Fixtures
{
	[TestFixture]
	[Parallelizable(ParallelScope.All)]
	public class HomePageTests : BaseUiTestFixture
	{
		private HomePage HomePage => new HomePage(Driver);

		[Test]
		public void CanFindCheapestHotel()
		{
			LoginFacade.LoginAsDemoUser();
			HomePage.Open();

			var expectedHotel = new Hotel
									{
										Price = 20, Title = "Malmaison Manchester"
									};

			HomePage.FeaturedHotels.AssertCheapestHotelIs(expectedHotel);
		}
	}
}
