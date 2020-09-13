using NUnit.Framework;

using PhpTravels.Ui.Components.AddAdmin;
using PhpTravels.Ui.Components.AdminsManagement;
using PhpTravels.Ui.Facades;
using PhpTravels.Ui.Tests.Assertions;

namespace PhpTravels.Ui.Tests.Fixtures
{
	[TestFixture]
	[Parallelizable(ParallelScope.Children)]
	public class AdminTests : BaseUiTestFixture
	{
		private AddAdminPage AddAdminPage => new AddAdminPage();

		private AdminsManagementPage AdminsManagementPage => new AdminsManagementPage();

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
