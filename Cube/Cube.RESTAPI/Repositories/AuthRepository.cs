using Cube.RestApi.Data;
using Cube.RestApi.Models.Entities;
using Cube.RestApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cube.RestApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CubeContext cubeContext;
        public AuthRepository(CubeContext cubeContext)
        {
            this.cubeContext = cubeContext;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await cubeContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() && x.Password == password);

            if (user == null)
            {
                return null;
            }

            /*
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
            }*/

            user.Password = null;
            return user;
        }
    }
}
