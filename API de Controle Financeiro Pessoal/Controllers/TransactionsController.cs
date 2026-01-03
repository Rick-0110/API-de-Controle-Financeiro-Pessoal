using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using FinanceControl.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API_de_Controle_Financeiro_Pessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IUserRepository _usersRepository; 

        public TransactionsController(ITransactionsRepository transactionsRepository, ICategoriesRepository categoriesRepository, IUserRepository usersRepository)
        {
            _transactionsRepository = transactionsRepository;
            _categoriesRepository = categoriesRepository;
            _usersRepository = usersRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto dto)
        {


            var user = await _usersRepository.GetByIdAsync(dto.UserId);
            if (user == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            var category = await _categoriesRepository.GetCategoryById(dto.CategoryId);
            if (category == null)
            {
                return BadRequest("Usuário não encontrado");
            }

            var transaction = new Transaction(
                dto.Description,
                dto.Amount,
                dto.Date,
                (TransactionType)dto.Type,
                dto.UserId,
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

            return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, response);

        }

        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _transactionsRepository.GetAllAsync();
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();

        }
    }
}
