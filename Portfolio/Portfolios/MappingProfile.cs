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
            CreateMap<CreateBlogPostCommand, BlogPost>()
                .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<UpdateBlogPostCommand, BlogPost>()
                .ForMember(dest => dest.UpdatedAt,
                opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<DeleteBlogPostCommand, BlogPost>();
        }
    }
}
