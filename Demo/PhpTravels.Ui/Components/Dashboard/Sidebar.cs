using System;

using Demo.Core;

using OpenQA.Selenium;

namespace PhpTravels.Ui.Components.Dashboard
{
	public class Sidebar
	{
		internal Sidebar()
		{
		}

		public void NavigateTo(SidebarRootItem rootItem, SidebarSubItem subItem)
		{
			ExpandSidebarRoot(rootItem);
			ClickOnSideBarSubItem(subItem);
		}

		private void ClickOnSideBarSubItem(SidebarSubItem subItem)
		{
			var subItemLink = GetSubItemLink(subItem);
			subItemLink.Click();
		}

		private void ExpandSidebarRoot(SidebarRootItem rootItem)
		{
			var rootLink = GetRootLink(rootItem);

			if (IsRootLinkNotExpanded(rootLink))
			{
				rootLink.Click();
			}
		}

		private IWebElement GetRootLink(SidebarRootItem rootItem)
		{
			var link = Browser.Instance.FindElement(By.XPath($"//a[@href='#{rootItem.ToString().ToUpperInvariant()}']"));
			return link;
		}

		private IWebElement GetSubItemLink(SidebarSubItem subItem)
		{
			var link = Browser.Instance.FindElement(By.XPath($"//a[text()='{subItem}']"));
			return link;
		}

		private bool IsRootLinkNotExpanded(IWebElement rootLink)
		{
			var isExpanded = Convert.ToBoolean(rootLink.GetAttribute("aria-expanded"));
			return !isExpanded;
		}
	}
}
