// Summary
//----------------------------------------------------
// AccountController.cs
// Handles user login and logout functionality.
// Routes users based on role (Employee or Farmer).
// Depends on: AppDbContext, PasswordService, Session
// ---------------------------------------------------

namespace Agri_Energy_Connect.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public double Price { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}

// ============================== End Of FILE ============================== //