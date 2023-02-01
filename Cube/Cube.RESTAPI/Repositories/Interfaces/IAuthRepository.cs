using Cube.RestApi.Models.Entities;

namespace Cube.RestApi.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> AuthenticateAsync(string email, string password);

    }
}
