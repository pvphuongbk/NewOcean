using AutoMapper;
using FakeItEasy;
using Moq;
using NewOcean.Core.Bus;
using NewOcean.Data.Dto.Blog;
using NewOcean.Data.SqlServer.Etities;
using NewOcean.Data.SqlServer.Interfaces;
using NewOcean.Domain.CommandHandlers.Blogs;
using NewOcean.Domain.Commands.Blogs;
using NewOcean.Service.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Test.Bocasay.Api.Handler
{
	public class BlogHandlerTest
	{
		[Fact]
		public async Task Test_CreateBlog()
		{
			// Mock
			Mock<IMediatorHandler> iMediatorHandler = new Mock<IMediatorHandler>();
			Mock<ICommonUoW> commonUoW = new Mock<ICommonUoW>();
			Mock<ICommonRepository<Blog>> iCommonRepository = new Mock<ICommonRepository<Blog>>();
			CreateBlogCommandHandler createBlogCommandHandler = 
				new CreateBlogCommandHandler(iMediatorHandler.Object, commonUoW.Object, iCommonRepository.Object);
			var blogRepository = A.Fake<ICommonRepository<Blog>>();

			Guid id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
			CreatedBlogCommand createdBlogCommand = new CreatedBlogCommand
			{
				CreateBlogDto = new CreateBlogDto { ID = id }
			};
			Blog blog = new Blog { ID = id };
			A.CallTo(() => blogRepository.GetById(id)).Returns(blog);

			// Act
			var testResult = await createBlogCommandHandler.Handle(createdBlogCommand, CancellationToken.None);

			// Assert
			Assert.Equal(0, testResult.Code);
		}

		[Fact]
		public async Task Test_UpdateBlog()
		{
			// Mock
			Mock<IMediatorHandler> iMediatorHandler = new Mock<IMediatorHandler>();
			Mock<ICommonUoW> commonUoW = new Mock<ICommonUoW>();
			Mock<ICommonRepository<Blog>> blogRepository = new Mock<ICommonRepository<Blog>>();
			UpdateBlogCommandHandler updateBlogCommandHandler =
				new UpdateBlogCommandHandler(iMediatorHandler.Object, commonUoW.Object, blogRepository.Object);

			Guid id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
			UpdateBlogCommand updateBlogCommand = new UpdateBlogCommand
			{
				BlogDto = new UpdateBlogDto { ID = id }
			};
			Blog blog = new Blog { ID = id };
			blogRepository.Setup(x => x.GetById(id)).Returns(blog);

			// Act
			var testResult = await updateBlogCommandHandler.Handle(updateBlogCommand, CancellationToken.None);

			// Assert
			Assert.Equal(0, testResult.Code);
		}

		[Fact]
		public async Task Test_GetBlogByDate()
		{
			// Mock
			Mock<IMediatorHandler> iMediatorHandler = new Mock<IMediatorHandler>();
			Mock<ICommonUoW> commonUoW = new Mock<ICommonUoW>();
			Mock<ICommonRepository<Blog>> blogRepository = new Mock<ICommonRepository<Blog>>();
			Mock<IMediatorHandler> bus = new Mock<IMediatorHandler>();
			IMapper _mapper;
			var mapperConfig = new MapperConfiguration(c =>
			{
				c.AddProfile<AutoMapperProfile>();
			});

			_mapper = mapperConfig.CreateMapper();

			GetBlogByDateCommandHandler getBlogByDateCommandHandler =
				new GetBlogByDateCommandHandler(bus.Object, commonUoW.Object, _mapper, blogRepository.Object);

			DateTime from = new DateTime(2022, 5, 13, 1, 0, 0);
			DateTime to = new DateTime(2022, 2, 13, 2, 0, 0);
			GetBlogByDateCommand getBlogByDateCommand = new GetBlogByDateCommand
			{
				GetBlogByDateDto = new GetBlogByDateDto { From = from, To = to }
			};
			Guid id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
			IEnumerable<Blog> blogs = new List<Blog>()
			{
				new Blog { ID = id }
			}.AsEnumerable();
			blogRepository.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<Blog, bool>>>())).Returns(Task.FromResult(blogs));

			// Act
			var testResult = await getBlogByDateCommandHandler.Handle(getBlogByDateCommand, CancellationToken.None);

			// Assert
			Assert.Equal(0, testResult.Code);
		}
	}
}
