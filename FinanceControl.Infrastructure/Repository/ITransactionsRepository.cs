using FinanceControl.Domain.Entities;

namespace FinanceControl.Domain.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);
        
    }
}
