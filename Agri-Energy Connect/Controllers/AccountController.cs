using Microsoft.AspNetCore.Mvc;
using Agri_Energy_Connect.Models;
using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Services;

namespace Agri_Energy_Connect.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PasswordService _passwordService;

        public AccountController(AppDbContext context, PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username);

                if (user != null)
                {
                    bool isPasswordValid = _passwordService.VerifyPassword(user.PasswordHash, model.Password);

                    if (isPasswordValid) 
                    {
                        HttpContext.Session.SetInt32("UserId", user.UserId);
                        HttpContext.Session.SetString("Username", user.Username);
                        HttpContext.Session.SetString("Role", user.Role);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
