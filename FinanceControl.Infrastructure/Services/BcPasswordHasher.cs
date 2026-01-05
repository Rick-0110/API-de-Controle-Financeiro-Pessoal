using FinanceControl.Domain.Interfaces;
using BC = BCrypt.Net.BCrypt;
namespace FinanceControl.Infrastructure.Services
{
    public class BcPasswordHasher : IPasswordHasher
    {
       public string Hash(string password)
        {
            return BC.HashPassword(password);
        }
        public bool Verify(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
