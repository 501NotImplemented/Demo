using Demo.Core;

namespace PhpTravels.Ui.Components.Home
{
	public class HomePage : BasePage
	{
		private readonly string _title = "PHPTRAVELS |";

		public override string Url => Configuration.PhpTravels.Settings.BaseUrl.Trim();

		public FeaturedHotelsSection FeaturedHotels => new FeaturedHotelsSection();

		public override void WaitToBeOpened()
		{
			Browser.WaitForPageTitleToContain(_title);
		}
	}
}
