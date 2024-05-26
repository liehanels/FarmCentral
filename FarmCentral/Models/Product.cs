using System.ComponentModel.DataAnnotations;

namespace FarmCentral.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public DateOnly ManufactorDate { get; set; }
        public DateOnly BestBeforeDate { get; set; }
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
        public Farmer? Farmer { get; set; }
    }
}
