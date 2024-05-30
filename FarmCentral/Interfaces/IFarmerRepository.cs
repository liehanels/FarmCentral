using FarmCentral.Models;

namespace FarmCentral.Interfaces
{
    public interface IFarmerRepository
    {
        Task<IEnumerable<Farmer>> GetAll();
        Task<Farmer> GetByIdAsync(int id);
        Task<IEnumerable<Farmer>> GetFarmerByCity(string city);
        bool Add(Farmer farmer);
        bool Update(Farmer farmer);
        bool Delete(Farmer farmer);
        bool Save();
    }
}
