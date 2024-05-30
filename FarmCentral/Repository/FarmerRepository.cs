using FarmCentral.Data;
using FarmCentral.Interfaces;
using FarmCentral.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmCentral.Repository
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly ApplicationDbContext _context;

        public FarmerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Farmer farmer)
        {
            _context.Farmers.Add(farmer);
            return Save();
        }

        public bool Delete(Farmer farmer)
        {
            _context.Farmers.Remove(farmer);
            return Save();
        }

        public async Task<IEnumerable<Farmer>> GetAll()
        {
            return await _context.Farmers.Include(a => a.FarmerUser).ToListAsync();
        }

        public async Task<Farmer> GetByIdAsync(int id)
        {
            return await _context.Farmers.Include(i => i.Address).Include(f => f.FarmerUser).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Farmer>> GetFarmerByCity(string city)
        {
            return await _context.Farmers.Where(c => c.Address.City == city).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Farmer farmer)
        {
            _context.Update(farmer);
            return Save();
        }
    }
}
