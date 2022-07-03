namespace AspNet6.DependencyInjection.Controllers
{
    [Route("products")]
    public class ProductsController : MyControllerBase<Product, int>
    {
        public ProductsController(IRepository<Product, int> repository) : base(repository)
        {
        }
    }
}
