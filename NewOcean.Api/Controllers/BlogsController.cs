using Microsoft.AspNetCore.Mvc;
using NewOcean.Data.Dto.Blog;
using NewOcean.Domain.Commands.Blogs;
using NewOcean.Service.Interface;
using System.Threading.Tasks;

namespace NewOcean.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BlogsController : ControllerBase
	{
		private IBlogService _blogService;

		public BlogsController(IBlogService blogService)
		{
			_blogService = blogService;
		}
		[HttpPost("create")]
		public async Task<CreatBlogResponse> CreateBlog([FromBody] CreateBlogDto createBlogDto)
		{
			var users = await _blogService.Create(createBlogDto);
			return users;
		}

		[HttpPost("update")]
		public async Task<UpdateBlogResponse> UpdateBlog([FromBody] UpdateBlogDto updateBlogDto)
		{
			var users = await _blogService.Update(updateBlogDto);
			return users;
		}

		[HttpPost("get-by-date")]
		public async Task<GetBlogByDateResponse> GetBlogByDate([FromBody] GetBlogByDateDto getBlogByDateDto)
		{
			var users = await _blogService.GetByDate(getBlogByDateDto);
			return users;
		}
	}
}