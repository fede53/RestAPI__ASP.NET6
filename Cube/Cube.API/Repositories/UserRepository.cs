using Cube.Api.Data;
using Cube.Api.Models.Domain;
using Cube.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cube.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CubeContext cubeContext;
        public UserRepository(CubeContext cubeContext)
        {
            this.cubeContext = cubeContext;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await cubeContext.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() && x.Password == password);

            if (user == null)
            {
                return null;
            }

            var userRoles = await cubeContext.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await cubeContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }

            user.Password = null;
            return user;
        }
    }
}
