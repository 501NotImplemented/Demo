using System;
using System.Threading.Tasks;

using Demo.Core;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PhpTravels.Ui.Components
{
	public class AdminLoginPage : BasePage
	{
		private readonly string _title = "Administator Login";

		public AdminLoginPage(IWebDriver driver)
			: base(driver)
		{
		}

		public override string Url => $"{Configuration.PhpTravels.Settings.BaseUrl}admin";

		private IWebElement BtnLogin => Driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block ladda-button fadeIn animated btn-lg']"));

		private IWebElement TxtEmail => Driver.FindElement(By.XPath("//input[@name='email']"));

		private IWebElement TxtPassword => Driver.FindElement(By.XPath("//input[@name='password']"));

		public void ClickLoginButton()
		{
			var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
			wait.Until(ExpectedConditions.ElementToBeClickable(BtnLogin));
			BtnLogin.Click();
		}

		public void Login(string userName, string password)
		{
			Parallel.Invoke(() => SetEmail(userName), () => SetPassword(password));
			ClickLoginButton();
		}

		public void SetEmail(string email)
		{
			TxtEmail.SendKeys(email);
		}

		public void SetPassword(string password)
		{
			TxtPassword.SendKeys(password);
		}

		public override void WaitToBeOpened()
		{
			Driver.WaitForPageTitleToContain(_title);
			base.WaitToBeOpened();
			Wait.Until(() => BtnLogin.Enabled && TxtEmail.Enabled && TxtPassword.Enabled);
		}
	}
}
