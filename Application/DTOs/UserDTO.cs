using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RedeSocial_Auth.Application.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public string Email { get; set; }
    }
}
