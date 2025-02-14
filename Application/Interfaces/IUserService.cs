using RedeSocial_Auth.Domain.Models.Users;
using System.Collections.Generic;

namespace RedeSocial_Auth.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(Guid id);
        Task<User> AddUser(User user);
        Task<User> DeleteUser(Guid id);
        Task<User> UpdateUser(Guid id, User user);
    }
}