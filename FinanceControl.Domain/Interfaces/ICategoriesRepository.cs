using FinanceControl.Domain.Entities;

namespace FinanceControl.Domain.Interfaces
{
    public interface ICategoriesRepository
    {

        Task<Category> CreateCategoryAsync(Category category);
        Task<IEnumerable<Category>> GetAllByUserIdAsync(int userId);
        Task<Category?> GetCategoryById(int id);
        Task<Category?> UpdateCategoryAsync(int id, Category category);

       Task<Category?> DeleteCategoryAsync(int id);
    }
}
