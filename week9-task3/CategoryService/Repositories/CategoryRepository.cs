using CategoryService.Data;
using CategoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _db;
        public CategoryRepository(CategoryDbContext db) { _db = db; }

        public async Task<Category> Add(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task Delete(int id)
        {
            var entity = await _db.Categories.FindAsync(id);
            if (entity != null)
            {
                _db.Categories.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _db.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _db.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task Update(Category category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
        }
    }
}