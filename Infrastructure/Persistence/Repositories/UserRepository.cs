using Microsoft.EntityFrameworkCore;
using RedeSocial_Auth.Domain.Models.Users;
using RedeSocial_Auth.Infrastructure.Persistence.Interfaces;

namespace RedeSocial_Auth.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException($"Usuário com ID {id} não foi encontrado.");
            return user;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException($"Usuário com ID {id} não foi encontrado.");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(Guid id, User user)
        {
            var userToUpdate = await _context.Users.FindAsync(id) ?? throw new KeyNotFoundException($"Usuário com ID {id} não foi encontrado.");
            userToUpdate.Username = user.Username;
            userToUpdate.Email = user.Email;
            userToUpdate.PasswordHash = user.PasswordHash;
            userToUpdate.Birthday = user.Birthday;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return userToUpdate;
        }
    }
}