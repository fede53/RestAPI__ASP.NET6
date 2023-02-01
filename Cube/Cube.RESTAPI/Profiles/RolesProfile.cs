using AutoMapper;

namespace Cube.RestApi.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile() {

            CreateMap<Models.Entities.Role, Models.DTO.RoleDTO>().ReverseMap();
        }

    }
}
