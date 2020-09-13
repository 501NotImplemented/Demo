using PhpTravels.Ui.Components.Dashboard;
using PhpTravels.Ui.Entities;

namespace PhpTravels.Ui.Components.AddAdmin
{
	public class AddAdminPage : BaseAdminPage
	{
		public AddAdminForm AddAdminForm => new AddAdminForm();

		public override string Title => "Add Admin";

		public override string Url => $"{Configuration.PhpTravels.Settings.BaseUrl}admin/accounts/admins/add";

		public void AddAdmin(Admin newAdmin)
		{
			AddAdminForm.SetFirstName(newAdmin.FirstName);
			AddAdminForm.SetLastName(newAdmin.LastName);
			AddAdminForm.SetEmail(newAdmin.Email);
			AddAdminForm.SetPassword(newAdmin.Password);
			AddAdminForm.SetMobileNumber(newAdmin.MobileNumber);
			AddAdminForm.SetCountry(newAdmin.Country);
			AddAdminForm.SetAddress1(newAdmin.Address1);
			AddAdminForm.SetAddress2(newAdmin.Address2);

			AddAdminForm.ClickSubmitButton();
		}
	}
}
