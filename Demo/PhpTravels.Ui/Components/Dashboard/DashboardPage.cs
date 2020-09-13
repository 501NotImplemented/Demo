using Demo.Core;

using OpenQA.Selenium;

namespace PhpTravels.Ui.Components.Dashboard
{
	public class DashboardPage : BaseAdminPage
	{
		public DashboardPage(IWebDriver driver)
			: base(driver)
		{
		}

		public override string Title => "Dashboard";

		public override string Url => $"{Configuration.PhpTravels.Settings.BaseUrl}admin";

		public override void WaitToBeOpened()
		{
			Driver.WaitForPageTitleToContain(Title);
		}
	}
}
