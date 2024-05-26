using FarmCentral.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmCentral.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet <Address> Addresses { get; set; }
    }
}
