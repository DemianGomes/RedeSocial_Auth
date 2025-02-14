using RedeSocial_Auth.Domain.Models.Users;

namespace RedeSocial_Auth.Infrastructure.Persistence.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(Guid id);
        Task<User> AddUser(User user);
        Task<User> DeleteUser(Guid id);
        Task<User> UpdateUser(Guid id, User user);
    }
}