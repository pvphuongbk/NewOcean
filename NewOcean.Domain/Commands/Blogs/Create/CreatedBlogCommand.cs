using NewOcean.Core.Commands;
using NewOcean.Data.Dto.Blog;

namespace NewOcean.Domain.Commands.Blogs
{
	public class CreatedBlogCommand : ICommand<CreatBlogResponse>
	{
		public CreateBlogDto CreateBlogDto { get; set; }
	}
}
