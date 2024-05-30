using FarmCentral.Models;

namespace FarmCentral.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductByCity(string city);
        Task<IEnumerable<Product>> GetProductByFarmer(int farmer);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Product product);
        bool Save();
    }
}
