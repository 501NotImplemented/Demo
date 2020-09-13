using System.Linq;

using OpenQA.Selenium;

namespace PhpTravels.Ui.Components.AdminsManagement
{
	public class AdminsGrid
	{
		private readonly IWebDriver _driver;

		internal AdminsGrid(IWebDriver driver)
		{
			_driver = driver;
		}

		public bool IsEmpty => Grid == null;

		private IWebElement Grid => _driver.FindElements(By.XPath("//table[@class='xcrud-list table table-striped table-hover']")).FirstOrDefault();

		public bool IsAdminPresent(string adminEmail)
		{
			if (IsEmpty)
			{
				return false;
			}

			var adminEmailCell = Grid.FindElements(By.XPath($"//td/a[text()='{adminEmail}']")).FirstOrDefault();
			var isPresent = adminEmailCell != null;
			return isPresent;
		}
	}
}
