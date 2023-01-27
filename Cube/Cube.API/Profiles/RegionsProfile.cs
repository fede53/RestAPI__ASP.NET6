using AutoMapper;

namespace Cube.API.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile() {
            CreateMap<Models.Domain.Region, Models.DTO.RegionDTO>().ReverseMap();
                //.ForMember(dest => dest.Id, option=>options.MapFrom(src => src.RegionId));
        }

    }
}
