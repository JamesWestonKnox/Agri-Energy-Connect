// Summary
//----------------------------------------------------
// AppDbContext serves as the database context for the application
// Provides access to database tables
// ---------------------------------------------------

using Agri_Energy_Connect.Models;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect.Data
{
    public class AppDbContext : DbContext
    {
        //User table in database
        public DbSet<User> Users { get; set; }

        //Farmers table in database
        public DbSet<Farmer> Farmers { get; set; }

        //Products table in database
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
    }
}

// ============================== End Of FILE ============================== //