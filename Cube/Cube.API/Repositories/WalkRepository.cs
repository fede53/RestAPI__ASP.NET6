using Cube.Api.Data;
using Cube.Api.Models.Domain;
using Cube.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cube.Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly CubeContext cubeContext;
        public WalkRepository(CubeContext cubeContext) 
        {
            this.cubeContext = cubeContext;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await cubeContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id) => await cubeContext.Walks.Include(x => x.Region).Include(x => x.WalkDifficulty).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await cubeContext.AddAsync(walk);
            await cubeContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await cubeContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;   
            existingWalk.Length = walk.Length;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;

            await cubeContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await cubeContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(walk == null)
            {
                return null;
            }
            cubeContext.Walks.Remove(walk);
            await cubeContext.SaveChangesAsync();
            return walk;
        }
    }
}
