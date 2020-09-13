using Demo.Core;

using OpenQA.Selenium;

namespace PhpTravels.Ui.Components.Dashboard
{
	public abstract class BaseAdminPage : BasePage
	{
		protected BaseAdminPage(IWebDriver driver)
			: base(driver)
		{
		}

		public Sidebar Sidebar => new Sidebar(Driver);

		public abstract string Title { get; }

		public override void WaitToBeOpened()
		{
			Driver.WaitForPageTitleToContain(Title);
			base.WaitToBeOpened();
		}
	}
}
