using Cube.RestApi.Data;
using Cube.RestApi.Models.Entities;
using Cube.RestApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cube.RestApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CubeContext cubeContext;
        public UserRepository(CubeContext cubeContext) 
        {
            this.cubeContext = cubeContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
           return await cubeContext.Users.Include(x => x.Role).ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await cubeContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> AddAsync(User user)
        {
            await cubeContext.AddAsync(user);
            await cubeContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            var existingUser = await cubeContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = user.FirstName;   
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Role = user.Role;

            await cubeContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await cubeContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                return null;
            }
            cubeContext.Users.Remove(user);
            await cubeContext.SaveChangesAsync();
            return user;
        }
    }
}
