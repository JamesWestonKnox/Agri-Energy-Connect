// Summary
//----------------------------------------------------
// AccountController.cs
// Handles user login and logout functionality.
// Routes users based on role (Employee or Farmer).
// Depends on: AppDbContext, PasswordService, Session
// ---------------------------------------------------

namespace Agri_Energy_Connect.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
