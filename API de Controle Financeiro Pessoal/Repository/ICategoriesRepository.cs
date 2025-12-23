using FinanceControl.Domain.Entities;
using FinanceControl.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.Domain.Interfaces
{
    public interface ICategoriesRepository
    {

        Task<IActionResult> CreateCategoryAsync(Category category);
        Task<IActionResult> GetAllCategoriesAsync();
        Task<IActionResult> IdCategoryAsync(int id);
        
    }
}
