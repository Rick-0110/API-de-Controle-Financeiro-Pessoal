using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_de_Controle_Financeiro_Pessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository _transactionsRepository;

        public TransactionsController(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            var createdTransaction = await _transactionsRepository.CreateTransactionAsync(transaction);
            return CreatedAtAction(nameof(CreateTransaction), new { id = createdTransaction.Id }, createdTransaction);
        }


    }
}
