using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using FinanceControl.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly BancoContext _context;

        public CategoriesRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> UpdateCategoryAsync(int id, Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(id);

            if (existingCategory == null) return null;

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.UserId = category.UserId;

            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<Category?> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) return null;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}