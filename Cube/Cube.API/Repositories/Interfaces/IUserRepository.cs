using Cube.Api.Models.Domain;

namespace Cube.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);

    }
}
