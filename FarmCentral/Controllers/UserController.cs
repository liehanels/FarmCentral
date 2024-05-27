using FarmCentral.Data;
using FarmCentral.Models;
using Microsoft.AspNetCore.Mvc;

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
            List<User> users = _context.Users.ToList();
            return View(users);
        }
    }
}
