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

        public CategoriesController(ICategoriesRepository categoriesRepository, IUserRepository userRepository)
        {
            _categoriesRepository = categoriesRepository;
          
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryDto dto)
        {
          var userId = GetUserId(); 

            var category = new Category(dto.Name, dto.Description, userId);

            await _categoriesRepository.CreateCategoryAsync(category);

            var response = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                UserId = category.UserId
            };  

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var userId = GetUserId();   
            var category = await _categoriesRepository.GetCategoryById(id);
            if(category == null || category.UserId != userId)
            {
                return NotFound();
            }
            var response = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                UserId = category.UserId
            };
            return Ok(response);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            var userId = GetUserId();   

            var existingCategory = await _categoriesRepository.GetCategoryById(id);

            if (existingCategory == null || existingCategory.UserId != userId)
            {
                return NotFound();
            }


            existingCategory.Name = category.Name;

            await _categoriesRepository.UpdateCategoryAsync(id, existingCategory);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var userId = GetUserId();

           var existingCategory = await _categoriesRepository.GetCategoryById(id);
          
            if(existingCategory == null)
            {
                return NotFound("Categoria não encontrada");
            }

            if(existingCategory.UserId != userId)
            {
                return Forbid("Você não tem permissão para deletar esta categoria.");
            }

            await _categoriesRepository.DeleteCategoryAsync(id);

            return NoContent();
        }

        private int GetUserId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(idClaim)) throw new Exception("Token inválido");
            return int.Parse(idClaim);
        }

    }
}
