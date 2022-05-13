using NewOcean.Core.Bus;
using NewOcean.Data.Dto.Blog;
using NewOcean.Domain.Commands.Blogs;
using NewOcean.Service.Interface;
using System.Threading.Tasks;

namespace NewOcean.Service.Implememt
{
	public class BlogService : IBlogService
	{
		private readonly IMediatorHandler _bus;
		public BlogService(IMediatorHandler bus)
		{
			_bus = bus;
		}

		public async Task<CreatBlogResponse> Create(CreateBlogDto item)
		{
			var createCommand = new CreatedBlogCommand { CreateBlogDto = item };
			var result = await  _bus.SendCommand<CreatedBlogCommand, CreatBlogResponse>(createCommand);
			return result;
		}

		public async Task<GetBlogByDateResponse> GetByDate(GetBlogByDateDto item)
		{
			var createCommand = new GetBlogByDateCommand { GetBlogByDateDto = item };
			var result = await _bus.SendCommand<GetBlogByDateCommand, GetBlogByDateResponse>(createCommand);
			return result;
		}

		public async Task<UpdateBlogResponse> Update(UpdateBlogDto item)
		{
			var createCommand = new UpdateBlogCommand { BlogDto = item };
			var result = await _bus.SendCommand<UpdateBlogCommand, UpdateBlogResponse>(createCommand);
			return result;
		}
	}
}
