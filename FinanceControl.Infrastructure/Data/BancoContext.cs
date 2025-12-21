using Microsoft.EntityFrameworkCore;
using FinanceControl.Domain.Entities;
using System.Transactions;

using Transaction = FinanceControl.Domain.Entities.Transaction;

namespace FinanceControl.Infrastructure.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
