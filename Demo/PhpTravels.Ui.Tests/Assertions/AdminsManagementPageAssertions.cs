using NUnit.Framework;

using PhpTravels.Ui.Components.AdminsManagement;

namespace PhpTravels.Ui.Tests.Assertions
{
	public static class AdminsManagementPageAssertions
	{
		public static void AssertAdminIsPresent(this AdminsGrid grid, string adminEmail)
		{
			var result = grid.IsAdminPresent(adminEmail);
			Assert.True(result, $"Admin with email '{adminEmail}' is not present in grid");
		}
	}
}
