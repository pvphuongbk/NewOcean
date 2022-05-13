using NewOcean.Common.Enums;
using NewOcean.Data.SqlServer.Enums;
using NewOcean.Data.SqlServer.Etities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOcean.Data.SqlServer.Extensions
{
	public static class ModelBuilderExtensions
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Blog>().HasData(
				new Blog() { ID = Guid.Parse("6f8fad5b-d9cb-469f-a165-70867728950e"),Content = "Blog 1" },
				new Blog() { ID = Guid.Parse("6f8fad5b-d9cb-469f-a165-70867728ab56"), Content = "Blog 2" }
				);
		}
	}
}
