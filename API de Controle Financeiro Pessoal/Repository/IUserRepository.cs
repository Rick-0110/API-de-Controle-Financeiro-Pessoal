using FinanceControl.Domain.Entities;

namespace FinanceControl.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<List<User>> GetAllAsync();
    }
}
