using FinanceControl.Domain.Entities;


namespace FinanceControl.Domain.Interfaces
{
    public interface ICategoriesRepository
    {

        Task<Category> CreateCategoryAsync(Category category);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryById(int id);
        Task<Category?> UpdateCategoryAsync(int id, Category category);

       Task<Category?> DeleteCategoryAsync(int id);

    }
}
