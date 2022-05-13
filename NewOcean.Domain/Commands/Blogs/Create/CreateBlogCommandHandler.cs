using NewOcean.Core.Base;
using NewOcean.Core.Bus;
using NewOcean.Core.Handler;
using NewOcean.Data.SqlServer.Etities;
using NewOcean.Data.SqlServer.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewOcean.Domain.Commands.Blogs;

namespace NewOcean.Domain.CommandHandlers.Blogs
{
	public class CreateBlogCommandHandler : CommandHandler, IRequestHandler<CreatedBlogCommand, CreatBlogResponse>
	{
		private readonly ICommonRepository<Blog> _blogRepository;
		private readonly ICommonUoW _commonUoW;
		public CreateBlogCommandHandler(IMediatorHandler bus, ICommonUoW commonUoW, ICommonRepository<Blog> blogRepository) : base(bus)
		{
			_commonUoW = commonUoW;
			_blogRepository = blogRepository;
		}

		/// <summary>
		/// Handle command
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<CreatBlogResponse> Handle(CreatedBlogCommand request, CancellationToken cancellationToken)
		{
			var response = new CreatBlogResponse();
			try
			{
				var blog = _blogRepository.GetById(request.CreateBlogDto.ID);
				if (blog != null)
				{
					response.Code = ErrorCodeMessage.BlogExisted.Key;
					response.Message = ErrorCodeMessage.BlogExisted.Value;
					return response;
				}

				// Create new user
				var newBlog = new Blog
				{
					ID = request.CreateBlogDto.ID,
					Description = request.CreateBlogDto.Description,
					Content = request.CreateBlogDto.Content,
					CreatedDate = DateTime.Now
				};

				_blogRepository.Insert(newBlog);
				await _commonUoW.CommitAsync();
			}
			catch (Exception ex)
			{
				_commonUoW.RollBack();
				response.Code = ErrorCodeMessage.IncorrectFunction.Key;
				response.Message = ErrorCodeMessage.IncorrectFunction.Value;
				response.ErrorDetail = ex.ToString();
			}
			return response;
		}
	}
}
