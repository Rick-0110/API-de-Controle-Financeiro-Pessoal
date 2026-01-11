using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FinanceControl.Domain.Entities
{
    public class Category
    {

        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        [ForeignKey("UserId")]
        public User? User { get; set; } = null!;

        public Category(string name, string description,int UserId)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("O nome da categoria é obrigatório!", nameof(name));
            if(UserId <= 0) throw new ArgumentException("Usuário inválido!", nameof(UserId));
            this.Name = name;
            this.Description = description;
            this.UserId = UserId;
        }

        public void Update(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("O nome da categoria é obrigatório!", nameof(name));
            this.Name = name;
            this.Description = description;
        }

        protected Category()
        {
        }
    }
}
