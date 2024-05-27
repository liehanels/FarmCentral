using FarmCentral.Data;
using FarmCentral.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarmCentral.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            Product product = _context.Products.FirstOrDefault(c => c.Id == id);
            return View(product);
        }
    }
}
