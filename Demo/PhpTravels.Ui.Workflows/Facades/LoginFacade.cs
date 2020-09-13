using PhpTravels.Ui.Components;
using PhpTravels.Ui.Components.Dashboard;

namespace PhpTravels.Ui.Workflows.Facades
{
	public class LoginFacade
	{
		private readonly AccountPage _accountPage;

		private readonly AdminLoginPage _adminLoginPage;

		private readonly DashboardPage _dashboardPage;

		private readonly UserLoginPage _userLoginPage;

		public LoginFacade(UserLoginPage userLoginPage, AdminLoginPage adminLoginPage, AccountPage accountPage, DashboardPage dashboardPage)
		{
			_accountPage = accountPage;
			_adminLoginPage = adminLoginPage;
			_dashboardPage = dashboardPage;
			_userLoginPage = userLoginPage;
		}

		public void LoginAsAdmin()
		{
			_adminLoginPage.Open();
			_adminLoginPage.Login(Configuration.PhpTravels.Settings.AdminUserName, Configuration.PhpTravels.Settings.AdminPassword);
			_dashboardPage.WaitToBeOpened();
		}

		public void LoginAsDemoUser()
		{
			_userLoginPage.Open();
			_userLoginPage.Login(Configuration.PhpTravels.Settings.DemoUserName, Configuration.PhpTravels.Settings.DemoUserPassword);
			_accountPage.WaitToBeOpened();
		}
	}
}
