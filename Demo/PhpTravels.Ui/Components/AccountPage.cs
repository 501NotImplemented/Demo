using System;

using Demo.Core.Engine;

using OpenQA.Selenium;

namespace PhpTravels.Ui.Components
{
	public class AccountPage : BasePage
	{
		private readonly string _title = "My Account";

		public string CurrentDate
		{
			get
			{
				var element = Browser.Instance.FindElement(By.XPath("//div[@class='col-md-6 go-left RTL']"));
				return element.Text;
			}
		}

		public override string Url => $"{Configuration.PhpTravels.Settings.BaseUrl}account/";

		public override void WaitToBeOpened()
		{
			Browser.WaitForPageTitleToContain(_title);
			Browser.WaitForUrlToBeOpened(Url, TimeSpan.FromSeconds(3));
		}
	}
}
