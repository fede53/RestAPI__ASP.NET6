using Cube.Api.Models.Domain;

namespace Cube.Api.Models.DTO
{
    public class AddRegionDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

    }
}
