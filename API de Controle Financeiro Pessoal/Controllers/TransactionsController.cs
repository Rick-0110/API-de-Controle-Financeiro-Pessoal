using FinanceControl.Application.Dtos;
using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Enums;
using FinanceControl.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_de_Controle_Financeiro_Pessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly ICategoriesRepository _categoriesRepository;


        public TransactionsController(ITransactionsRepository transactionsRepository, ICategoriesRepository categoriesRepository, IUserRepository usersRepository)
        {
            _transactionsRepository = transactionsRepository;
            _categoriesRepository = categoriesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto dto)
        {

            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized("Token inválido ou sem ID.");
            }
            int userId = int.Parse(userIdString);

            var category = await _categoriesRepository.GetCategoryById(dto.CategoryId);

            if (category == null)
            {
                return BadRequest("Categoria não encontrada.");
            }

            var transaction = new Transaction(
                 dto.Description,
                 dto.Amount,
                 dto.Date,
                 dto.Type,
                 userId,
                 dto.CategoryId
             );

            await _transactionsRepository.CreateTransactionAsync(transaction);

            var response = new TransactionResponseDto
            {
                Id = transaction.Id,
                Description = transaction.Description,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Type = (TransactionType)transaction.Type,
                TypeName = transaction.Type.ToString(),
                UserId = transaction.UserId,
                CategoryId = transaction.CategoryId,
                CategoryName = category.Name
            };

            return CreatedAtAction(nameof(GetMyTransactions), new { id = transaction.Id }, response);

        }


        [HttpGet]
        public async Task<IActionResult> GetMyTransactions()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString)) return Unauthorized();
            int userId = int.Parse(userIdString);

            var transactions = await _transactionsRepository.GetByUserIdAsync(userId);

            var response = transactions.Select(t => new TransactionResponseDto
            {
                Id = t.Id,
                Description = t.Description,
                Amount = t.Amount,
                Date = t.Date,
                Type = t.Type,
                TypeName = t.Type.ToString(), 
                CategoryId = t.CategoryId,
                CategoryName = t.Category?.Name ?? "Sem Categoria"
            });

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateTransactionDto dto)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = int.Parse(userIdString!);

            var transaction = await _transactionsRepository.GetByIdAsync(id);

            if(transaction == null)
            {
                return NotFound("Transação não encontrada");
            }

            if(transaction.UserId != userId)
            {
                return Forbid("Você não tem permissão para atualizar esta transação.");
            }

            transaction.Update(dto.Description, dto.Amount, dto.Date, dto.CategoryId, dto.Type);

            await _transactionsRepository.UpdateAsync(transaction);
            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = int.Parse(userIdString!);
            var transaction = await _transactionsRepository.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound("Transação não encontrada");
            }
            if (transaction.UserId != userId)
            {
                return Forbid("Você não tem permissão para deletar esta transação.");
            }
            await _transactionsRepository.DeleteAsync(transaction);
            return NoContent();
        }   


        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString)) return Unauthorized();
            int userId = int.Parse(userIdString);

            var transactions = await _transactionsRepository.GetByUserIdAsync(userId);

            var totalIncome = transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);


            var totalExpense = transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);


            var dashboard = new DashboardDto
            {
                TotalIncome = totalIncome,
                TotalExpenses = totalExpense
            };

            return Ok(dashboard);
        }
    }
}
