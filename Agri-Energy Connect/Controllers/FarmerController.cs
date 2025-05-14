using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect.Controllers
{
    public class FarmerController : Controller
    {
        private readonly AppDbContext _context;

        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult FarmerDashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Products()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var farmer = _context.Farmers
                .Include(f => f.Products)
                .FirstOrDefault(f => f.UserId == userId);

            if (farmer == null)
            {
                return NotFound("Farmer not found for this user.");
            }

            return View(farmer.Products.ToList());
        }

        [HttpGet]
        public IActionResult Marketplace(ProductFilterModel filter)
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

            var filteredProducts = products.ToList();

            filter.Products = filteredProducts;
            return View(filter);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddProduct(AddProductModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId == null)
                {
                    ModelState.AddModelError("", "Session expired. Please log in again.");
                    return RedirectToAction("Login", "Account");
                }

                var farmer = _context.Farmers.FirstOrDefault(f => f.UserId == userId);
                if (farmer == null)
                {
                    ModelState.AddModelError("", "Farmer not found.");
                    return View(model);
                }

                var product = new Product
                {
                    Name = model.Name,
                    Category = model.Category,
                    Description = model.Description,
                    ProductionDate = model.ProductionDate,
                    Price = model.Price,
                    FarmerId = farmer.FarmerId
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                TempData["Success"] = "Product added successfully.";
                return RedirectToAction("Products");
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return View(model);
            }
        }

    }
}
