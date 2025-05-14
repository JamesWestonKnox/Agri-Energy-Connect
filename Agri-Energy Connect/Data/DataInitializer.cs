// Summary
//----------------------------------------------------
//DataInitializer is used to seed default data into the database
// ---------------------------------------------------

using Agri_Energy_Connect.Models;
using Agri_Energy_Connect.Services;

namespace Agri_Energy_Connect.Data
{
    public static class DataInitializer
    {
        public static void Initialize(AppDbContext context, PasswordService passwordService)
        {
            if (!context.Users.Any())
            {
                //Creates default employee user
                var defaultEmployee = new User
                {
                    Username = "Emp1",
                    PasswordHash = passwordService.HashPassword("password"),
                    Role = "Employee"
                };

                //Saves to database
                context.Users.Add(defaultEmployee);
                context.SaveChanges();
            }
        }
    }
}

// ============================== End Of FILE ============================== //