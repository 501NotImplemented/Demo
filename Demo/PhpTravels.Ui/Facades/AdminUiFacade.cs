using PhpTravels.Ui.Components.AddAdmin;
using PhpTravels.Ui.Components.AdminsManagement;
using PhpTravels.Ui.Components.Dashboard;
using PhpTravels.Ui.Entities;

namespace PhpTravels.Ui.Facades
{
	public class AdminUiFacade
	{
		private readonly AddAdminPage _addAdminPage;

		private readonly AdminsManagementPage _adminsManagementPage;

		private readonly DashboardPage _dashboardPage;

		public AdminUiFacade(AdminsManagementPage adminsManagementPage, AddAdminPage addAdminPage, DashboardPage dashboardPage)
		{
			_adminsManagementPage = adminsManagementPage;
			_addAdminPage = addAdminPage;
			_dashboardPage = dashboardPage;
		}

		public Admin AddAdmin(Admin newAdmin = null)
		{
			if (newAdmin == null)
			{
				newAdmin = new Admin();
			}

			_dashboardPage.Sidebar.NavigateTo(SidebarRootItem.Accounts, SidebarSubItem.Admins);
			_adminsManagementPage.WaitToBeOpened();
			_adminsManagementPage.ClickAddButton();

			_addAdminPage.WaitToBeOpened();
			_addAdminPage.AddAdmin(newAdmin);

			return newAdmin;
		}
	}
}
