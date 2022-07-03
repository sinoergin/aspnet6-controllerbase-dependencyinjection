namespace AspNet6.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddMyDatabase(this IServiceCollection provider)
        {
            provider.AddDbContext<MyDatabaseContext>(opt => opt.UseInMemoryDatabase("MyDatabase"));
            provider.AddScoped<DbContext, MyDatabaseContext>();
        }

        public static void AddMyRepositories(this IServiceCollection provider)
        {
            provider.AddScoped<IRepository<Category, int>, Repository<Category, int>>();
            provider.AddScoped<IRepository<Product, int>, Repository<Product, int>>();
        }
    }
}
