using OpenQA.Selenium;

namespace Demo.Core.Elements
{
	public class Combobox
	{
		private readonly IWebElement _wrappedComponent;

		public Combobox(IWebElement rawElement)
		{
			_wrappedComponent = rawElement;
		}

		private IWebElement TxtInput => _wrappedComponent.FindElement(By.XPath("//input"));

		public void Expand()
		{
			_wrappedComponent.Click();
		}

		public void SetText(string text)
		{
			TxtInput.SendKeys(text);
			TxtInput.SendKeys(Keys.Enter);
		}
	}
}
