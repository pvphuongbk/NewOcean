using NewOcean.Core.Base;
using FakeItEasy;
using System;
using System.Threading.Tasks;
using Xunit;
using NewOcean.Service.Interface;
using NewOcean.Api.Controllers;
using Moq;
using System.Linq.Expressions;
using NewOcean.Domain.Commands.Blogs;
using NewOcean.Data.Dto.Blog;

namespace Test.NewOcean.Api
{
	public class BlogControllerTests
	{
		[Fact]
		public async Task Test_CreateBlog()
		{
			// Mock
			var blogService = A.Fake<IBlogService>();
			CreateBlogDto createBlogDto = new CreateBlogDto();
			CreatBlogResponse creatBlogResponse = new CreatBlogResponse();
			A.CallTo(() => blogService.Create(createBlogDto)).Returns(Task.FromResult(creatBlogResponse));
			var blogController = new BlogsController(blogService);

			// Act
			var testResult = await blogController.CreateBlog(createBlogDto);

			// Assert
			Assert.Equal(0, testResult.Code);
		}

		[Fact]
		public async Task Test_UpdateBlog()
		{
			// Mock
			var blogService = A.Fake<IBlogService>();
			UpdateBlogDto updateBlogDto = new UpdateBlogDto();
			UpdateBlogResponse updateBlogResponse = new UpdateBlogResponse();
			A.CallTo(() => blogService.Update(updateBlogDto)).Returns(Task.FromResult(updateBlogResponse));
			var blogController = new BlogsController(blogService);

			// Act
			var testResult = await blogController.UpdateBlog(updateBlogDto);

			// Assert
			Assert.Equal(0, testResult.Code);
		}

		[Fact]
		public async Task Test_GetBlogByDate()
		{
			// Mock
			var blogService = A.Fake<IBlogService>();
			GetBlogByDateDto getBlogByDateDto = new GetBlogByDateDto();
			GetBlogByDateResponse getBlogByDateResponse = new GetBlogByDateResponse();
			A.CallTo(() => blogService.GetByDate(getBlogByDateDto)).Returns(Task.FromResult(getBlogByDateResponse));
			var blogController = new BlogsController(blogService);

			// Act
			var testResult = await blogController.GetBlogByDate(getBlogByDateDto);

			// Assert
			Assert.Equal(0, testResult.Code);
		}
	}
}
