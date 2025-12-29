using System.ComponentModel.DataAnnotations;

namespace FinanceControl.Application.Dtos
{
    public class CreateTransactionDto
    {
        [Required(ErrorMessage = "O título é obrigatório!")]
        public string Title { get; set; }

        [Range(0.01, double.MaxValue)]
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }
}
