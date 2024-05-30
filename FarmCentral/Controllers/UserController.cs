using FarmCentral.Data;
using FarmCentral.Interfaces;
using FarmCentral.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmCentral.Controllers
{
    public class UserController : Controller
    {
        private readonly IFarmerRepository _farmerRepository;

        public UserController(IFarmerRepository userRepository)
        {
            _farmerRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var FarmerUsers = await _farmerRepository.GetAll();
            return View(FarmerUsers);
        }
        public async Task<IActionResult> Details(int id)
        {
            Farmer farmer = await _farmerRepository.GetByIdAsync(id);
            if(farmer == null)
            {
                farmer = await _farmerRepository.GetByIdAsync(1);
            }
            return View(farmer);
        }
    }
}
