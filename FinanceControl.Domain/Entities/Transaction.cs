using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; 

namespace FinanceControl.Domain.Entities
{
    public class Transaction
    {
     

        public int Id { get; private set; }

        
        public string Title { get; private set; }

        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public int Type { get; private set; }

        public int UserId { get;  set; }

        [JsonIgnore]
        public User? User { get; set; } = null!;

        public int CategoryId { get; private set; }

        [JsonIgnore]
        public Category? Category { get; set; } = null!;

        public Transaction(string title, decimal amount, int type, int userId, int categoryId)
        {
            if(string.IsNullOrWhiteSpace(title)) throw new ArgumentException("O título é obrigatório!", nameof(title));

            Title = title;
            Amount = amount;
            Type = type;
            UserId = userId;
            CategoryId = categoryId;
            Date = DateTime.Now;


        }

        protected Transaction() { }



    }
}