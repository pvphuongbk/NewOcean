using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace NewOcean.Data.SqlServer.EF
{
	public class NewOceanDbContextFactory : IDesignTimeDbContextFactory<CommonDBContext>
	{
		public CommonDBContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath((Directory.GetCurrentDirectory()))
				.AddJsonFile("appsettings.json")
				.Build();

			var connectionString = configuration.GetConnectionString("NewOceanDb");

			var optionsBuilder = new DbContextOptionsBuilder<CommonDBContext>();
			optionsBuilder.UseSqlServer(connectionString);
			return new CommonDBContext(optionsBuilder.Options);
		}
	}
}
