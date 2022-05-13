using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewOcean.Data.SqlServer.Etities;
namespace NewOcean.Data.SqlServer.Configurations
{
	public class BlogConfiguration : IEntityTypeConfiguration<Blog>
	{
		public void Configure(EntityTypeBuilder<Blog> builder)
		{
			builder.ToTable("Blog");
			builder.Property(x => x.ID).IsRequired();
		}
	}
}
