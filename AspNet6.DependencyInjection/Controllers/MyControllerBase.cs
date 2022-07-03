using Microsoft.AspNetCore.Mvc;

namespace AspNet6.DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyControllerBase<TEntity, TKey> : ControllerBase where TEntity : class
    {
        public IRepository<TEntity, TKey> Repository;

        public MyControllerBase(IRepository<TEntity, TKey> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        [HttpGet]
        [Route("get")]
        public async Task<TEntity> GetAsync(TKey id)
        {
            return await Repository.GetAsync(id);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await Repository.InsertAsync(entity);
        }

        [HttpPost]
        [Route("update")]
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await Repository.UpdateAsync(entity);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<bool> RemoveAsync(TKey id)
        {
            return await Repository.DeleteAsync(id);
        }
    }
}
