using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _20220305027
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext()
        {
            this.Database.EnsureCreated();

            if (!this.Users.Any())
            {
                this.Users.Add(new User { Username = "admin", Password = "123" });
                this.SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=inventory.db");
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}