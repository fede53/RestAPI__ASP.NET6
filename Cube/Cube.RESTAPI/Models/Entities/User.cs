using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cube.RestApi.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
