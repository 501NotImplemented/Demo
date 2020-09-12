using Demo.Core.Engine;

namespace PhpTravels.Ui.Components.Dashboard
{
	public abstract class BaseAdminPage : BasePage
	{
		public Sidebar Sidebar => new Sidebar();

		public abstract string Title { get; }

		public override void WaitToBeOpened()
		{
			Browser.WaitForPageTitleToContain(Title);
			base.WaitToBeOpened();
		}
	}
}
