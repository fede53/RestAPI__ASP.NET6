using Cube.Api.Data;
using Cube.Api.Models.Domain;
using Cube.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cube.Api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly CubeContext cubeContext;
        public RegionRepository(CubeContext cubeContext) 
        {
            this.cubeContext = cubeContext;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await cubeContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await cubeContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await cubeContext.AddAsync(region);
            await cubeContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await cubeContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code= region.Code;   
            existingRegion.Name= region.Name;
            existingRegion.Area= region.Area;
            existingRegion.Lat= region.Lat;
            existingRegion.Long= region.Long;
            existingRegion.Population= region.Population;

            await cubeContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await cubeContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(region == null)
            {
                return null;
            }
            cubeContext.Regions.Remove(region);
            await cubeContext.SaveChangesAsync();
            return region;
        }
    }
}
