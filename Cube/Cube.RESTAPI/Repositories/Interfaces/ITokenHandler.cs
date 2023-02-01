using Cube.RestApi.Models.Entities;

namespace Cube.RestApi.Repositories.Interfaces
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
