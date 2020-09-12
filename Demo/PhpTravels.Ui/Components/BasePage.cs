using System;

using Demo.Core;

using PhpTravels.Ui.Contracts;

namespace PhpTravels.Ui.Components
{
	public abstract class BasePage : IPage
	{
		public virtual bool IsOpened => Browser.Instance.Url.Equals(Url.ToLowerInvariant());

		public abstract string Url { get; }

		public virtual void Open()
		{
			Browser.NavigateTo($"{Url}");
			WaitToBeOpened();
		}

		public virtual void WaitToBeOpened()
		{
			Browser.WaitForUrlToBeOpened($"{Url}", TimeSpan.FromSeconds(5));
		}
	}
}
