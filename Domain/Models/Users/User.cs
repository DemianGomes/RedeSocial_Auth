using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RedeSocial_Auth.Domain.Models.Users
{
    public class User
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateOnly Birthday { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
