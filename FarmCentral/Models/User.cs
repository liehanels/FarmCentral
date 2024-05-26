using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace FarmCentral.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
