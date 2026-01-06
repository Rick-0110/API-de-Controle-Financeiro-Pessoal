using System.ComponentModel.DataAnnotations;

namespace FinanceControl.Application.Dtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres")]
        public string Description { get; set; }


    }

}
