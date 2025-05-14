// Summary
//----------------------------------------------------
// AccountController.cs
// Handles user login and logout functionality.
// Routes users based on role (Employee or Farmer).
// Depends on: AppDbContext, PasswordService, Session
// ---------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class AddFarmerModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
    }
}

// ============================== End Of FILE ============================== //