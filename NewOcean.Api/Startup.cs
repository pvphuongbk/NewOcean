using NewOcean.Core.Bus;
using NewOcean.Data.SqlServer.EF;
using NewOcean.Data.SqlServer.Interfaces;
using NewOcean.Data.SqlServer.Repositories;
using NewOcean.Data.SqlServer.UnitOfWork;
using NewOcean.Service.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using NewOcean.Domain.Commands.Blogs;
using NewOcean.Service.Interface;
using NewOcean.Service.Implememt;
using System.Linq;

namespace NewOcean.Api
{
	public class Startup
	{
		private readonly IConfiguration _config;
		public Startup(IConfiguration configuration)
		{
			_config = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "NewOcean.Api", Version = "v1" });
				c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
			});

			services.AddCors(option =>
			{
				option.AddDefaultPolicy(builder =>
				{
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
				});
			});


			#region Dependency
			//services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			//	.AddMicrosoftIdentityWebApi(_config, "AzureAd");
			services.AddDbContext<CommonDBContext>(options =>

				options.UseSqlServer(_config.GetConnectionString("NewOceanDb")), ServiceLifetime.Scoped
			);

			// Auto maper
			services.AddCommonServices();


			services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));
			services.AddScoped<ICommonUoW,CommonUoW>();

			// Mediator
			services.AddMediatR(typeof(CreatedBlogCommand).GetTypeInfo().Assembly);
			services.AddScoped<IMediatorHandler, InMemoryBus>();

			// Service
			services.AddScoped<IBlogService, BlogService>();

			// Redis Repository
			//services.AddScoped<IUserRepositoryRedis, UserRepositoryRedis>();

			// Redis
			//string redisConnection = _config.GetSection("MyConfigs")["RedisConnection"];
			//services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));
			//services.AddSingleton<IDatabase>(sp =>
			//{
			//	var con = sp.GetService<IConnectionMultiplexer>();
			//	return con.GetDatabase();
			//});
			#endregion
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewOcean.Api v1"));
			}
			app.UseDeveloperExceptionPage();
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
