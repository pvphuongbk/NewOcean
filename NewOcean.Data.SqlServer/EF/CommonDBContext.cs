using Microsoft.EntityFrameworkCore;
using NewOcean.Data.SqlServer.Configurations;
using NewOcean.Data.SqlServer.Etities;

namespace NewOcean.Data.SqlServer.EF
{
	public class CommonDBContext : PDataContext
	{
		public CommonDBContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder moduleBuilder)
		{
			moduleBuilder.ApplyConfiguration(new BlogConfiguration());

			// Seeding data
			//moduleBuilder.Seed();
			//base.OnModelCreating(moduleBuilder);
		}
		public DbSet<Blog> Blog { get; set; }
	}
}
