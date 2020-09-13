using System;
using System.IO;

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

		public string AdminPassword => _configuration.GetSection("AdminSettings:Password").Value;

		public string AdminUserName => _configuration.GetSection("AdminSettings:Username").Value;

		public string BaseUrl => _configuration["BaseUrl"];

		public string DemoUserName => _configuration.GetSection("UserSettings:Username").Value;

		public string DemoUserPassword => _configuration.GetSection("UserSettings:Password").Value;

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
