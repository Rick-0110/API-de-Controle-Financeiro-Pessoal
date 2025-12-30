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


        // TODO: [SECURITY] Remover UserId do DTO após implementar Autenticação JWT.
        // Atualmente mantido para testes de integração de banco de dados.
        [Required]
        public int UserId { get; set; }
    }

}
