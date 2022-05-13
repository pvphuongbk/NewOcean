using NewOcean.Core.Commands;
using NewOcean.Data.Dto.Blog;

namespace NewOcean.Domain.Commands.Blogs
{
	public class UpdateBlogCommand : ICommand<UpdateBlogResponse>
	{
		public UpdateBlogDto BlogDto { get; set; }
	}
}
