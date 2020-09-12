using System.Linq;

using Demo.Core;

using OpenQA.Selenium;

namespace PhpTravels.Ui.Components.AdminsManagement
{
	public class AdminsGrid
	{
		internal AdminsGrid()
		{
		}

		public bool IsEmpty => Grid == null;

		private IWebElement Grid => Browser.Instance.FindElements(By.XPath("//table[@class='xcrud-list table table-striped table-hover']")).FirstOrDefault();

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
