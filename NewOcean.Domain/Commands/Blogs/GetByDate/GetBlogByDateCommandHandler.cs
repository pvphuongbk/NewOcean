using AutoMapper;
using MediatR;
using NewOcean.Core.Base;
using NewOcean.Core.Bus;
using NewOcean.Core.Handler;
using NewOcean.Data.Dto.Blog;
using NewOcean.Data.SqlServer.Etities;
using NewOcean.Data.SqlServer.Interfaces;
using NewOcean.Domain.Commands.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewOcean.Domain.CommandHandlers.Blogs
{
	public class GetBlogByDateCommandHandler : CommandHandler, IRequestHandler<GetBlogByDateCommand, GetBlogByDateResponse>
	{
		private IMediatorHandler _bus;
		private readonly ICommonRepository<Blog> _blogRepository;
		private readonly ICommonUoW _commonUoW;
		private readonly IMapper _mapper;
		public GetBlogByDateCommandHandler(IMediatorHandler bus, ICommonUoW commonUoW, IMapper mapper, ICommonRepository<Blog> blogRepository) : base(bus)
		{
			_bus = bus;
			_commonUoW = commonUoW;
			_mapper = mapper;
			_blogRepository = blogRepository;
		}

		/// <summary>
		/// Handle command
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<GetBlogByDateResponse> Handle(GetBlogByDateCommand request, CancellationToken cancellationToken)
		{
			var response = new GetBlogByDateResponse();
			try
			{
				var task = await _blogRepository.FindAllAsync(x=> !x.IsDeleted && x.CreatedDate >= request.GetBlogByDateDto.From && x.CreatedDate <= request.GetBlogByDateDto.To);
				var blogs = task.ToList();
				if (blogs != null)
				{
					var dtos = _mapper.Map<List<Blog>, List<BlogDto>>(blogs);
					response.Data = dtos;
				}
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
