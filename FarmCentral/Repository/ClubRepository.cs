using FarmCentral.Data;
using FarmCentral.Interfaces;
using FarmCentral.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmCentral.Repository
{
    public class ClubRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public bool Add(Product product)
        {
            _context.Products.Add(product);
            return Save();
        }

        public bool Delete(Product product)
        {
            _context.Products.Remove(product);
            return Save();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Product>> GetProductByCity(string city)
        {
            return await _context.Products.Where(c => c.Farmer.Address.City == city).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
