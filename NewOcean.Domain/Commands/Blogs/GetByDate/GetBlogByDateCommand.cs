using NewOcean.Core.Commands;
using NewOcean.Data.Dto.Blog;
using System;

namespace NewOcean.Domain.Commands.Blogs
{
	public class GetBlogByDateCommand : ICommand<GetBlogByDateResponse>
	{
		public GetBlogByDateDto GetBlogByDateDto { get; set; }
	}
}
