using AutoMapper;
using PortfolioAPI.CommandsQueries;
using PortfolioAPI.Dtos;
using PortfolioAPI.Models;

namespace PortfolioAPI.PortfolioMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //BlogPost Mapper
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


            //Portfolio Mapper
            CreateMap<Portfolio, PortfolioDto>();
            CreateMap<CreatePortfolioCommand, Portfolio>();
            CreateMap<UpdatePortfolioCommand, Portfolio>();
            CreateMap<DeletePortfolioCommand, Portfolio>();



        }
    }
}
