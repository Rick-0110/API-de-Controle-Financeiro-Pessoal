using FinanceControl.Domain.Entities;

namespace FinanceControl.Domain.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<Transaction> CreateTransactionAsync(Transaction transaction);

        Task<IEnumerable<Transaction>> GetByUserIdAsync(int userId);

        Task<Transaction?> GetByIdAsync(int id);
    }
}
