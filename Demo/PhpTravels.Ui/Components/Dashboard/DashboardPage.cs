using Demo.Core;

namespace PhpTravels.Ui.Components.Dashboard
{
	public class DashboardPage : BaseAdminPage
	{
		public override string Title => "Dashboard";

		public override string Url => $"{Configuration.PhpTravels.Settings.BaseUrl}admin";

		public override void WaitToBeOpened()
		{
			Browser.WaitForPageTitleToContain(Title);
		}
	}
}
