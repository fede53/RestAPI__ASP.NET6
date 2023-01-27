using Cube.API.Data;
using Cube.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cube.API.Repositories
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
    }
}
