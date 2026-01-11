using FinanceControl.Infrastructure.Data;
using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastructure.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly BancoContext _context;
        public TransactionsRepository(BancoContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }


        public async Task<IEnumerable<Transaction>> GetByUserIdAsync(int userId)
        {
            return await _context.Transactions
                .AsNoTracking() 
                .Where(t => t.UserId == userId) 
                .Include(t => t.Category)       
                .OrderByDescending(t => t.Date) 
                .ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

     
    }
}
