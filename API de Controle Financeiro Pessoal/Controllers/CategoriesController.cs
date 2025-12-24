using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using FinanceControl.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_de_Controle_Financeiro_Pessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await _categoriesRepository.CreateCategoryAsync(category);  
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoriesRepository.IdCategoryAsync(id);

            if(category == null)
            {
             return NotFound();
            }

            return Ok(category);
        }   

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoriesRepository.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            var updatedCategory = await _categoriesRepository.UpdateCategoryAsync(id, category);
            if(updatedCategory == null)
            {
                return NotFound();
            }
            return Ok(updatedCategory);
        }



    }
}
