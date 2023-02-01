using AutoMapper;

namespace Cube.Api.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile() {

            //CreateMap<Models.DTO.RegionDTO, Models.Domain.Region>().Ignore(record => record.Field);
            //CreateMap<Models.DTO.RegionDTO, Models.Domain.Region>().Ignore(record => record.Field);
            CreateMap<Models.Domain.Region, Models.DTO.RegionDTO>().ReverseMap();
                //.ForMember(dest => dest.Id, option=>options.MapFrom(src => src.RegionId));
        }

    }
}
