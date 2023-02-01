using Cube.Api.Models.Domain;

namespace Cube.Api.Models.DTO
{
    public class AddWalkDTO
    {
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}
