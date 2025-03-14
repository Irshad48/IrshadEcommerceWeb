using IrshadEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace IrshadEcommerce.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
                
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder=1},
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Title 1",
                    Author = "Author 1",
                    Description = "Description 1",
                    ISBN = "ISBN 1",
                    ListPrice = 99,
                    Price50 = 90,
                    Price100 = 80
                },
                new Product
                {
                    Id = 2,
                    Title = "Title 2",
                    Author = "Author 2",
                    Description = "Description 2",
                    ISBN = "ISBN 2",
                    ListPrice = 990,
                    Price50 = 900,
                    Price100 = 800
                },
                new Product
                {
                    Id = 3,
                    Title = "Title 3",
                    Author = "Author 3",
                    Description = "Description 3",
                    ISBN = "ISBN 3",
                    ListPrice = 9900,
                    Price50 = 9000,
                    Price100 = 8000
                }
                );
        }
    }
}
