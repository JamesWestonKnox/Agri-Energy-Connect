// Summary
//----------------------------------------------------
// AccountController.cs
// Handles user login and logout functionality.
// Routes users based on role (Employee or Farmer).
// Depends on: AppDbContext, PasswordService, Session
// ---------------------------------------------------

namespace Agri_Energy_Connect.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}

// ============================== End Of FILE ============================== //