using NewOcean.Data.SqlServer.Base;

namespace NewOcean.Data.SqlServer.Etities
{
	public class Blog : BaseEntity
	{
		public Blog()
		{
			IsDeleted = false;
		}
		public string Content { get; set; }

		public string Description { get; set; }
	}
}
