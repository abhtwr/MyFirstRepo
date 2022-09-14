using AutoMapper;

namespace MyFirst.WebAPI.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>();
        }
    }
}
