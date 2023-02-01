using Cube.RestApi.Models.Entities;

namespace Cube.RestApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(int id, User user);
        Task<User> DeleteAsync(int id);

    }
}
