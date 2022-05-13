using AutoMapper;
using NewOcean.Data.Dto.Blog;
using NewOcean.Data.SqlServer.Etities;

namespace NewOcean.Service.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Blog, BlogDto>().ReverseMap();
        }
    }
}
