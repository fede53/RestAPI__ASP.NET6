using AutoMapper;

namespace Cube.RestApi.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile() {

            CreateMap<Models.Entities.User, Models.DTO.UserDTO>().ReverseMap();
        }

    }
}
