using CategoryService.Models;

namespace CategoryService.Services
{
    public interface ICategoryService
    {
        Task<Category> Add(Category category);
        Task<IEnumerable<Category>> GetAll();
        Task<Category?> GetById(int id);
        Task Update(Category category);
        Task Delete(int id);
    }
}