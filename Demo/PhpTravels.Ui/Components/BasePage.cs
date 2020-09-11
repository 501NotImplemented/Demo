using System;
using Demo.Core;

namespace PhpTravels.Ui.Components
{
	public abstract class BasePage : IPage
	{
		public abstract string Url { get; }

		public bool IsOpened => Browser.Instance.Url.Equals(Url.ToLowerInvariant());

		public virtual void WaitToBeOpened()
		{
			Browser.WaitForUrlToBeOpened($"{Configuration.PhpTravels.Settings.BaseUrl}{Url}", TimeSpan.FromSeconds(10));
		}

		public void Open()
		{
			Browser.NavigateTo($"{Configuration.PhpTravels.Settings.BaseUrl.Trim()}{Url}");
		}
	}
}
