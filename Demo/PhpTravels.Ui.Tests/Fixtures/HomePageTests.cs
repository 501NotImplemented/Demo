using NUnit.Framework;
using PhpTravels.Ui.Components.Home;
using PhpTravels.Ui.Tests.Assertions;

namespace PhpTravels.Ui.Tests.Fixtures
{
	[TestFixture]
	[Parallelizable]
	public class HomePageTests : BaseUiTestFixture
	{
		private static HomePage HomePage => new HomePage();

		[Test]
		public void CanFindCheapestHotel()
		{
			UserLoginFacade.LoginAsDemoUser();
			HomePage.Open();

			var expectedHotel = new Hotel
			{
				Price = 20, Title = "Malmaison Manchester"
			};

			HomePage.FeaturedHotels.AssertCheapestHotelIs(expectedHotel);
		}
	}
}
