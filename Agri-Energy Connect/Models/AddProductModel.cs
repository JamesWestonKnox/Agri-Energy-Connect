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
    public class AddProductModel
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "A description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter a production date.")]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public double Price { get; set; }
    }
}

// ============================== End Of FILE ============================== //