using OpenQA.Selenium;

using PhpTravels.Ui.Components.Dashboard;

namespace PhpTravels.Ui.Components.AdminsManagement
{
	public class AdminsManagementPage : BaseAdminPage
	{
		public AdminsManagementPage(IWebDriver driver)
			: base(driver)
		{
		}

		public AdminsGrid Grid => new AdminsGrid(Driver);

		public override string Title => "Admins Management";

		public override string Url => $"{Configuration.PhpTravels.Settings.BaseUrl}admin/accounts/admins/";

		private IWebElement BtnAdd => Driver.FindElement(By.XPath("//form[@class='add_button']/button"));

		public void ClickAddButton()
		{
			BtnAdd.Click();
		}
	}
}
