using System.ComponentModel.DataAnnotations;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Application.Dtos
{
    public class CreateTransactionDto
    {
        [Required(ErrorMessage = "A descrição é obrigatória!")]
        public string Description { get; set; }

        [Range(0.01, 999999999, ErrorMessage = "O valor deve ser maior que zero")]
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}
