using System;

using Demo.Core;

using OpenQA.Selenium;

namespace PhpTravels.Ui.Components
{
	public class AccountPage : BasePage
	{
		private readonly string _title = "My Account";

		public AccountPage(IWebDriver driver)
			: base(driver)
		{
		}

		public string CurrentDate
		{
			get
			{
				var element = Driver.FindElement(By.XPath("//div[@class='col-md-6 go-left RTL']"));
				return element.Text;
			}
		}

		public override string Url => $"{Configuration.PhpTravels.Settings.BaseUrl}account/";

		public override void WaitToBeOpened()
		{
			Driver.WaitForPageTitleToContain(_title);
			Driver.WaitForUrlToBeOpened(Url, TimeSpan.FromSeconds(3));
		}
	}
}
