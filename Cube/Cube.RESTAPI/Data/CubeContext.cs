using Cube.RestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cube.RestApi.Data
{
    public class CubeContext: DbContext
    {
        public CubeContext(DbContextOptions<CubeContext> options): base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.Role)
                .WithMany(b => b.Users);
        }
    }
}
