using PhpTravels.Ui.Components;

namespace PhpTravels.Ui.Facades
{
	public class UserLoginFacade
	{
		private LoginPage LoginPage => new LoginPage();

		public void LoginAsDemoUser()
		{
			LoginPage.Open();
			LoginPage.Login(Configuration.PhpTravels.Settings.DemoUserName, Configuration.PhpTravels.Settings.DemoUserPassword);
		}
	}
}
