using FinanceControl.Domain.Enums;

namespace FinanceControl.Application.Dtos
{
    public class TransactionResponseDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string TypeName { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


    }
}
