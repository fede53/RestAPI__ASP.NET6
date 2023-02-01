using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Cube.RestApi.Models.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public List<User> Users { get; set; }

    }
}
