using AutoMapper;

namespace Cube.Api.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile() {
            CreateMap<Models.Domain.Walk, Models.DTO.WalkDTO>().ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficultyDTO>().ReverseMap();
            //.ForMember(dest => dest.Id, option=>options.MapFrom(src => src.RegionId));
        }

    }
}
