using Cube.RestApi.Models.Entities;

namespace Cube.RestApi.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetAsync(int id);
        Task<Role> AddAsync(Role role);
        Task<Role> UpdateAsync(int id, Role role);
        Task<Role> DeleteAsync(int id);

    }
}
