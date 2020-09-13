using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace Demo.Core.Engine
{
	public class EventFiringBrowser : EventFiringWebDriver
	{
		public EventFiringBrowser(IWebDriver parentDriver)
			: base(parentDriver)
		{
		}

		/// <summary>
		/// Raises the <see cref="E:ElementClicked" /> event.
		/// </summary>
		/// <param name="e">The <see cref="WebElementEventArgs"/> instance containing the event data.</param>
		protected override void OnElementClicked(WebElementEventArgs e)
		{
			Parallel.Invoke(() => Browser.WaitForPageReadyStateToComplete(), () => Browser.WaitForActiveJQueryToComplete());

			base.OnElementClicked(e);
		}

		/// <summary>
		/// Raises the <see cref="E:ElementValueChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="WebElementEventArgs"/> instance containing the event data.</param>
		protected override void OnElementValueChanged(WebElementValueEventArgs e)
		{
			Browser.WaitForActiveJQueryToComplete();

			base.OnElementValueChanged(e);
		}

		/// <summary>
		/// Raises the <see cref="E:FindElement" /> event.
		/// </summary>
		/// <param name="e">The <see cref="WebElementEventArgs"/> instance containing the event data.</param>
		protected override void OnFindingElement(FindElementEventArgs e)
		{
			Parallel.Invoke(() => Browser.WaitForPageReadyStateToComplete(), () => Browser.WaitForActiveJQueryToComplete());

			base.OnFindingElement(e);
		}

		/// <summary>
		/// Raises the <see cref="E:Navigated" /> event.
		/// </summary>
		/// <param name="e">The <see cref="WebDriverNavigationEventArgs"/> instance containing the event data.</param>
		protected override void OnNavigated(WebDriverNavigationEventArgs e)
		{
			Parallel.Invoke(() => Browser.WaitForPageReadyStateToComplete(), () => Browser.WaitForActiveJQueryToComplete());

			base.OnNavigated(e);
		}
	}
}
