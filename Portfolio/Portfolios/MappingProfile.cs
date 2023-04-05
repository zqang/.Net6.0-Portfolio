using AutoMapper;
using Portfolio.CommandsQueries;
using Portfolio.Dtos;
using Portfolio.Models;

namespace Portfolio.Portfolios
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, BlogPostDto>();
            CreateMap<CreateBlogPostCommand, BlogPost>();
            CreateMap<UpdateBlogPostCommand, BlogPost>();
        }
    }
}
