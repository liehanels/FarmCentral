using System.ComponentModel.DataAnnotations;

namespace FarmCentral.Models
{
    public class Farmer
    {
        [Key]
        public int Id { get; set; }
        public required User? FarmerUser { get; set; }
        public required Address? Address { get; set; }
    }
}
