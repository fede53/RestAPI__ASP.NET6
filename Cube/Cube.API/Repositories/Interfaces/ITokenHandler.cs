using Cube.Api.Models.Domain;

namespace Cube.Api.Repositories.Interfaces
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
