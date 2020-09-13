using Demo.Core;

using OpenQA.Selenium;

namespace PhpTravels.Ui.Components.Home
{
	public class HomePage : BasePage
	{
		private readonly string _title = "PHPTRAVELS |";

		public HomePage(IWebDriver driver)
			: base(driver)
		{
		}

		public FeaturedHotelsSection FeaturedHotels => new FeaturedHotelsSection(Driver);

		public override string Url => Configuration.PhpTravels.Settings.BaseUrl.Trim();

		public override void WaitToBeOpened()
		{
			Driver.WaitForPageTitleToContain(_title);
		}
	}
}
