using FarmCentral.Data;
using FarmCentral.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var products = _context.Products.Include(f => f.Farmer).ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            Product product = _context.Products.Include(u => u.Farmer).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                product = _context.Products.Include(u => u.Farmer).FirstOrDefault(c => c.Id == 1);
            }
            return View(product);
        }
        public IActionResult EditProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(c => c.Id == id);
            if(product == null)
            {
                product = _context.Products.FirstOrDefault(c => c.Id == 1);
            }
            return View(product);
        }
    }
}
