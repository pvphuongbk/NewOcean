using NewOcean.Data.Dto.Base;
using System;

namespace NewOcean.Data.Dto.Blog
{
	public class CreateBlogDto
	{
		public Guid ID { get; set; }
		public string Content { get; set; }

		public string Description { get; set; }
	}
}
