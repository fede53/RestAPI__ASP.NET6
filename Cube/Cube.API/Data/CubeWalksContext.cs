using Cube.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cube.API.Data
{
    public class CubeWalksContext: DbContext
    {
        public CubeWalksContext(DbContextOptions<CubeWalksContext> options): base(options) 
        { 

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
