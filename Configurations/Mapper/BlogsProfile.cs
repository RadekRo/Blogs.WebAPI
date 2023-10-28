using AutoMapper;
using Blogs.WebAPI.Domain;
using Blogs.WebAPI.DTOs;

namespace Blogs.WebAPI.Configurations.Mapper
{
    public class BlogsProfile : Profile
    {
        public BlogsProfile() 
        {
            CreateMap<Blog, BlogDto>();
            CreateMap<Blog, BlogDetailDto>();
            CreateMap<Post, PostDto>();
        }
    }
}
