using AutoMapper;
using NewOcean.Core.Base;
using NewOcean.Core.Bus;
using NewOcean.Core.Handler;
using NewOcean.Data.SqlServer.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using NewOcean.Domain.Commands.Blogs;
using NewOcean.Data.SqlServer.Etities;

namespace NewOcean.Domain.CommandHandlers.Blogs
{
	public class UpdateBlogCommandHandler : CommandHandler, IRequestHandler<UpdateBlogCommand, UpdateBlogResponse>
	{
		private readonly ICommonRepository<Blog> _blogRepository;
		private readonly ICommonUoW _commonUoW;
		public UpdateBlogCommandHandler(IMediatorHandler bus, ICommonUoW commonUoW, ICommonRepository<Blog> blogRepository) : base(bus)
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
		public async Task<UpdateBlogResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			var response = new UpdateBlogResponse();
			try
			{
				var blog = _blogRepository.GetById(request.BlogDto.ID);
				// Check user exist
				if (blog == null)
				{
					response.Code = ErrorCodeMessage.BlogNotExisted.Key;
					response.Message = ErrorCodeMessage.BlogNotExisted.Value;
					return response;
				}

				// Update this user
				blog.Content = request.BlogDto.Content;
				blog.Description = request.BlogDto.Description;
				blog.ModifiedDate = DateTime.Now;

				_blogRepository.Update(blog);

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
