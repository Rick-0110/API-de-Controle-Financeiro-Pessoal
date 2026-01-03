using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; 

namespace FinanceControl.Domain.Entities
{
    public class Transaction
    {
     

        public int Id { get; private set; }

        
        public string Description { get; private set; }

        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public int Type { get; private set; }

        public int UserId { get;  set; }

        [JsonIgnore]
        public User? User { get; set; } = null!;

        public int CategoryId { get; private set; }

        [JsonIgnore]
        public Category? Category { get; set; } = null!;

        public Transaction(string description,decimal amount, DateTime date, TransactionType type, int userId, int categoryId)
        {
            if(string.IsNullOrWhiteSpace(description)) throw new ArgumentException("A descrição é obrigatória!", nameof(description));
            if(amount <= 0 ) throw new ArgumentException("O valor da transação deve ser maior que zero!", nameof(amount));
            if(UserId <= 0) throw new ArgumentException("Usuário inválido!", nameof(userId));
            if(categoryId <= 0) throw new ArgumentException("Categoria inválida!", nameof(categoryId));

            Description = description;
            Amount = amount;
            Date = date;
            Type = (int)type;
            UserId = userId;
            CategoryId = categoryId;

        }

        protected Transaction() { }



    }
}