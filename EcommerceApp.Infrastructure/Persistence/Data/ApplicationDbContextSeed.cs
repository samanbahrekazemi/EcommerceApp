using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.ValueObjects;

namespace EcommerceApp.Infrastructure.Persistence.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {

                // Categories
                var categories = new List<Category>
                {
                    new Category { Id = new CategoryId(1), Name = "Electronics" },
                    new Category { Id = new CategoryId(2), Name = "Clothing" },
                    new Category { Id = new CategoryId(3), Name = "Books" },
                };
                context.Categories.AddRange(categories);


                // Tags
                var tags = new List<Tag>
                {
                    new Tag { Id = new TagId(1), Name = "Smartphones" },
                    new Tag { Id = new TagId(2), Name = "Laptops" },
                    new Tag { Id = new TagId(3), Name = "T-Shirts" },
                    new Tag { Id = new TagId(4), Name = "Jeans" },
                    new Tag { Id = new TagId(5), Name = "Fiction" },
                    new Tag { Id = new TagId(6), Name = "Non-Fiction" },
                };
                context.Tags.AddRange(tags);




                // Products
                var products = new List<Product>
                {
                    new Product
                    {
                        Id = new ProductId(1),
                        Name = "iPhone 13",
                        Description = "The latest iPhone from Apple",
                        Price = 999.99m,
                        CreatedAt = DateTime.Now.AddMinutes(-40),
                        CategoryId = new CategoryId(1)
                    },
                    new Product
                    {
                        Id = new ProductId(2),
                        Name = "Samsung Galaxy S21",
                        Description = "The latest Android smartphone from Samsung",
                        Price = 899.99m,
                        CreatedAt = DateTime.Now.AddMinutes(-30),
                        CategoryId = new CategoryId(1)
                    },
                    new Product
                    {
                        Id = new ProductId(3),
                        Name = "MacBook Pro",
                        Description = "The latest laptop from Apple",
                        Price = 1999.99m,
                        CreatedAt = DateTime.Now.AddMinutes(-20),
                        CategoryId = new CategoryId(1)
                    },
                    new Product
                    {
                        Id = new ProductId(4),
                        Name = "Dell XPS 13",
                        Description = "A popular laptop from Dell",
                        Price = 1299.99m,
                        CreatedAt = DateTime.Now.AddMinutes(-15),
                        CategoryId = new CategoryId(1)
                    },
                    new Product
                    {
                        Id = new ProductId(5),
                        Name = "Plain T-Shirt",
                        Description = "A simple and comfortable t-shirt",
                        Price = 19.99m,
                        CreatedAt = DateTime.Now.AddMinutes(-10),
                        CategoryId = new CategoryId(2)
                    },
                    new Product
                    {
                        Id = new ProductId(6),
                        Name = "Slim Fit Jeans",
                        Description = "A stylish and comfortable pair of jeans",
                        Price = 49.99m,
                        CreatedAt = DateTime.Now.AddMinutes(-5),
                        CategoryId = new CategoryId(2)
                    },
                    new Product
                    {
                        Id = new ProductId(7),
                        Name = "The Great Gatsby",
                        Description = "A classic novel by F. Scott Fitzgerald",
                        Price = 9.99m,
                        CreatedAt = DateTime.Now.AddMinutes(-2),
                        CategoryId = new CategoryId(3)
                    },
                    new Product
                    {
                        Id = new ProductId(8),
                        Name = "The Lean Startup",
                        Description = "A popular business book by Eric Ries",
                        Price = 14.99m,
                        CreatedAt = DateTime.Now,
                        CategoryId = new CategoryId(3)
                    },
                };
                context.Products.AddRange(products);

                await context.SaveChangesAsync();
            }
        }

    }

}
