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
            List<Farmer> FarmerUsers = _context.Farmers.Include(u => u.FarmerUser).ToList();
            return View(FarmerUsers);
        }
    }
}
