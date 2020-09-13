using System;
using System.IO;
using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhpTravels.Configuration
{
	public class PhpTravelsSettings
	{
		private IConfigurationRoot _configuration;

		internal PhpTravelsSettings()
		{
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
		}

		public string AdminPassword
		{
			get
			{
				var initialValue = _configuration.GetSection("AdminSettings:Password").Value;
				var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(initialValue));
				return decoded;
			}
		}

		public string AdminUserName
		{
			get
			{
				var initialValue = _configuration.GetSection("AdminSettings:Username").Value;
				var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(initialValue));
				return decoded;
			}
		}

		public string BaseUrl => _configuration["BaseUrl"];

		public string DemoUserName
		{
			get
			{
				var initialValue = _configuration.GetSection("UserSettings:Username").Value;
				var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(initialValue));
				return decoded;
			}
		}

		public string DemoUserPassword
		{
			get
			{
				var initialValue = _configuration.GetSection("UserSettings:Password").Value;
				var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(initialValue));
				return decoded;
			}
		}

		private void ConfigureServices(IServiceCollection serviceCollection)
		{
			_configuration = new ConfigurationBuilder()
							.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
							.AddJsonFile("appsettings.json", false)
							.Build();

			serviceCollection.AddSingleton(_configuration);
		}
	}
}
