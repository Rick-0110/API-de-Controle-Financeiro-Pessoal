using System.Text.Json.Serialization;

namespace FinanceControl.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Transaction> Trasactions { get; set; } = new List<Transaction>();

        [JsonIgnore]
        public ICollection<Category> Categories{ get; set; } = new List<Category>();
    }
}
