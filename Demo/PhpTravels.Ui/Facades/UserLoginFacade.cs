using PhpTravels.Ui.Components;

namespace PhpTravels.Ui.Facades
{
	public class UserLoginFacade
	{
		private LoginPage LoginPage => new LoginPage();

		private static AccountPage AccountPage => new AccountPage();

		public void LoginAsDemoUser()
		{
			LoginPage.Open();
			LoginPage.Login(Configuration.PhpTravels.Settings.DemoUserName, Configuration.PhpTravels.Settings.DemoUserPassword);
			AccountPage.WaitToBeOpened();
		}
	}
}
