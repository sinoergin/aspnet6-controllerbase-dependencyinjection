namespace AspNet6.DependencyInjection.Extensions
{
    public static class DbContextModelBuilderExtension
    {
        public static void CreateSomeData(this ModelBuilder builder)
        {
            List<Category> categories = new()
            {
                new Category { Id = 1, Name = "Category1" },
                new Category { Id = 2, Name = "Category2" }
            };

            builder.Entity<Category>().HasData(categories);

            List<Product> products = new()
            {
                new Product { Id = 1, Name = "Product1", Price = 10m, Quantity = 5, CategoryId = 1 },
                new Product { Id = 2, Name = "Product2", Price = 15m, Quantity = 6, CategoryId = 1 },
                new Product { Id = 3, Name = "Product3", Price = 20m, Quantity = 7, CategoryId = 2 },
                new Product { Id = 4, Name = "Product4", Price = 25m, Quantity = 8, CategoryId = 2 }
            };

            builder.Entity<Product>().HasData(products);
        }
    }
}
