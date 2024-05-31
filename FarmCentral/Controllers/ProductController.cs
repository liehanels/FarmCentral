using FarmCentral.Data;
using FarmCentral.Interfaces;
using FarmCentral.Models;
using FarmCentral.ViewModels;
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
        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                await _productRepository.GetByIdAsync(1);
                return NotFound();
            }
            var ProductVM = new EditProductViewModel
            {
                ProductName = product.ProductName,
                Quantity = product.Quantity,
                PricePerUnit = (int)product.PricePerUnit
            };
            _productRepository.Update(product);
            return View(ProductVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditProductViewModel model)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit product");
                return View("Edit", model);
            }
            var userProduct = await _productRepository.GetByIdAsyncNoTracking(id);
            var product = new Product
            {
                ProductName = userProduct.ProductName,
                Quantity = userProduct.Quantity,
                PricePerUnit = userProduct.PricePerUnit,
            };
            _productRepository.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productRepository.Add(product);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetProductByFarmer(int farmerId)
        {
            Product product = await _productRepository.GetByIdAsync(farmerId);
            if (product == null)
            {
                product = await _productRepository.GetByIdAsync(1);
            }
            return View(product);
        }
    }
}
