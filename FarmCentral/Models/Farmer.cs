using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmCentral.Models
{
    public class Farmer
    {
        [Key]
        public int Id { get; set; }
        public required User? FarmerUser { get; set; }
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public required Address? Address { get; set; }
    }
}
