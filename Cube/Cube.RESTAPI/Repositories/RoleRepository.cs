using Cube.RestApi.Data;
using Cube.RestApi.Models.Entities;
using Cube.RestApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cube.RestApi.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CubeContext cubeContext;
        public RoleRepository(CubeContext cubeContext) 
        {
            this.cubeContext = cubeContext;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await cubeContext.Roles.ToListAsync();
        }

        public async Task<Role> GetAsync(int id)
        {
            return await cubeContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role> AddAsync(Role role)
        {
            await cubeContext.AddAsync(role);
            await cubeContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateAsync(int id, Role role)
        {
            var existingRole = await cubeContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRole == null)
            {
                return null;
            }
            existingRole.Name = role.Name;   
            await cubeContext.SaveChangesAsync();
            return existingRole;
        }

        public async Task<Role> DeleteAsync(int id)
        {
            var role = await cubeContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if(role == null)
            {
                return null;
            }
            cubeContext.Roles.Remove(role);
            await cubeContext.SaveChangesAsync();
            return role;
        }
    }
}
