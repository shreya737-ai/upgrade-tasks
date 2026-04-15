using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryServiceImpl(ICategoryRepository repo) { _repo = repo; }

        public Task<Category> Add(Category category) => _repo.Add(category);
        public Task Delete(int id) => _repo.Delete(id);
        public Task<IEnumerable<Category>> GetAll() => _repo.GetAll();
        public Task<Category?> GetById(int id) => _repo.GetById(id);
        public Task Update(Category category) => _repo.Update(category);
    }
}