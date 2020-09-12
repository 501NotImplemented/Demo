using Demo.Core.Engine;

namespace PhpTravels.Ui.Components.Home
{
	public class HomePage : BasePage
	{
		private readonly string _title = "PHPTRAVELS |";

		public FeaturedHotelsSection FeaturedHotels => new FeaturedHotelsSection();

		public override string Url => Configuration.PhpTravels.Settings.BaseUrl.Trim();

		public override void WaitToBeOpened()
		{
			Browser.WaitForPageTitleToContain(_title);
		}
	}
}
