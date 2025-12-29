using System.ComponentModel.DataAnnotations;

namespace FinanceControl.Application.Dtos
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "O formato do e-mail é inválido")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")] 
        public string Password { get; set; }
        
    }

}
