namespace AspNet6.DependencyInjection.Controllers
{
    [Route("categories")]
    public class CategoriesController : MyControllerBase<Category, int>
    {
        public CategoriesController(IRepository<Category, int> repository) : base(repository)
        {
        }
    }
}
