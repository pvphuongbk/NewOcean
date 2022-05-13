using NewOcean.Core.Base;
using NewOcean.Data.Dto.Blog;
using NewOcean.Domain.Commands.Blogs;
using System;
using System.Threading.Tasks;

namespace NewOcean.Service.Interface
{
	public interface IBlogService : IBaseService
	{
		Task<CreatBlogResponse> Create(CreateBlogDto item);
		Task<UpdateBlogResponse> Update(UpdateBlogDto item);
		Task<GetBlogByDateResponse> GetByDate(GetBlogByDateDto item);
	}
}
