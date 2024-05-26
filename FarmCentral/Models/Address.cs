using System.ComponentModel.DataAnnotations;

namespace FarmCentral.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public required string Province { get; set; }
    }
}
