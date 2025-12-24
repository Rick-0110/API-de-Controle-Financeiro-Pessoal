using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using FinanceControl.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastructure.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly BancoContext _context;

        public CategoriesRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return new OkObjectResult(category);
        }   

        public async Task<IActionResult> IdCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(category);
        }

        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return new OkObjectResult(categories);
        }

        public async Task<IActionResult> UpdateCategoryAsync(int id, Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                return new NotFoundResult();
            }
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.UserId = category.UserId;
            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
            return new OkObjectResult(existingCategory);
        }

    


    }
}
