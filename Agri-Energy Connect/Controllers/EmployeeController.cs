// Summary
//----------------------------------------------------
// Employee Controller handles functionality for employee role
// Managing farmers and viewing and filtering products
// Assistance provided by ChatGPT, OpenAI (2025). https://chat.openai.com
// ---------------------------------------------------

using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Models;
using Agri_Energy_Connect.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context; //Context for database access
        private readonly PasswordService _passwordService; //Used to access password hash and verification functions

        //Initializes controller with context and password service
        public EmployeeController(AppDbContext context, PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        [HttpGet]
        public IActionResult EmployeeDashboard()
        {
            //Returns EmployeeDashboard view
            return View();
        }

        [HttpGet]
        public IActionResult Products(ProductFilterModel filter)
        {
            // Get products from database
            var products = _context.Products.AsQueryable();

            // Apply filter by category
            if (!string.IsNullOrEmpty(filter.SelectedCategory))
            {
                products = products.Where(p => p.Category == filter.SelectedCategory);
            }

            //Apply filter by start date
            if (filter.StartDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate >= filter.StartDate.Value);
            }

            //Apply filter by end date
            if (filter.EndDate.HasValue)
            {
                products = products.Where(p => p.ProductionDate <= filter.EndDate.Value);
            }

            // Include farmer data in the query results
            var filteredProducts = products.Include(p => p.Farmer).ToList();

            // Return view with filtered product list
            filter.Products = filteredProducts;
            return View(filter);
        }

        [HttpGet]
        public IActionResult Farmers()
        {
            // Display all farmers
            var farmers = _context.Farmers.ToList();
            return View(farmers);
        }

        [HttpGet]
        public IActionResult AddFarmer()
        {
            //Returns AddFarmer view
            return View();
        }

        [HttpGet]
        public IActionResult FarmerDetails(int id)
        {
            // Display a specific farmer and their products
            var farmer = _context.Farmers
                .Include(f => f.Products)
                .FirstOrDefault(f => f.FarmerId == id);

            if (farmer == null)
            {
                return NotFound();
            }

            // Return view with farmer information
            return View(farmer);
        }

        [HttpPost]
        public IActionResult AddFarmer(AddFarmerModel model)
        {
            // Check if form data is valid
            if (ModelState.IsValid)
            {
                // Check for existing user
                var existingUser = _context.Users.FirstOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError(nameof(model.Username), "Username already exists.");
                    return View(model);
                }

                // Creates new user with Farmer role
                var user = new User
                {
                    Username = model.Username,
                    PasswordHash = _passwordService.HashPassword(model.Password),
                    Role = "Farmer"
                };
                _context.Users.Add(user);
                _context.SaveChanges();

                // Creates a new farmer linked to userID
                var farmer = new Farmer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserId = user.UserId
                };

                // Saves changes
                _context.Farmers.Add(farmer);
                _context.SaveChanges();

                // Redirect to farmers page
                return RedirectToAction("Farmers");
            }

            //If  form fails return to view with appropiate error messages
            return View(model);
        }
    }
}

// ============================== End Of FILE ============================== //