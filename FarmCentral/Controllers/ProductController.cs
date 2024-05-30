using FarmCentral.Data;
using FarmCentral.Interfaces;
using FarmCentral.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmCentral.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            return View(products);
        }
        public async Task<IActionResult> Details(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                product = await _productRepository.GetByIdAsync(1);
            }
            return View(product);
        }
        public async Task<IActionResult> EditProduct(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                product = await _productRepository.GetByIdAsync(1);
            }
            return View(product);
        }
    }
}
