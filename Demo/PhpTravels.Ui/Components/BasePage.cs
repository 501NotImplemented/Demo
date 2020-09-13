using System;

using Demo.Core;

using OpenQA.Selenium;

using PhpTravels.Ui.Contracts;

namespace PhpTravels.Ui.Components
{
	public abstract class BasePage : IPage
	{
		protected BasePage(IWebDriver driver)
		{
			Driver = driver;
		}

		public virtual bool IsOpened => Driver.Url.Equals(Url.ToLowerInvariant());

		public abstract string Url { get; }

		protected IWebDriver Driver { get; set; }

		public virtual void Open()
		{
			Driver.NavigateTo($"{Url}");
			WaitToBeOpened();
		}

		public virtual void WaitToBeOpened()
		{
			Driver.WaitForUrlToBeOpened($"{Url}", TimeSpan.FromSeconds(5));
		}
	}
}
