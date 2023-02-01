using Cube.Api.Data;
using Cube.Api.Models.Domain;
using Cube.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cube.Api.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly CubeContext cubeContext;
        public WalkDifficultyRepository(CubeContext cubeContext) 
        {
            this.cubeContext = cubeContext;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await cubeContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await cubeContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await cubeContext.AddAsync(walkDifficulty);
            await cubeContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await cubeContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code= walkDifficulty.Code;   

            await cubeContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDifficulty = await cubeContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
            if(walkDifficulty == null)
            {
                return null;
            }
            cubeContext.WalkDifficulty.Remove(walkDifficulty);
            await cubeContext.SaveChangesAsync();
            return walkDifficulty;
        }
    }
}
