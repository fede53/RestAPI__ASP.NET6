using AutoMapper;

namespace Cube.Api.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile() {
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficultyDTO>().ReverseMap();
                //.ForMember(dest => dest.Id, option=>options.MapFrom(src => src.RegionId));
        }

    }
}
