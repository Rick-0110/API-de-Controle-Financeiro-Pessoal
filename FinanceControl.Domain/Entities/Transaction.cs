namespace FinanceControl.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public TransactionType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
