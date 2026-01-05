using FinanceControl.Domain.Entities;
using System;
using System.Collections.Generic;


namespace FinanceControl.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
    }
}
