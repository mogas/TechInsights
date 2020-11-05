using AutoMapper;
using TechInsights.Entities.Models;

namespace TechInsights.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PortfolioClient, PortfolioClientDto>();
        }
    }
}
