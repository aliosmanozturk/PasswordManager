

using Microsoft.EntityFrameworkCore;
using PasswordManager.Models;

namespace PasswordManager.Database.EntityFramework
{
    public class PAsswordDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User ID=sa;Password=Ada232;Database=PasswordGenerator;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Application Name=PasswordGenerator;");
        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Passwords> Passwords { get; set; }
    }
}
