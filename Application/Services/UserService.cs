using RedeSocial_Auth.Application.Interfaces;
using RedeSocial_Auth.Domain.Models.Users;
using RedeSocial_Auth.Infrastructure.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedeSocial_Auth.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
            
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            //Ordenando resultados
            return users.OrderBy(u => u.Username);
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            return user;
        }

        public async Task<User> AddUser(User user)
        {
            var addUser = await _userRepository.AddUser(user);

            switch (addUser)
            {
                case null:
                    throw new ArgumentException("Requisição inválida");
                default:
                    return addUser;
            }
        }

        public async Task<User> DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id).Result;

            if (user == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            await _userRepository.DeleteUser(id);
            return user;
        }

        public async Task<User> UpdateUser(Guid id, User user)
        {
            var userToUpdate = await _userRepository.GetUserById(id);

            if (userToUpdate == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado");
            }

            userToUpdate.Username = user.Username;
            userToUpdate.Email = user.Email;
            userToUpdate.PasswordHash = user.PasswordHash;

            await _userRepository.UpdateUser(id, userToUpdate);
            return userToUpdate;
        }
    }
}