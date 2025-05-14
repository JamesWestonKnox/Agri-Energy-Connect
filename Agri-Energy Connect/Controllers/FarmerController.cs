// Summary
//----------------------------------------------------
// Far,er Controller handles functionality for farmer role
// View marketplace products and view and create own products
// Assistance provided by ChatGPT, OpenAI (2025). https://chat.openai.com
// ---------------------------------------------------

using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext _context; //Context for database access

        //Initializes controller with database context
        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FarmerDashboard()
        {
            //Returns FarmerDashboard view
            return View();
        }

        [HttpGet]
        public IActionResult Products()
        {
            //Retrieves userID from session context
            var userId = HttpContext.Session.GetInt32("UserId");

            //Retrieves farmer and products from datbasee
            var farmer = _context.Farmers
                .Include(f => f.Products)
                .FirstOrDefault(f => f.UserId == userId);

            if (farmer == null)
            {
                return NotFound("Farmer not found for this user.");
            }

            //Pass products to view
            return View(farmer.Products.ToList());
        }

        [HttpGet]
        public IActionResult Marketplace(ProductFilterModel filter)
        {
            //Retrieve all products from database
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
        public IActionResult AddProduct()
        {
            //Returns AddProduct view
            return View();
        }


        [HttpPost]
        public IActionResult AddProduct(AddProductModel model)
        {
            // Ensure form input is valid
            if (ModelState.IsValid)
            {
                // Retrieve current user from session
                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId == null)
                {
                    ModelState.AddModelError("", "Session expired. Please log in again.");
                    return RedirectToAction("Login", "Account");
                }

                //Retrieve farmer using session userID
                var farmer = _context.Farmers.FirstOrDefault(f => f.UserId == userId);
                if (farmer == null)
                {
                    ModelState.AddModelError("", "Farmer not found.");
                    return View(model);
                }

                //Create new product entry
                var product = new Product
                {
                    Name = model.Name,
                    Category = model.Category,
                    Description = model.Description,
                    ProductionDate = model.ProductionDate,
                    Price = model.Price,
                    FarmerId = farmer.FarmerId
                };

                //Save changes to database
                _context.Products.Add(product);
                _context.SaveChanges();

                // Redirect to products page
                return RedirectToAction("Products");
            }
            else
            {
                // Return the view with appropiate errors
                return View(model);
            }
        }

    }
}

// ============================== End Of FILE ============================== //