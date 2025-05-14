using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Models;
using Agri_Energy_Connect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PasswordService _passwordService;

        public EmployeeController(AppDbContext context, PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        [HttpGet]
        public IActionResult EmployeeDashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Products(ProductFilterModel filter)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filter.SelectedCategory))
            {
                products = products.Where(p => p.Category == filter.SelectedCategory);
            }

            if (filter.StartDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate >= filter.StartDate.Value);
            }

            if (filter.EndDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate <= filter.EndDate.Value);
            }

            var filteredProducts = products.Include(p => p.Farmer).ToList();

            filter.Products = filteredProducts;
            return View(filter);
        }

        [HttpGet]
        public IActionResult Farmers()
        {
            var farmers = _context.Farmers.ToList();
            return View(farmers);
        }

        [HttpGet]
        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FarmerDetails(int id)
        {
            var farmer = _context.Farmers
                .Include(f => f.Products)
                .FirstOrDefault(f => f.FarmerId == id);

            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        [HttpPost]
        public IActionResult AddFarmer(AddFarmerModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Username already exists.");
                    return View(model);
                }

                var user = new User
                {
                    Username = model.Username,
                    PasswordHash = _passwordService.HashPassword(model.Password),
                    Role = "Farmer"
                };
                _context.Users.Add(user);
                _context.SaveChanges();

                var farmer = new Farmer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserId = user.UserId
                };

                _context.Farmers.Add(farmer);
                _context.SaveChanges();

                TempData["Success"] = "Farmer account created successfully.";
                return RedirectToAction("Farmers");
            }

            return View(model);
        }
    }
}
