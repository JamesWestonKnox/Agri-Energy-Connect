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
                var defaultEmployee = new User
                {
                    Username = "Emp1",
                    PasswordHash = passwordService.HashPassword("password"),
                    Role = "Employee"
                };

                context.Users.Add(defaultEmployee);
                context.SaveChanges();
            }
        }
    }
}
