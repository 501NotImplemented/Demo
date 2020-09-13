using Demo.Core.Elements;

using OpenQA.Selenium;

namespace PhpTravels.Ui.Components.AddAdmin
{
	public class AddAdminForm
	{
		private readonly IWebDriver _driver;

		internal AddAdminForm(IWebDriver driver)
		{
			_driver = driver;
		}

		private IWebElement BtnSubmit => _driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block btn-lg']"));

		private Combobox CboCountry => new Combobox(_driver.FindElement(By.XPath("//div[@id='s2id_autogen1']")));

		private IWebElement TxtAddress1 => _driver.FindElement(By.XPath("//input[@name='address1']"));

		private IWebElement TxtAddress2 => _driver.FindElement(By.XPath("//input[@name='address2']"));

		private IWebElement TxtEmail => _driver.FindElement(By.XPath("//input[@name='email']"));

		private IWebElement TxtFirstName => _driver.FindElement(By.XPath("//input[@name='fname']"));

		private IWebElement TxtLastName => _driver.FindElement(By.XPath("//input[@name='lname']"));

		private IWebElement TxtMobileNumber => _driver.FindElement(By.XPath("//input[@name='mobile']"));

		private IWebElement TxtPassword => _driver.FindElement(By.XPath("//input[@name='password']"));

		public void ClickSubmitButton()
		{
			BtnSubmit.Click();
		}

		public void SetAddress1(string address1)
		{
			TxtAddress1.SendKeys(address1);
		}

		public void SetAddress2(string address2)
		{
			TxtAddress2.SendKeys(address2);
		}

		public void SetCountry(Country country)
		{
			CboCountry.Expand();
			CboCountry.SetText(country.ToString());
		}

		public void SetEmail(string email)
		{
			TxtEmail.SendKeys(email);
		}

		public void SetFirstName(string firstName)
		{
			TxtFirstName.SendKeys(firstName);
		}

		public void SetLastName(string lastName)
		{
			TxtLastName.SendKeys(lastName);
		}

		public void SetMobileNumber(string mobileNumber)
		{
			TxtMobileNumber.SendKeys(mobileNumber);
		}

		public void SetPassword(string password)
		{
			TxtPassword.SendKeys(password);
		}
	}
}
