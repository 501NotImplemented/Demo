using System;
using System.Threading.Tasks;
using Demo.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PhpTravels.Ui.Components
{
	public class LoginPage : BasePage
	{
		public override string Url => $"{Configuration.PhpTravels.Settings.BaseUrl}login";

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
			var wait = new WebDriverWait(Browser.Instance, TimeSpan.FromSeconds(3));
			wait.Until(ExpectedConditions.ElementToBeClickable(BtnLogin));
			BtnLogin.Click();
		}

		public override void WaitToBeOpened()
		{
			base.WaitToBeOpened();
			Wait.Until(() => BtnLogin.Enabled && TxtEmail.Enabled && TxtPassword.Enabled);
		}

		public void Login(string userName, string password)
		{
			Parallel.Invoke(() => SetEmail(userName), () => SetPassword(password));
			ClickLoginButton();
		}
	}
}
