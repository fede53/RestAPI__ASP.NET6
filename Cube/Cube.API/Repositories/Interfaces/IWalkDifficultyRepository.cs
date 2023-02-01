using Cube.Api.Models.Domain;

namespace Cube.Api.Repositories.Interfaces
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();

        Task<WalkDifficulty> GetAsync(Guid id);

        Task<WalkDifficulty> AddAsync(WalkDifficulty region);

        Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty region);

        Task<WalkDifficulty> DeleteAsync(Guid id);

    }
}
