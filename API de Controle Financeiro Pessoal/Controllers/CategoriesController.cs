using FinanceControl.Application.Dtos;
using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;



namespace API_de_Controle_Financeiro_Pessoal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IUserRepository _userRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository, IUserRepository userRepository)
        {
            _categoriesRepository = categoriesRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryDto dto)
        {
            var userId = GetUserId();

            var category = new Category(dto.Name, dto.Description, userId);

            await _categoriesRepository.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoriesRepository.GetCategoryById(id);

            if(category == null)
            {
             return NotFound();
            }

            var userId = GetUserId();

            if(category.UserId != userId)
            {
            return Forbid();
            }

            return Ok(category);
        }   

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var userId = GetUserId();

            var categories = await _categoriesRepository.GetAllByUserIdAsync(userId);

            var response = categories.Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                UserId = c.UserId
            });
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            var userId = GetUserId();

            var updatedCategory = await _categoriesRepository.UpdateCategoryAsync(id, category);
            if(updatedCategory == null)
            {
                return NotFound();
            }
            return Ok(updatedCategory);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var userId = GetUserId();

            var deletedCategory = await _categoriesRepository.DeleteCategoryAsync(id);
            if(deletedCategory == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        private int GetUserId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(idClaim);
        }

    }
}
