using Cube.RestApi.Models.Entities;

namespace Cube.RestApi.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleDTO Role { get; set; }
    }
}
