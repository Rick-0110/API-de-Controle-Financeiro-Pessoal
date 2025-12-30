using System.Text.Json.Serialization;

namespace FinanceControl.Domain.Entities
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; } = null!;

        public Category(string name, string description,int UserId)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("O nome da categoria é obrigatório!", nameof(name));
            if(UserId <= 0) throw new ArgumentException("Usuário inválido!", nameof(UserId));
            this.Name = name;
            this.Description = description;
            this.UserId = UserId;
        }

        protected Category()
        {
        }
    }
}
