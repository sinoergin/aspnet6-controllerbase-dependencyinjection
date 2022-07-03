namespace AspNet6.DependencyInjection.Database
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(key => key.Id);
            modelBuilder.Entity<Product>().HasKey(key => key.Id);

            modelBuilder.Entity<Product>()
                .HasOne(opt => opt.Category)
                .WithMany(opt => opt.Products)
                .HasForeignKey(fk => fk.CategoryId);

            modelBuilder.CreateSomeData();
        }

    }
}
