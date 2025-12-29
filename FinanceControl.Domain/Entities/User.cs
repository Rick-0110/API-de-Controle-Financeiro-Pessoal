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


        public User(string name, string email, string password) 
        {
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("O nome é obrigatório!", nameof(name));

        Name = name;
        Email = email;
        Password = password;

        }

        protected User() { }
    }
}
