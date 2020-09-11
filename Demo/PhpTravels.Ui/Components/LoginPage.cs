using System.Threading.Tasks;
using Demo.Core;
using OpenQA.Selenium;

namespace PhpTravels.Ui.Components
{
	public class LoginPage : BasePage
	{
		public override string Url => "login";

		private IWebElement TxtEmail => Browser.Instance.FindElement(By.XPath("//input[@name='username']"));

		private IWebElement TxtPassword => Browser.Instance.FindElement(By.XPath("//input[@name='password']"));

		private IWebElement BtnLogin => Browser.Instance.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block loginbtn']"));

		public void SetEmail(string email)
		{
			TxtEmail.SendKeys(email);
		}

		public void SetPassword(string password)
		{
			TxtPassword.SendKeys(password);
		}

		public void ClickLoginButton()
		{
			BtnLogin.Click();
		}

		public void Login(string userName, string password)
		{
			Parallel.Invoke(() => SetEmail(userName), () => SetPassword(password));
			ClickLoginButton();
		}
	}
}
