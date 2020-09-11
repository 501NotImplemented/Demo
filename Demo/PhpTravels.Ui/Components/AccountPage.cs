using Demo.Core;
using OpenQA.Selenium;

namespace PhpTravels.Ui.Components
{
	public class AccountPage : BasePage
	{
		public override string Url => "account/";

		public string CurrentDate
		{
			get
			{
				var element = Browser.Instance.FindElement(By.XPath("//div[@class='col-md-6 go-left RTL']"));
				return element.Text;
			}
		}
	}
}
