// Summary
//---------------------------------------------------
// Account controller is used to handle the functionality for a user to login and logout of the application
// Assistance provided by ChatGPT, OpenAI (2025). https://chat.openai.com
// ---------------------------------------------------

using Agri_Energy_Connect.Data;
using Agri_Energy_Connect.Models;
using Agri_Energy_Connect.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agri_Energy_Connect.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context; //Context for database access
        private readonly PasswordService _passwordService; //Used to access password hash and verification functions

        //Initializes controller with context and password service
        public AccountController(AppDbContext context, PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            //Returns login view
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            // Check form input is valid
            if (ModelState.IsValid)
            {
                //Look for existing user in database
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username);

                if (user != null)
                {
                    //Use password service to verify entered password against hash value
                    bool isPasswordValid = _passwordService.VerifyPassword(user.PasswordHash, model.Password);

                    if (isPasswordValid)
                    {
                        //Store session data when logged in
                        HttpContext.Session.SetInt32("UserId", user.UserId);
                        HttpContext.Session.SetString("Username", user.Username);
                        HttpContext.Session.SetString("Role", user.Role);

                        //Redirects to dashboard according to role
                        if (user.Role == "Employee")
                        {
                            return RedirectToAction("EmployeeDashboard", "Employee");
                        }
                        else if (user.Role == "Farmer")
                        {
                            return RedirectToAction("FarmerDashboard", "Farmer");
                        }
                    }
                    else
                    {
                        //Error message for incorrect password
                        ModelState.AddModelError(string.Empty, "Incorrect password. Please try again.");
                    }
                }
                else
                {
                    //Error message for username not found
                    ModelState.AddModelError(string.Empty, "Username not found. Please check and try again.");
                }
            }
            //If login form fails return to login view with appropiate error messages
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            //Clears the current session and returns to login page
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

// ============================== End Of FILE ============================== //