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
			Browser.WaitForUrlToBeOpened($"{Url}", TimeSpan.FromSeconds(5));
		}

		public virtual void Open()
		{
			Browser.NavigateTo($"{Url}");
			WaitToBeOpened();
		}
	}
}
