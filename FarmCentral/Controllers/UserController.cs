using FarmCentral.Data;
using FarmCentral.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmCentral.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var FarmerUsers = _context.Farmers.Include(u => u.FarmerUser).ToList();
            return View(FarmerUsers);
        }
        public IActionResult Details(int id)
        {
            Farmer farmer = _context.Farmers.Include(u => u.Address).Include(u => u.FarmerUser).FirstOrDefault(c => c.Id == id);
            if(farmer == null)
            {
                farmer = _context.Farmers.Include(u => u.Address).Include(u => u.FarmerUser).FirstOrDefault(c => c.Id == 1);
            }
            return View(farmer);
        }
    }
}
