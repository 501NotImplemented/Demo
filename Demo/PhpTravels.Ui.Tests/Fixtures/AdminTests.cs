using NUnit.Framework;

using PhpTravels.Ui.Components.AddAdmin;
using PhpTravels.Ui.Components.AdminsManagement;
using PhpTravels.Ui.Tests.Assertions;
using PhpTravels.Ui.Workflows.Facades;

namespace PhpTravels.Ui.Tests.Fixtures
{
	[TestFixture]
	[Parallelizable(ParallelScope.All)]
	public class AdminTests : BaseUiTestFixture
	{
		private AddAdminPage AddAdminPage => new AddAdminPage(Driver);

		private AdminsManagementPage AdminsManagementPage => new AdminsManagementPage(Driver);

		private AdminUiFacade AdminUiFacade => new AdminUiFacade(AdminsManagementPage, AddAdminPage, DashboardPage);

		[Test]
		public void CanCreateNewAdmin()
		{
			LoginFacade.LoginAsAdmin();

			var newAdmin = AdminUiFacade.AddAdmin();
			AdminsManagementPage.Grid.AssertAdminIsPresent(newAdmin.Email);
		}
	}
}
