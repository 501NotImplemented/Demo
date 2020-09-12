using Bogus;
using Bogus.DataSets;

using PhpTravels.Ui.Components.AddAdmin;

namespace PhpTravels.Ui.Entities
{
	public class Admin
	{
		public Admin()
		{
			FirstName = new Person().FirstName;
			LastName = new Person().LastName;
			Country = Country.Ukraine;
			Email = new Person().Email;
			Password = new Internet().Password();
			MobileNumber = new Faker().Phone.PhoneNumber();
			Address1 = $"{new Person().Address.City}{new Person().Address.Street}";
			Address2 = $"{new Person().Address.City}{new Person().Address.Street}";
		}

		public string Address1 { get; set; }

		public string Address2 { get; set; }

		public Country Country { get; set; }

		public string Email { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string MobileNumber { get; set; }

		public string Password { get; set; }
	}
}
